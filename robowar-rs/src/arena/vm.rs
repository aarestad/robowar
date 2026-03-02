use std::collections::HashMap;

use crate::arena::engine::Weapon;

#[derive(Debug, Clone, Copy, PartialEq, Eq)]
pub enum Instruction {
    Nop,
    End,

    Plus,
    Minus,
    Times,
    Division,
    Mod,

    More,
    Less,
    Same,
    NotSame,

    And,
    Or,
    Xor,
    Not,

    Store,
    Drop,
    Swap,
    Roll,
    Dup,

    Jump,
    Call,
    If,
    Ife,
    Ifg,
    Ifeg,

    Recall,
    VStore,
    VRecall,

    Sin,
    Cos,
    Tan,
    Arctan,
    Abs,
    Sqrt,
    Chs,

    Distance,

    Beep,
    Print,
    Sync,
    Debug,

    Icon(u8),
    Sound(u8),

    Radar,
    Scan,
    Targets,
    Walls,

    Move,
    Turn,
    Shoot,
    Fire,

    ShieldUp,
    ShieldDown,

    Energy,
    Damage,

    GetX,
    GetY,
    GetDir,
    SetDir,
}

impl Instruction {
    pub fn from_magic(magic: i16) -> Option<Self> {
        match magic {
            20111 => Some(Instruction::Nop),
            20110 => Some(Instruction::End),

            20000 => Some(Instruction::Plus),
            20001 => Some(Instruction::Minus),
            20002 => Some(Instruction::Times),
            20003 => Some(Instruction::Division),
            20015 => Some(Instruction::Mod),

            20004 => Some(Instruction::More),
            20005 => Some(Instruction::Less),
            20006 => Some(Instruction::Same),
            20007 => Some(Instruction::NotSame),

            20112 => Some(Instruction::And),
            20113 => Some(Instruction::Or),
            20114 => Some(Instruction::Xor),
            20118 => Some(Instruction::Not),

            20100 => Some(Instruction::Store),
            20101 => Some(Instruction::Drop),
            20102 => Some(Instruction::Swap),
            20103 => Some(Instruction::Roll),
            20106 => Some(Instruction::Dup),

            20104 => Some(Instruction::Jump),
            20105 => Some(Instruction::Call),
            20107 => Some(Instruction::If),
            20108 => Some(Instruction::Ife),
            20140 => Some(Instruction::Ifg),
            20141 => Some(Instruction::Ifeg),

            20109 => Some(Instruction::Recall),
            20137 => Some(Instruction::VStore),
            20138 => Some(Instruction::VRecall),

            20121 => Some(Instruction::Sin),
            20122 => Some(Instruction::Cos),
            20123 => Some(Instruction::Tan),
            20119 => Some(Instruction::Arctan),
            20120 => Some(Instruction::Abs),
            20124 => Some(Instruction::Sqrt),
            20117 => Some(Instruction::Chs),

            20139 => Some(Instruction::Distance),

            20116 => Some(Instruction::Beep),
            20135 => Some(Instruction::Print),
            20136 => Some(Instruction::Sync),
            20142 => Some(Instruction::Debug),

            20125..=20134 => Some(Instruction::Icon((magic - 20125) as u8)),
            20143..=20152 => Some(Instruction::Sound((magic - 20143) as u8)),

            20153 => Some(Instruction::Radar),
            20154 => Some(Instruction::Scan),
            20155 => Some(Instruction::Targets),
            20156 => Some(Instruction::Walls),

            20157 => Some(Instruction::Move),
            20158 => Some(Instruction::Turn),
            20159 => Some(Instruction::Shoot),
            20160 => Some(Instruction::Fire),

            20161 => Some(Instruction::ShieldUp),
            20162 => Some(Instruction::ShieldDown),

            20163 => Some(Instruction::Energy),
            20164 => Some(Instruction::Damage),

            20165 => Some(Instruction::GetX),
            20166 => Some(Instruction::GetY),
            20167 => Some(Instruction::GetDir),
            20168 => Some(Instruction::SetDir),

            _ => None,
        }
    }

