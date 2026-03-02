use std::cell::RefCell;
use std::rc::Rc;

use gtk::prelude::*;
use gtk4 as gtk;

use crate::arena::robot::Robot;

pub fn create_drafting_board(_app: &gtk::Application, robot: Robot) -> gtk::Window {
    let window = gtk::Window::new();
    window.set_title(Some(&format!("RoboWar 5 - Drafting Board: {}", robot.name)));
    window.set_default_size(800, 600);

    let robot_rc = Rc::new(RefCell::new(robot));

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 0);

    let toolbar = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    toolbar.set_margin_start(10);
    toolbar.set_margin_end(10);
    toolbar.set_margin_top(10);
    toolbar.set_margin_bottom(10);

    let compile_btn = gtk::Button::with_label("Compile");
    let compile_close_btn = gtk::Button::with_label("Compile & Close");
    let cancel_btn = gtk::Button::with_label("Cancel");

    toolbar.append(&compile_btn);
    toolbar.append(&compile_close_btn);
    toolbar.append(&cancel_btn);

    let status_label = gtk::Label::new(Some("Ready to edit"));
    toolbar.append(&status_label);

    main_box.append(&toolbar);

    let paned = gtk::Paned::new(gtk::Orientation::Horizontal);

    let code_scroll = gtk::ScrolledWindow::new();
    let code_view = gtk::TextView::new();
    code_view.set_wrap_mode(gtk::WrapMode::Word);
    code_view.set_monospace(true);
    code_view.set_hexpand(true);
    code_view.set_vexpand(true);

    let buffer = code_view.buffer();
    let code_text = decode_robot_code(&robot_rc.borrow().code);
    buffer.set_text(&code_text);

    code_scroll.set_child(Some(&code_view));
    code_scroll.set_hexpand(true);
    code_scroll.set_vexpand(true);

    let info_box = gtk::Box::new(gtk::Orientation::Vertical, 10);
    info_box.set_margin_start(10);
    info_box.set_margin_end(10);
    info_box.set_margin_top(10);
    info_box.set_margin_bottom(10);
    info_box.set_width_request(200);

    let info_title = gtk::Label::new(Some("<b>Robot Info</b>"));
    info_title.set_use_markup(true);
    info_box.append(&info_title);

    let name_label = gtk::Label::new(Some(&format!("Name: {}", robot_rc.borrow().name)));
    info_box.append(&name_label);

    let energy_label = gtk::Label::new(Some(&format!(
        "Energy: {}",
        robot_rc.borrow().hardware.energy
    )));
    info_box.append(&energy_label);

    let damage_label = gtk::Label::new(Some(&format!(
        "Damage: {}",
        robot_rc.borrow().hardware.damage
    )));
    info_box.append(&damage_label);

    let shield_label = gtk::Label::new(Some(&format!(
        "Shield: {}",
        robot_rc.borrow().hardware.shield
    )));
    info_box.append(&shield_label);

    let processor_label = gtk::Label::new(Some(&format!(
        "Processor: {}",
        robot_rc.borrow().hardware.processor
    )));
    info_box.append(&processor_label);

    let memory_label = gtk::Label::new(Some(&format!(
        "Memory (NNE): {}",
        robot_rc.borrow().hardware.nne
    )));
    info_box.append(&memory_label);

    let weapons_label = gtk::Label::new(Some("<b>Weapons</b>"));
    weapons_label.set_use_markup(true);
    info_box.append(&weapons_label);

    let bullets_label = gtk::Label::new(Some(&format!(
        "Bullets: {}",
        robot_rc.borrow().hardware.bullets
    )));
    info_box.append(&bullets_label);

    let missiles_label = gtk::Label::new(Some(&format!(
        "Missiles: {}",
        robot_rc.borrow().hardware.missiles
    )));
    info_box.append(&missiles_label);

    let drones_label = gtk::Label::new(Some(&format!(
        "Drones: {}",
        robot_rc.borrow().hardware.drones
    )));
    info_box.append(&drones_label);

    let lasers_label = gtk::Label::new(Some(&format!(
        "Lasers: {}",
        robot_rc.borrow().hardware.lasers
    )));
    info_box.append(&lasers_label);

    let help_title = gtk::Label::new(Some("<b>Quick Help</b>"));
    help_title.set_use_markup(true);
    info_box.append(&help_title);

    let help_text = gtk::Label::new(Some(
        "Labels: name:\nIF: a b > label If\nMath: a b +\nFire: 1 fire' sto\nJump: label jump\nReturn: return"
    ));
    help_text.set_selectable(true);
    info_box.append(&help_text);

    let help_scroll = gtk::ScrolledWindow::new();
    help_scroll.set_child(Some(&info_box));
    help_scroll.set_width_request(220);

    paned.set_start_child(Some(&code_scroll));
    paned.set_end_child(Some(&help_scroll));
    paned.set_resize_start_child(true);
    paned.set_shrink_start_child(false);

    main_box.append(&paned);

    window.set_child(Some(&main_box));

    let robot_clone = robot_rc.clone();
    let buffer_clone = buffer.clone();
    compile_btn.connect_clicked(move |_| {
        let start = buffer_clone.start_iter();
        let end = buffer_clone.end_iter();
        let text = buffer_clone.text(&start, &end, true).to_string();
        let encoded = encode_robot_code(&text);
        robot_clone.borrow_mut().code = encoded;
        status_label.set_text("Compiled successfully!");
    });

    let robot_clone2 = robot_rc.clone();
    let buffer_clone2 = buffer.clone();
    let window_clone = window.clone();
    compile_close_btn.connect_clicked(move |_| {
        let start = buffer_clone2.start_iter();
        let end = buffer_clone2.end_iter();
        let text = buffer_clone2.text(&start, &end, true).to_string();
        let encoded = encode_robot_code(&text);
        robot_clone2.borrow_mut().code = encoded;
        window_clone.close();
    });

    let window_clone2 = window.clone();
    cancel_btn.connect_clicked(move |_| {
        window_clone2.close();
    });

    window
}

fn decode_robot_code(code: &[i16]) -> String {
    code.iter()
        .map(|&v| {
            if v >= 0 && v < 256 {
                let c = v as u8 as char;
                if c.is_ascii_graphic() || c == ' ' || c == '\n' || c == '\t' {
                    return c.to_string();
                }
            }
            format!("{}\n", v)
        })
        .collect()
}

fn encode_robot_code(text: &str) -> Vec<i16> {
    let mut code = Vec::new();
    for line in text.lines() {
        let line = line.trim();
        if line.is_empty() {
            continue;
        }

        let parts: Vec<&str> = line.split_whitespace().collect();
        for part in parts {
            if let Ok(num) = part.parse::<i16>() {
                code.push(num);
            }
        }
    }
    if code.is_empty() {
        code.push(20110);
    }
    code
}
