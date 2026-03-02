use std::cell::RefCell;
use std::rc::Rc;

use gtk::prelude::*;
use gtk4 as gtk;

use crate::arena::robot::{load_sample_robots, Robot};

#[derive(Clone)]
pub struct TournamentState {
    pub robots: Rc<RefCell<Vec<Robot>>>,
    pub rounds: Rc<RefCell<i32>>,
    pub allow_drones: Rc<RefCell<bool>>,
    pub allow_nearest: Rc<RefCell<bool>>,
    pub allow_move_and_shoot: Rc<RefCell<bool>>,
    pub allow_negative_energy: Rc<RefCell<bool>>,
    pub battle_speed: Rc<RefCell<i32>>,
    pub print_log: Rc<RefCell<bool>>,
}

impl TournamentState {
    pub fn new() -> Self {
        Self {
            robots: Rc::new(RefCell::new(Vec::new())),
            rounds: Rc::new(RefCell::new(10)),
            allow_drones: Rc::new(RefCell::new(true)),
            allow_nearest: Rc::new(RefCell::new(true)),
            allow_move_and_shoot: Rc::new(RefCell::new(true)),
            allow_negative_energy: Rc::new(RefCell::new(false)),
            battle_speed: Rc::new(RefCell::new(50)),
            print_log: Rc::new(RefCell::new(false)),
        }
    }
}

pub fn create_tournament_window(app: &gtk::Application) -> gtk::Window {
    let state = TournamentState::new();

    let window = gtk::Window::new();
    window.set_title(Some("Tournament"));
    window.set_default_size(700, 550);

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 10);
    main_box.set_margin_start(20);
    main_box.set_margin_end(20);
    main_box.set_margin_top(20);
    main_box.set_margin_bottom(20);

    let title = gtk::Label::new(Some("<span size='large' weight='bold'>Tournament</span>"));
    title.set_use_markup(true);
    main_box.append(&title);

    let robots_frame = gtk::Frame::new(Some("Select Robots"));
    let robots_box = gtk::Box::new(gtk::Orientation::Vertical, 5);
    robots_box.set_margin_start(10);
    robots_box.set_margin_end(10);
    robots_box.set_margin_top(10);
    robots_box.set_margin_bottom(10);

    let robots_list = gtk::ListBox::new();
    robots_list.set_hexpand(true);
    robots_list.set_vexpand(true);

    let robots_scroll = gtk::ScrolledWindow::new();
    robots_scroll.set_child(Some(&robots_list));
    robots_scroll.set_height_request(150);
    robots_box.append(&robots_scroll);

    let load_robots_btn = gtk::Button::with_label("Load Robots from Directory");
    robots_box.append(&load_robots_btn);
    robots_frame.set_child(Some(&robots_box));
    main_box.append(&robots_frame);

    let options_frame = gtk::Frame::new(Some("Tournament Options"));
    let options_grid = gtk::Grid::new();
    options_grid.set_row_spacing(8);
    options_grid.set_column_spacing(8);
    options_grid.set_margin_start(10);
    options_grid.set_margin_end(10);
    options_grid.set_margin_top(10);
    options_grid.set_margin_bottom(10);

    let rounds_label = gtk::Label::new(Some("Rounds:"));
    options_grid.attach(&rounds_label, 0, 0, 1, 1);
    let rounds_spin = gtk::SpinButton::with_range(1.0, 100.0, 1.0);
    rounds_spin.set_value(10.0);
    options_grid.attach(&rounds_spin, 1, 0, 1, 1);

    let speed_label = gtk::Label::new(Some("Battle Speed:"));
    options_grid.attach(&speed_label, 0, 1, 1, 1);
    let speed_scale = gtk::Scale::with_range(gtk::Orientation::Horizontal, 0.0, 100.0, 1.0);
    speed_scale.set_value(50.0);
    options_grid.attach(&speed_scale, 1, 1, 2, 1);

    let allow_drones = gtk::CheckButton::with_label("Allow Drones");
    allow_drones.set_active(true);
    options_grid.attach(&allow_drones, 0, 2, 3, 1);

    let allow_nearest = gtk::CheckButton::with_label("Allow Nearest");
    allow_nearest.set_active(true);
    options_grid.attach(&allow_nearest, 0, 3, 3, 1);

    let allow_move_shoot = gtk::CheckButton::with_label("Allow Move and Shoot");
    allow_move_shoot.set_active(true);
    options_grid.attach(&allow_move_shoot, 0, 4, 3, 1);

    let allow_neg_energy = gtk::CheckButton::with_label("Allow -200 > Energy");
    options_grid.attach(&allow_neg_energy, 0, 5, 3, 1);

    let print_log = gtk::CheckButton::with_label("Print Log (slows down!)");
    options_grid.attach(&print_log, 0, 6, 3, 1);

    options_frame.set_child(Some(&options_grid));
    main_box.append(&options_frame);

    let status_label = gtk::Label::new(Some("Ready to start tournament"));
    main_box.append(&status_label);

    let button_box = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    button_box.set_halign(gtk::Align::Center);

    let start_btn = gtk::Button::with_label("Start Tournament");
    let stop_btn = gtk::Button::with_label("Stop");
    let close_btn = gtk::Button::with_label("Close");

    button_box.append(&start_btn);
    button_box.append(&stop_btn);
    button_box.append(&close_btn);
    main_box.append(&button_box);

    window.set_child(Some(&main_box));

    let status_label_clone = status_label.clone();
    let robots_list_clone = robots_list.clone();
    let state_clone = state.clone();
    load_robots_btn.connect_clicked(move |_| {
        let resources_path = {
            let mut path = std::env::current_exe().unwrap_or_default();
            path.pop();
            path.join("resources")
        };
        let robots_path = resources_path.join("robots");
        let robots = load_sample_robots(&robots_path);

        let mut state_robots = state_clone.robots.borrow_mut();
        state_robots.clear();

        for robot in &robots {
            let row = gtk::ListBoxRow::new();
            let label = gtk::Label::new(Some(&robot.name));
            row.set_child(Some(&label));
            robots_list_clone.append(&row);
            state_robots.push(robot.clone());
        }

        status_label_clone.set_text(&format!("Loaded {} robots", robots.len()));
    });

    let status_label2 = status_label.clone();
    let state_clone2 = state.clone();
    start_btn.connect_clicked(move |_| {
        let robots = state_clone2.robots.borrow();
        let rounds = rounds_spin.value() as i32;

        if robots.len() < 2 {
            status_label2.set_text("Need at least 2 robots to start tournament");
            return;
        }

        status_label2.set_text(&format!(
            "Starting tournament with {} robots for {} rounds...",
            robots.len(),
            rounds
        ));
    });

    let window_clone = window.clone();
    close_btn.connect_clicked(move |_| {
        window_clone.close();
    });

    window
}
