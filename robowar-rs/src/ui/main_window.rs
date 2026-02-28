use std::cell::RefCell;
use std::rc::Rc;

use gtk::prelude::*;
use gtk4 as gtk;

use crate::arena::engine::Arena;
use crate::arena::robot::{load_sample_robots, Robot};

const ARENA_DRAW_SIZE: i32 = 400;

pub fn create_main_window(app: &gtk::Application) -> gtk::ApplicationWindow {
    let window = gtk::ApplicationWindow::new(app);
    window.set_title(Some("RoboWar 5 - Arena"));
    window.set_default_size(800, 600);

    let header = gtk::HeaderBar::new();
    header.set_title_widget(Some(&gtk::Label::new(Some("RoboWar 5"))));
    window.set_titlebar(Some(&header));

    let vbox = gtk::Box::new(gtk::Orientation::Vertical, 0);

    let toolbar = gtk::Box::new(gtk::Orientation::Horizontal, 5);
    toolbar.set_margin_start(5);
    toolbar.set_margin_end(5);
    toolbar.set_margin_top(5);
    toolbar.set_margin_bottom(5);

    let battle_btn = gtk::Button::with_label("Start Battle");
    let stop_btn = gtk::Button::with_label("Stop");
    let step_btn = gtk::Button::with_label("Step");
    let reset_btn = gtk::Button::with_label("Reset");

    let status_label = gtk::Label::new(Some("Ready - Load robots to begin"));

    toolbar.append(&battle_btn);
    toolbar.append(&stop_btn);
    toolbar.append(&step_btn);
    toolbar.append(&reset_btn);
    toolbar.append(&status_label);

    let arena = Rc::new(RefCell::new(Arena::new()));

    let arena_view = gtk::Box::new(gtk::Orientation::Vertical, 0);
    arena_view.set_size_request(ARENA_DRAW_SIZE, ARENA_DRAW_SIZE);
    arena_view.set_halign(gtk::Align::Center);
    arena_view.set_valign(gtk::Align::Center);

    let arena_placeholder = gtk::Label::new(Some("Arena View\n(Render support coming soon)"));
    arena_placeholder.set_height_request(ARENA_DRAW_SIZE);
    arena_placeholder.set_width_request(ARENA_DRAW_SIZE);
    arena_placeholder.set_justify(gtk::Justification::Center);
    arena_view.append(&arena_placeholder);

    let sidebar = gtk::Box::new(gtk::Orientation::Vertical, 10);
    sidebar.set_margin_start(10);
    sidebar.set_margin_end(10);
    sidebar.set_margin_top(10);
    sidebar.set_margin_bottom(10);
    sidebar.set_width_request(200);

    let robots_label = gtk::Label::new(Some("<b>Robots</b>"));
    robots_label.set_use_markup(true);
    sidebar.append(&robots_label);

    let robots_list = gtk::Box::new(gtk::Orientation::Vertical, 5);
    let loaded_robots = Rc::new(RefCell::new(Vec::<Robot>::new()));

    let add_robot_btn = gtk::Button::with_label("Add Robot...");
    sidebar.append(&add_robot_btn);
    sidebar.append(&robots_list);

    let info_frame = gtk::Frame::new(Some("Battle Info"));
    let info_box = gtk::Box::new(gtk::Orientation::Vertical, 5);
    info_box.set_margin_start(5);
    info_box.set_margin_end(5);
    info_box.set_margin_top(5);
    info_box.set_margin_bottom(5);

    let chronon_label = gtk::Label::new(Some("Chronons: 0"));
    let winner_label = gtk::Label::new(Some("Winner: None"));

    info_box.append(&chronon_label);
    info_box.append(&winner_label);
    info_frame.set_child(Some(&info_box));
    sidebar.append(&info_frame);

    let main_box = gtk::Box::new(gtk::Orientation::Horizontal, 0);
    main_box.append(&arena_view);
    main_box.append(&sidebar);

    vbox.append(&toolbar);
    vbox.append(&main_box);

    window.set_child(Some(&vbox));

    let status_label_clone = status_label.clone();
    battle_btn.connect_clicked(move |_| {
        status_label_clone.set_text("Battle in progress...");
    });

    let arena_clone = arena.clone();
    let status_label2 = status_label.clone();
    let chronon_label2 = chronon_label.clone();
    let winner_label2 = winner_label.clone();

    step_btn.connect_clicked(move |_| {
        let mut arena = arena_clone.borrow_mut();
        arena.step();
        chronon_label2.set_text(&format!("Chronons: {}", arena.chronon));

        let robot_info: Vec<String> = arena
            .robots
            .iter()
            .enumerate()
            .filter(|(_, r)| r.alive)
            .map(|(i, r)| format!("R{}: E={}", i + 1, r.energy - r.damage))
            .collect();
        if !robot_info.is_empty() {
            status_label2.set_text(&robot_info.join(", "));
        }

        if !arena.running {
            if let Some(winner) = arena.winner {
                winner_label2.set_text(&format!("Winner: Robot {}", winner + 1));
                status_label2.set_text("Battle complete!");
            } else {
                status_label2.set_text("Battle ended - no winner");
            }
        }
    });

    let arena_clone2 = arena.clone();
    let status_label3 = status_label.clone();
    stop_btn.connect_clicked(move |_| {
        let mut arena = arena_clone2.borrow_mut();
        arena.running = false;
        status_label3.set_text("Battle stopped");
    });

    let arena_clone3 = arena.clone();
    let status_label4 = status_label.clone();
    let robots_list_clone = robots_list.clone();
    let loaded_robots_clone = loaded_robots.clone();

    add_robot_btn.connect_clicked(move |_| {
        let sample_robots = load_sample_robots(std::path::Path::new("."));
        let mut loaded = loaded_robots_clone.borrow_mut();
        let mut arena = arena_clone3.borrow_mut();

        if loaded.is_empty() && !sample_robots.is_empty() {
            for (i, robot) in sample_robots.iter().take(4).enumerate() {
                arena.add_robot(robot, i);
                loaded.push(robot.clone());

                let robot_label = gtk::Label::new(Some(&format!("{}. {}", i + 1, robot.name)));
                robots_list_clone.append(&robot_label);
            }
            status_label4.set_text(&format!("Loaded {} robots", loaded.len()));
        } else if loaded.len() >= 4 {
            status_label4.set_text("Maximum 4 robots per battle");
        } else {
            status_label4.set_text("No robot files found");
        }
    });

    window
}