    pub fn to_magic(&self) -> i16 {
        match self {
            Instruction::Nop => 20111,
            Instruction::End => 20110,
            Instruction::Plus => 20000,
            Instruction::Minus => 20001,
            Instruction::Times => 20002,
            Instruction::Division => 20003,
            Instruction::Mod => 20015,
            Instruction::More => 20004,
            Instruction::Less => 20005,
            Instruction::Same => 20006,
            Instruction::NotSame => 20007,
            Instruction::And => 20112,
            Instruction::Or => 20113,
            Instruction::Xor => 20114,
            Instruction::Not => 20118,
            Instruction::Store => 20100,
            Instruction::Drop => 20101,
            Instruction::Swap => 20102,
            Instruction::Roll => 20103,
            Instruction::Dup => 20106,
            Instruction::Jump => 20104,
            Instruction::Call => 20105,
            Instruction::If => 20107,
            Instruction::Ife => 20108,
            Instruction::Ifg => 20140,
            Instruction::Ifeg => 20141,
            Instruction::Recall => 20109,
            Instruction::VStore => 20137,
            Instruction::VRecall => 20138,
            Instruction::Sin => 20121,
            Instruction::Cos => 20122,
            Instruction::Tan => 20123,
            Instruction::Arctan => 20119,
            Instruction::Abs => 20120,
            Instruction::Sqrt => 20124,
            Instruction::Chs => 20117,
            Instruction::Distance => 20139,
            Instruction::Beep => 20116,
            Instruction::Print => 20135,
            Instruction::Sync => 20136,
            Instruction::Debug => 20142,
            Instruction::Icon(n) => 20125 + *n as i16,
            Instruction::Sound(n) => 20143 + *n as i16,
            Instruction::Radar => 20153,
            Instruction::Scan => 20154,
            Instruction::Targets => 20155,
            Instruction::Walls => 20156,
            Instruction::Move => 20157,
            Instruction::Turn => 20158,
            Instruction::Shoot => 20159,
            Instruction::Fire => 20160,
            Instruction::ShieldUp => 20161,
            Instruction::ShieldDown => 20162,
            Instruction::Energy => 20163,
            Instruction::Damage => 20164,
            Instruction::GetX => 20165,
            Instruction::GetY => 20166,
            Instruction::GetDir => 20167,
            Instruction::SetDir => 20168,
        }
    }
}

#[derive(Debug, Clone, Default)]
pub struct VmAction {
    pub move_distance: Option<i32>,
    pub turn_angle: Option<i32>,
    pub fire_weapon: Option<Weapon>,
    pub fire_power: Option<i32>,
    pub shield_up: bool,
    pub shield_down: bool,
    pub target_x: Option<i32>,
    pub target_y: Option<i32>,
    pub scan_angle: Option<i32>,
    pub print_text: Option<String>,
    pub play_sound: Option<u8>,
    pub set_icon: Option<u8>,
}

#[derive(Debug, Clone, Default)]
pub struct Vm {
    pub code: Vec<i16>,
    pub stack: Vec<i32>,
    pub variables: HashMap<i32, i32>,
    pub call_stack: Vec<usize>,
    pub ip: usize,
    pub running: bool,
    pub error: Option<String>,
    pub action: VmAction,
}

impl Vm {
    pub fn new() -> Self {
        Self {
            code: Vec::new(),
            stack: Vec::with_capacity(100),
            variables: HashMap::new(),
            call_stack: Vec::new(),
            ip: 0,
            running: true,
            error: None,
            action: VmAction::default(),
        }
    }

    pub fn reset(&mut self) {
        self.stack.clear();
        self.variables.clear();
        self.call_stack.clear();
        self.ip = 0;
        self.running = true;
        self.error = None;
        self.action = VmAction::default();
    }

    pub fn push(&mut self, value: i32) {
        if self.stack.len() < 100 {
            self.stack.push(value);
        } else {
            self.error = Some("Stack overflow".to_string());
        }
    }

    pub fn pop(&mut self) -> Option<i32> {
        self.stack.pop()
    }

    pub fn peek(&self) -> Option<i32> {
        self.stack.last().copied()
    }

