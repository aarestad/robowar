use super::robot::Robot;
use super::vm::Vm;
use std::collections::VecDeque;

const ARENA_SIZE: i32 = 300;

#[derive(Debug, Clone, Copy, PartialEq)]
pub enum Direction {
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3,
}

impl Direction {
    pub fn to_radians(&self) -> f64 {
        match self {
            Direction::Up => 0.0,
            Direction::Right => std::f64::consts::FRAC_PI_2,
            Direction::Down => std::f64::consts::PI,
            Direction::Left => 3.0 * std::f64::consts::FRAC_PI_2,
        }
    }
}

#[derive(Debug, Clone, Copy, PartialEq)]
pub enum Weapon {
    None,
    Bullet,
    Missile,
    Hellbore,
    Laser,
    Mine,
    TacNuke,
    Stunner,
    Drone,
    MegaNuke,
}

#[derive(Debug, Clone)]
pub struct Shot {
    pub x: f64,
    pub y: f64,
    pub vx: f64,
    pub vy: f64,
    pub weapon: Weapon,
    pub owner: usize,
    pub damage: i32,
    pub lifetime: i32,
}

#[derive(Debug, Clone)]
pub struct RobotState {
    pub x: f64,
    pub y: f64,
    pub direction: Direction,
    pub energy: i32,
    pub damage: i32,
    pub shield: i32,
    pub alive: bool,
    pub vm: Vm,
}

impl RobotState {
    pub fn new(robot: &Robot, start_x: f64, start_y: f64, direction: Direction) -> Self {
        Self {
            x: start_x,
            y: start_y,
            direction,
            energy: robot.hardware.energy as i32,
            damage: 0,
            shield: 0,
            alive: true,
            vm: Vm::new(),
        }
    }
}

pub struct Arena {
    pub robots: Vec<RobotState>,
    pub shots: VecDeque<Shot>,
    pub chronon: i32,
    pub max_chronons: i32,
    pub running: bool,
    pub winner: Option<usize>,
}

impl Arena {
    pub fn new() -> Self {
        Self {
            robots: Vec::new(),
            shots: VecDeque::new(),
            chronon: 0,
            max_chronons: 10000,
            running: false,
            winner: None,
        }
    }

    pub fn add_robot(&mut self, robot: &Robot, position: usize) {
        let (x, y, dir) = match position {
            0 => (50.0, 50.0, Direction::Down),
            1 => (250.0, 50.0, Direction::Down),
            2 => (50.0, 250.0, Direction::Up),
            3 => (250.0, 250.0, Direction::Up),
            4 => (150.0, 50.0, Direction::Down),
            5 => (150.0, 250.0, Direction::Up),
            _ => (150.0, 150.0, Direction::Down),
        };

        let mut state = RobotState::new(robot, x, y, dir);
        state.vm.code = robot.code.clone();
        self.robots.push(state);
    }

    pub fn start(&mut self) {
        self.chronon = 0;
        self.running = true;
        self.winner = None;
        self.shots.clear();

        for robot in &mut self.robots {
            robot.vm.reset();
            robot.vm.code = robot.vm.code.clone();
        }
    }

    pub fn step(&mut self) {
        if !self.running {
            return;
        }

        self.chronon += 1;

        for (idx, robot) in self.robots.iter_mut().enumerate() {
            if !robot.alive {
                continue;
            }

            robot.vm.execute();

            if let Some(err) = &robot.vm.error {
                log::warn!("Robot {} error at chronon {}: {}", idx, self.chronon, err);
                robot.alive = false;
            }
        }

        self.update_shots();
        self.check_collisions();
        self.check_winner();
    }

    pub fn step_instruction_all(&mut self) {
        if !self.running {
            return;
        }

        for (idx, robot) in self.robots.iter_mut().enumerate() {
            if !robot.alive || robot.vm.error.is_some() {
                continue;
            }

            let continued = robot.vm.step_instruction();

            if let Some(err) = &robot.vm.error {
                log::warn!(
                    "Robot {} error at instruction {}: {}",
                    idx,
                    robot.vm.ip,
                    err
                );
                robot.alive = false;
            }

            if !continued {
                robot.vm.running = false;
            }
        }

        if self.chronon == 0 {
            self.chronon = 1;
        }
    }

