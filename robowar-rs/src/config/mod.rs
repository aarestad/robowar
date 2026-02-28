use std::fs::{self, File};
use std::io::{Read, Seek, SeekFrom, Write};
use std::path::Path;

#[derive(Debug, thiserror::Error)]
pub enum ConfigError {
    #[error("IO error: {0}")]
    Io(#[from] std::io::Error),
    #[error("Invalid config file: {0}")]
    Invalid(String),
}

#[derive(Debug, Clone, serde::Serialize, serde::Deserialize)]
pub struct Preferences {
    pub sounds: bool,
    pub scoring_system: bool,
    pub chronon_limit: bool,
    pub tournament_rounds: i32,
    pub tournament_value: i32,
    pub drafting_board_window_state: bool,
    pub main_window_window_state: bool,
    pub move_and_shoot: bool,
    pub reset_cursor_position: bool,
    pub overload_enabled: bool,
    pub first_time_startup: bool,
    pub ultra_warning: u8,
    pub auto_recompile: bool,
    pub debugger_window_x: i32,
    pub print_instruction_numbers: bool,
    pub syntax_coloring: bool,
    pub battle_speed: i32,
    pub change_resolution: bool,
    pub speed_constant: f32,
    pub auto_no_sound: bool,
}

impl Default for Preferences {
    fn default() -> Self {
        Self {
            sounds: true,
            scoring_system: true,
            chronon_limit: false,
            tournament_rounds: 10,
            tournament_value: 0,
            drafting_board_window_state: true,
            main_window_window_state: true,
            move_and_shoot: true,
            reset_cursor_position: true,
            overload_enabled: true,
            first_time_startup: true,
            ultra_warning: 0,
            auto_recompile: true,
            debugger_window_x: 0,
            print_instruction_numbers: false,
            syntax_coloring: true,
            battle_speed: 50,
            change_resolution: false,
            speed_constant: 1.0,
            auto_no_sound: false,
        }
    }
}

pub fn read_bool(file: &mut File, offset: u64) -> Result<bool, ConfigError> {
    let mut buffer = [0u8; 2];
    file.seek(SeekFrom::Start(offset))?;
    match file.read_exact(&mut buffer) {
        Ok(()) => {
            let value = u16::from_le_bytes(buffer);
            Ok(value != 0)
        }
        Err(_) => Ok(false),
    }
}

pub fn read_i32(file: &mut File, offset: u64) -> Result<i32, ConfigError> {
    let mut buffer = [0u8; 4];
    file.seek(SeekFrom::Start(offset))?;
    match file.read_exact(&mut buffer) {
        Ok(()) => Ok(i32::from_le_bytes(buffer)),
        Err(_) => Ok(0),
    }
}

pub fn read_u8(file: &mut File, offset: u64) -> Result<u8, ConfigError> {
    let mut buffer = [0u8; 1];
    file.seek(SeekFrom::Start(offset))?;
    match file.read_exact(&mut buffer) {
        Ok(()) => Ok(buffer[0]),
        Err(_) => Ok(0),
    }
}

pub fn read_f32(file: &mut File, offset: u64) -> Result<f32, ConfigError> {
    let mut buffer = [0u8; 4];
    file.seek(SeekFrom::Start(offset))?;
    match file.read_exact(&mut buffer) {
        Ok(()) => Ok(f32::from_le_bytes(buffer)),
        Err(_) => Ok(1.0),
    }
}

pub fn convert_cfg_to_json(cfg_path: &Path, json_path: &Path) -> Result<Preferences, ConfigError> {
    let mut file = File::open(cfg_path)?;

    let prefs = Preferences {
        sounds: read_bool(&mut file, 1000)?,
        scoring_system: read_bool(&mut file, 2500)?,
        chronon_limit: read_bool(&mut file, 3000)?,
        tournament_rounds: read_i32(&mut file, 3250)?,
        tournament_value: read_i32(&mut file, 3500)?,
        drafting_board_window_state: read_bool(&mut file, 4000)?,
        main_window_window_state: read_bool(&mut file, 4500)?,
        move_and_shoot: read_bool(&mut file, 5000)?,
        reset_cursor_position: read_bool(&mut file, 5500)?,
        overload_enabled: read_bool(&mut file, 6000)?,
        first_time_startup: read_bool(&mut file, 7000)?,
        ultra_warning: read_u8(&mut file, 7500)?,
        auto_recompile: read_bool(&mut file, 8000)?,
        debugger_window_x: read_i32(&mut file, 9000)?,
        print_instruction_numbers: read_bool(&mut file, 10000)?,
        syntax_coloring: read_bool(&mut file, 10500)?,
        battle_speed: read_i32(&mut file, 11000)?,
        change_resolution: read_bool(&mut file, 12000)?,
        speed_constant: read_f32(&mut file, 12500)?,
        auto_no_sound: read_bool(&mut file, 13000)?,
    };

    let json =
        serde_json::to_string_pretty(&prefs).map_err(|e| ConfigError::Invalid(e.to_string()))?;

    if let Some(parent) = json_path.parent() {
        fs::create_dir_all(parent)?;
    }

    let mut out_file = File::create(json_path)?;
    out_file.write_all(json.as_bytes())?;

    Ok(prefs)
}

#[allow(dead_code)]
pub fn load_preferences(config_dir: &Path) -> Preferences {
    let json_path = config_dir.join("preferences.json");

    if json_path.exists() {
        if let Ok(content) = fs::read_to_string(&json_path) {
            if let Ok(prefs) = serde_json::from_str(&content) {
                return prefs;
            }
        }
    }

    Preferences::default()
}

#[allow(dead_code)]
pub fn save_preferences(config_dir: &Path, prefs: &Preferences) -> Result<(), ConfigError> {
    let json_path = config_dir.join("preferences.json");

    if let Some(parent) = json_path.parent() {
        fs::create_dir_all(parent)?;
    }

    let json =
        serde_json::to_string_pretty(prefs).map_err(|e| ConfigError::Invalid(e.to_string()))?;
    fs::write(json_path, json)?;

    Ok(())
}

#[cfg(test)]
mod tests {
    use super::*;
    use std::io::Seek;

    #[test]
    fn test_preferences_default() {
        let prefs = Preferences::default();
        assert!(prefs.sounds);
        assert!(prefs.scoring_system);
        assert_eq!(prefs.battle_speed, 50);
    }
}
