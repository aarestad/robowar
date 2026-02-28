use std::fs::File;
use std::io::{Read, Seek, SeekFrom};
use std::path::Path;

#[derive(Debug, Clone, serde::Serialize, serde::Deserialize)]
pub struct RobotHardware {
    pub energy: i16,
    pub damage: i16,
    pub shield: i16,
    pub processor: u8,
    pub nne: u8,
    pub turret: u8,
    pub bullets: u8,
    pub missiles: u8,
    pub tac_nukes: u8,
    pub hellbores: u8,
    pub mines: u8,
    pub stunners: u8,
    pub drones: u8,
    pub lasers: u8,
    pub probes: u8,
    pub reserved: i32,
    pub shield_icon: u8,
    pub death_icon: u8,
    pub hit_icon: u8,
    pub block_icon: u8,
    pub collision_icon: u8,
}

impl Default for RobotHardware {
    fn default() -> Self {
        Self {
            energy: 100,
            damage: 0,
            shield: 0,
            processor: 1,
            nne: 1,
            turret: 0,
            bullets: 10,
            missiles: 0,
            tac_nukes: 0,
            hellbores: 0,
            mines: 0,
            stunners: 0,
            drones: 0,
            lasers: 0,
            probes: 0,
            reserved: 0,
            shield_icon: 0,
            death_icon: 1,
            hit_icon: 2,
            block_icon: 3,
            collision_icon: 4,
        }
    }
}

#[derive(Debug, Clone, serde::Serialize, serde::Deserialize)]
pub struct Robot {
    pub name: String,
    pub hardware: RobotHardware,
    pub icon_data: Option<Vec<u8>>,
    pub code: Vec<i16>,
}

impl Default for Robot {
    fn default() -> Self {
        Self {
            name: "New Robot".to_string(),
            hardware: RobotHardware::default(),
            icon_data: None,
            code: vec![20110],
        }
    }
}

const MC_REC: u64 = 112;
const C_REC: u64 = 116;

pub fn read_robot_file(path: &Path) -> std::io::Result<Robot> {
    let mut file = File::open(path)?;

    let mut buf = [0u8; 22];
    file.seek(SeekFrom::Start(0))?;
    file.read_exact(&mut buf)?;

    let hardware = RobotHardware {
        energy: i16::from_le_bytes([buf[0], buf[1]]),
        damage: i16::from_le_bytes([buf[2], buf[3]]),
        shield: i16::from_le_bytes([buf[4], buf[5]]),
        processor: buf[6],
        nne: buf[7],
        turret: buf[8],
        bullets: buf[9],
        missiles: buf[10],
        tac_nukes: buf[11],
        hellbores: buf[12],
        mines: buf[13],
        stunners: buf[14],
        drones: buf[15],
        lasers: buf[16],
        probes: buf[17],
        reserved: 0,
        shield_icon: 0,
        death_icon: 1,
        hit_icon: 2,
        block_icon: 3,
        collision_icon: 4,
    };

    let mut mc_offset_buf = [0u8; 4];
    file.seek(SeekFrom::Start(MC_REC))?;
    file.read_exact(&mut mc_offset_buf)?;
    let mc_offset = u32::from_le_bytes(mc_offset_buf) as u64;

    let mut code_size_buf = [0u8; 4];
    file.seek(SeekFrom::Start(C_REC))?;
    file.read_exact(&mut code_size_buf)?;
    let code_size = u32::from_le_bytes(code_size_buf) as usize;

    let mut code = Vec::with_capacity(code_size.min(5000));
    file.seek(SeekFrom::Start(mc_offset))?;
    for _ in 0..code_size.min(5000) {
        let mut instr_buf = [0u8; 2];
        match file.read_exact(&mut instr_buf) {
            Ok(()) => code.push(i16::from_le_bytes(instr_buf)),
            Err(_) => break,
        }
    }

    let filename = path
        .file_stem()
        .and_then(|s| s.to_str())
        .unwrap_or("Unknown")
        .to_string();

    Ok(Robot {
        name: filename,
        hardware,
        icon_data: None,
        code,
    })
}

pub fn save_robot_file(path: &Path, robot: &Robot) -> std::io::Result<()> {
    use std::fs::OpenOptions;
    use std::io::Write;

    let mut file = OpenOptions::new()
        .write(true)
        .create(true)
        .truncate(true)
        .open(path)?;

    let mut header = [0u8; 22];
    header[0..2].copy_from_slice(&robot.hardware.energy.to_le_bytes());
    header[2..4].copy_from_slice(&robot.hardware.damage.to_le_bytes());
    header[4..6].copy_from_slice(&robot.hardware.shield.to_le_bytes());
    header[6] = robot.hardware.processor;
    header[7] = robot.hardware.nne;
    header[8] = robot.hardware.turret;
    header[9] = robot.hardware.bullets;
    header[10] = robot.hardware.missiles;
    header[11] = robot.hardware.tac_nukes;
    header[12] = robot.hardware.hellbores;
    header[13] = robot.hardware.mines;
    header[14] = robot.hardware.stunners;
    header[15] = robot.hardware.drones;
    header[16] = robot.hardware.lasers;
    header[17] = robot.hardware.probes;

    file.write_all(&header)?;

    let placeholder = [0u8; 100];
    file.write_all(&placeholder)?;

    let icon_offset: i32 = 142;
    let icon_offset_bytes = icon_offset.to_le_bytes();
    file.write_all(&icon_offset_bytes)?;
    file.write_all(&icon_offset_bytes)?;

    file.seek(SeekFrom::Start(MC_REC))?;
    let mc_offset: u32 = 142;
    file.write_all(&mc_offset.to_le_bytes())?;

    let code_size: u32 = robot.code.len() as u32;
    file.write_all(&code_size.to_le_bytes())?;

    file.write_all(&[0u8; 4])?;
    file.write_all(&[0u8; 10])?;
    file.write_all(&[0u8; 2])?;
    file.write_all(&[0u8; 12])?;

    file.seek(SeekFrom::Start(142))?;
    for &instr in &robot.code {
        file.write_all(&instr.to_le_bytes())?;
    }

    Ok(())
}

pub fn load_sample_robots(robots_dir: &Path) -> Vec<Robot> {
    let mut robots = Vec::new();

    if let Ok(entries) = std::fs::read_dir(robots_dir) {
        for entry in entries.flatten() {
            let path = entry.path();
            if path.extension().is_some_and(|ext| ext == "rwr") {
                if let Ok(robot) = read_robot_file(&path) {
                    robots.push(robot);
                }
            }
        }
    }

    robots
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_default_robot() {
        let robot = Robot::default();
        assert_eq!(robot.name, "New Robot");
        assert_eq!(robot.hardware.energy, 100);
    }
}