    pub fn step_chronon(&mut self) {
        if !self.running {
            return;
        }

        self.chronon += 1;

        for robot in &mut self.robots {
            if !robot.alive {
                continue;
            }
            robot.vm.running = true;
        }

        let mut all_stopped = false;
        while !all_stopped && self.running {
            all_stopped = true;
            for robot in &mut self.robots {
                if !robot.alive || robot.vm.error.is_some() {
                    continue;
                }
                if robot.vm.running && robot.vm.ip < robot.vm.code.len() {
                    robot.vm.execute();
                    if let Some(err) = &robot.vm.error {
                        log::warn!("Robot error at chronon {}: {}", self.chronon, err);
                        robot.alive = false;
                    }
                    if robot.vm.running {
                        all_stopped = false;
                    }
                }
            }
        }

        self.update_shots();
        self.check_collisions();
        self.check_winner();
    }

    fn update_shots(&mut self) {
        for shot in &mut self.shots {
            shot.x += shot.vx;
            shot.y += shot.vy;
            shot.lifetime -= 1;
        }

        self.shots.retain(|s| {
            s.lifetime > 0
                && s.x >= 0.0
                && s.x < ARENA_SIZE as f64
                && s.y >= 0.0
                && s.y < ARENA_SIZE as f64
        });
    }

    fn check_collisions(&mut self) {
        for (idx, robot) in self.robots.iter_mut().enumerate() {
            if !robot.alive {
                continue;
            }

            if robot.x < 0.0
                || robot.x >= ARENA_SIZE as f64
                || robot.y < 0.0
                || robot.y >= ARENA_SIZE as f64
            {
                robot.alive = false;
                robot.damage = 1000;
            }

            for shot in &self.shots {
                if shot.owner == idx {
                    continue;
                }

                let dx = robot.x - shot.x;
                let dy = robot.y - shot.y;
                let dist = (dx * dx + dy * dy).sqrt();

                if dist < 10.0 {
                    robot.damage += shot.damage;
                    if robot.shield > 0 {
                        robot.shield -= shot.damage / 2;
                        if robot.shield < 0 {
                            robot.damage = -robot.shield;
                            robot.shield = 0;
                        }
                    }

                    if robot.damage >= robot.energy {
                        robot.alive = false;
                    }
                }
            }
        }
    }

    fn check_winner(&mut self) {
        let alive_count = self.robots.iter().filter(|r| r.alive).count();

        if alive_count <= 1 {
            self.running = false;
            self.winner = self.robots.iter().position(|r| r.alive);
        }

        if self.chronon >= self.max_chronons {
            self.running = false;
            let max_energy = self.robots.iter().map(|r| r.energy - r.damage).max();
            if let Some(max) = max_energy {
                self.winner = self.robots.iter().position(|r| r.energy - r.damage == max);
            }
        }
    }

    pub fn fire_weapon(&mut self, robot_idx: usize, weapon: Weapon, power: i32) {
        if robot_idx >= self.robots.len() {
            return;
        }

        let robot = &self.robots[robot_idx];
        if !robot.alive {
            return;
        }

        let (vx, vy) = match robot.direction {
            Direction::Up => (0.0, -power as f64),
            Direction::Right => (power as f64, 0.0),
            Direction::Down => (0.0, power as f64),
            Direction::Left => (-power as f64, 0.0),
        };

        let damage = match weapon {
            Weapon::Bullet => 10,
            Weapon::Missile => 30,
            Weapon::Hellbore => 50,
            Weapon::Laser => 5,
            Weapon::Mine => 0,
            Weapon::TacNuke => 100,
            Weapon::Stunner => 0,
            Weapon::Drone => 20,
            Weapon::MegaNuke => 200,
            Weapon::None => 0,
        };

        let shot = Shot {
            x: robot.x,
            y: robot.y,
            vx,
            vy,
            weapon,
            owner: robot_idx,
            damage,
            lifetime: 100,
        };

        self.shots.push_back(shot);
    }
}

impl Default for Arena {
    fn default() -> Self {
        Self::new()
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_arena_creation() {
        let arena = Arena::new();
        assert_eq!(arena.robots.len(), 0);
        assert!(arena.running == false);
    }
}
