mod config;

use std::env;
use std::path::PathBuf;

fn main() {
    env_logger::init();

    let args: Vec<String> = env::args().collect();

    if args.len() >= 2 && args[1] == "convert-cfg" {
        let cfg_path = PathBuf::from(&args[2]);
        let json_path = if args.len() >= 4 {
            PathBuf::from(&args[3])
        } else {
            cfg_path.with_extension("json")
        };

        match config::convert_cfg_to_json(&cfg_path, &json_path) {
            Ok(prefs) => {
                println!("Converted successfully!");
                println!("Preferences: {:?}", prefs);
                println!("Output: {}", json_path.display());
            }
            Err(e) => {
                eprintln!("Error: {}", e);
                std::process::exit(1);
            }
        }
    } else if args.len() >= 2 && args[1] == "convert-all" {
        let source_dir = PathBuf::from(".");
        let miscdata = source_dir.join("miscdata");

        let conversions = [("MainPrefs.cfg", "preferences.json")];

        for (cfg_name, json_name) in conversions {
            let cfg_path = miscdata.join(cfg_name);
            let json_path = miscdata.join(json_name);

            if cfg_path.exists() {
                match config::convert_cfg_to_json(&cfg_path, &json_path) {
                    Ok(_) => println!("Converted {} -> {}", cfg_name, json_name),
                    Err(e) => eprintln!("Error converting {}: {}", cfg_name, e),
                }
            } else {
                println!("Skipping {} (not found)", cfg_name);
            }
        }
    } else {
        run_gui();
    }
}

fn run_gui() {
    use gio::prelude::ApplicationExtManual;
    use gtk4::prelude::*;

    let app = robowar::ui::app::create_app();

    app.connect_activate(|app| {
        let window = robowar::ui::main_window::create_main_window(app);
        window.show();
    });

    app.run();
}