    pub fn step_instruction(&mut self) -> bool {
        if !self.running || self.ip >= self.code.len() || self.error.is_some() {
            return false;
        }

        let instr = self.code[self.ip];
        self.execute_instruction(instr);

        if self.ip < self.code.len() && self.error.is_none() && self.running {
            self.ip += 1;
            return true;
        }
        false
    }

    pub fn execute(&mut self) {
        while self.running && self.ip < self.code.len() && self.error.is_none() {
            let instr = self.code[self.ip];
            self.execute_instruction(instr);
            if self.ip < self.code.len() && self.error.is_none() {
                self.ip += 1;
            }
        }
    }

    fn execute_instruction(&mut self, magic: i16) {
        if let Some(instr) = Instruction::from_magic(magic) {
            match instr {
                Instruction::End => {
                    self.running = false;
                }
                Instruction::Nop => {}

                Instruction::Plus => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        self.push(a.wrapping_add(b));
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Minus => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        self.push(b.wrapping_sub(a));
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Times => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        self.push(a.wrapping_mul(b));
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Division => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        if a != 0 {
                            self.push(b.wrapping_div(a));
                        } else {
                            self.error = Some("Division by zero".to_string());
                        }
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Mod => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        if a != 0 {
                            self.push(b.wrapping_rem(a));
                        } else {
                            self.error = Some("Mod by zero".to_string());
                        }
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::More => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        self.push(if b > a { 1 } else { 0 });
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Less => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        self.push(if b < a { 1 } else { 0 });
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Same => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        self.push(if b == a { 1 } else { 0 });
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::NotSame => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        self.push(if b != a { 1 } else { 0 });
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::And => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        self.push(b & a);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Or => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        self.push(b | a);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Xor => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        self.push(b ^ a);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Not => {
                    if let Some(a) = self.pop() {
                        self.push(!a);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Store => {
                    if let (Some(addr), Some(value)) = (self.pop(), self.pop()) {
                        self.variables.insert(addr, value);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Drop => {
                    self.pop();
                }
                Instruction::Swap => {
                    if let (Some(a), Some(b)) = (self.pop(), self.pop()) {
                        self.push(a);
                        self.push(b);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Roll => {
                    if let Some(count) = self.pop() {
                        if count > 0 && count as usize <= self.stack.len() {
                            let len = self.stack.len();
                            let idx = len - count as usize;
                            let value = self.stack.remove(idx);
                            self.push(value);
                        }
                    }
                }
                Instruction::Dup => {
                    if let Some(top) = self.peek() {
                        self.push(top);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Jump => {
                    if let Some(addr) = self.pop() {
                        if addr >= 0 && (addr as usize) < 5000 {
                            self.ip = addr as usize;
                        } else {
                            self.error = Some("Jump destination out of bounds".to_string());
                        }
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Call => {
                    if let Some(addr) = self.pop() {
                        if addr >= 0 && (addr as usize) < 5000 {
                            self.call_stack.push(self.ip);
                            self.ip = addr as usize;
                        } else {
                            self.error = Some("Call destination out of bounds".to_string());
                        }
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::If => {
                    if let (Some(addr), Some(cond)) = (self.pop(), self.pop()) {
                        if cond != 0 {
                            if addr >= 0 && (addr as usize) < 5000 {
                                self.ip = addr as usize;
                            } else {
                                self.error = Some("Jump destination out of bounds".to_string());
                            }
                        }
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Ife => {
                    if let (Some(addr), Some(cond)) = (self.pop(), self.pop()) {
                        if cond == 0 {
                            if addr >= 0 && (addr as usize) < 5000 {
                                self.ip = addr as usize;
                            } else {
                                self.error = Some("Jump destination out of bounds".to_string());
                            }
                        }
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Ifg => {
                    if let (Some(addr), Some(cond)) = (self.pop(), self.pop()) {
                        if cond > 0 {
                            if addr >= 0 && (addr as usize) < 5000 {
                                self.ip = addr as usize;
                            } else {
                                self.error = Some("Jump destination out of bounds".to_string());
                            }
                        }
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Ifeg => {
                    if let (Some(addr), Some(cond)) = (self.pop(), self.pop()) {
                        if cond >= 0 {
                            if addr >= 0 && (addr as usize) < 5000 {
                                self.ip = addr as usize;
                            } else {
                                self.error = Some("Jump destination out of bounds".to_string());
                            }
                        }
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Recall => {
                    if let Some(addr) = self.pop() {
                        self.push(*self.variables.get(&addr).unwrap_or(&0));
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::VStore => {
                    if let Some(value) = self.pop() {
                        self.variables.insert(0, value);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::VRecall => {
                    self.push(*self.variables.get(&0).unwrap_or(&0));
                }
                Instruction::Sin => {
                    if let Some(a) = self.pop() {
                        self.push((a as f64).sin() as i32);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Cos => {
                    if let Some(a) = self.pop() {
                        self.push((a as f64).cos() as i32);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Tan => {
                    if let Some(a) = self.pop() {
                        self.push((a as f64).tan() as i32);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Arctan => {
                    if let Some(a) = self.pop() {
                        self.push((a as f64).atan() as i32);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Abs => {
                    if let Some(a) = self.pop() {
                        self.push(a.abs());
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Sqrt => {
                    if let Some(a) = self.pop() {
                        self.push((a as f64).sqrt() as i32);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Chs => {
                    if let Some(a) = self.pop() {
                        self.push(-a);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Move => {
                    if let Some(dist) = self.pop() {
                        self.action.move_distance = Some(dist);
                        self.push(0);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Turn => {
                    if let Some(angle) = self.pop() {
                        self.action.turn_angle = Some(angle);
                        self.push(0);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Shoot => {
                    if let Some(power) = self.pop() {
                        self.action.fire_weapon = Some(Weapon::Bullet);
                        self.action.fire_power = Some(power);
                        self.push(0);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Fire => {
                    if let Some(power) = self.pop() {
                        self.action.fire_weapon = Some(Weapon::Bullet);
                        self.action.fire_power = Some(power);
                        self.push(0);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::ShieldUp => {
                    self.action.shield_up = true;
                    self.push(0);
                }
                Instruction::ShieldDown => {
                    self.action.shield_down = true;
                    self.push(0);
                }
                Instruction::Energy => {
                    self.push(100);
                }
                Instruction::Damage => {
                    self.push(0);
                }
                Instruction::GetX => {
                    self.push(150);
                }
                Instruction::GetY => {
                    self.push(150);
                }
                Instruction::GetDir => {
                    self.push(0);
                }
                Instruction::SetDir => {
                    if let Some(_dir) = self.pop() {
                        self.action.turn_angle = Some(0);
                    }
                }
                Instruction::Radar => {
                    if let Some(angle) = self.pop() {
                        self.action.scan_angle = Some(angle);
                        self.push(0);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Scan => {
                    if let Some(angle) = self.pop() {
                        self.action.scan_angle = Some(angle);
                        self.push(0);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
                Instruction::Targets => {
                    self.push(0);
                }
                Instruction::Walls => {
                    if let Some(_angle) = self.pop() {
                        self.push(300);
                    } else {
                        self.push(300);
                    }
                }
                Instruction::Beep => {
                    self.action.play_sound = Some(0);
                }
                Instruction::Print => {
                    if let Some(text) = self.pop() {
                        self.action.print_text = Some(format!("{}", text));
                    }
                }
                Instruction::Sync => {}
                Instruction::Debug => {}
                Instruction::Icon(n) => {
                    self.action.set_icon = Some(n);
                }
                Instruction::Sound(n) => {
                    self.action.play_sound = Some(n);
                }
                Instruction::Distance => {
                    if let (Some(x1), Some(y1), Some(x2), Some(y2)) =
                        (self.pop(), self.pop(), self.pop(), self.pop())
                    {
                        let dx = x2 as f64 - x1 as f64;
                        let dy = y2 as f64 - y1 as f64;
                        self.push(((dx * dx + dy * dy).sqrt()) as i32);
                    } else {
                        self.error = Some("Stack underflow".to_string());
                    }
                }
            }
        } else if (0..1000).contains(&magic) {
            self.push(magic as i32);
        }
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_vm_basic_math() {
        let mut vm = Vm::new();
        vm.stack = vec![3, 5];
        vm.execute_instruction(Instruction::Plus.to_magic());
        assert_eq!(vm.stack.last(), Some(&8));
    }
}
