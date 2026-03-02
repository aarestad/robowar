use std::cell::RefCell;
use std::rc::Rc;

use gtk::prelude::*;
use gtk4 as gtk;

use crate::arena::engine::Arena;
use crate::arena::robot::Robot;

#[derive(Clone, Copy, PartialEq)]
pub enum DebugAction {
    None,
    Step,
    Chronon,
    Stop,
    Terminate,
}

pub struct DebuggerState {
    pub arena: Rc<RefCell<Arena>>,
    pub action: Rc<RefCell<DebugAction>>,
    pub current_robot: Rc<RefCell<usize>>,
}

impl Clone for DebuggerState {
    fn clone(&self) -> Self {
        Self {
            arena: Rc::clone(&self.arena),
            action: Rc::clone(&self.action),
            current_robot: Rc::clone(&self.current_robot),
        }
    }
}

impl DebuggerState {
    pub fn new() -> Self {
        Self {
            arena: Rc::new(RefCell::new(Arena::new())),
            action: Rc::new(RefCell::new(DebugAction::None)),
            current_robot: Rc::new(RefCell::new(0)),
        }
    }

    pub fn load_robots(&self, robots: &[Robot]) {
        let mut arena = self.arena.borrow_mut();
        arena.robots.clear();
        arena.chronon = 0;
        arena.running = true;
        arena.winner = None;

        for (i, robot) in robots.iter().enumerate() {
            arena.add_robot(robot, i);
        }
    }
}

pub fn create_debugger_window(app: &gtk::Application) -> gtk::Window {
    let state = DebuggerState::new();

    let window = gtk::Window::new();
    window.set_title(Some("Debug"));
    window.set_default_size(350, 600);

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 10);
    main_box.set_margin_start(15);
    main_box.set_margin_end(15);
    main_box.set_margin_top(15);
    main_box.set_margin_bottom(15);

    let title = gtk::Label::new(Some("<span size='large' weight='bold'>Debugger</span>"));
    title.set_use_markup(true);
    main_box.append(&title);

    let info_frame = gtk::Frame::new(Some("Battle Info"));
    let info_box = gtk::Box::new(gtk::Orientation::Vertical, 5);
    info_box.set_margin_start(10);
    info_box.set_margin_end(10);
    info_box.set_margin_top(5);
    info_box.set_margin_bottom(5);

    let chronon_label = gtk::Label::new(Some("Chronon: 0"));
    info_box.append(&chronon_label);

    let robots_frame = gtk::Frame::new(Some("Robots"));
    let robots_box = gtk::Box::new(gtk::Orientation::Vertical, 3);
    robots_box.set_margin_start(10);
    robots_box.set_margin_end(10);
    robots_box.set_margin_top(5);
    robots_box.set_margin_bottom(5);

    let robot1_label = gtk::Label::new(Some("R1: Energy=100 Damage=0 Alive"));
    robots_box.append(&robot1_label);

    let robot2_label = gtk::Label::new(Some("R2: Energy=100 Damage=0 Alive"));
    robots_box.append(&robot2_label);

    robots_frame.set_child(Some(&robots_box));
    info_box.append(&robots_frame);
    info_frame.set_child(Some(&info_box));
    main_box.append(&info_frame);

    let code_frame = gtk::Frame::new(Some("Robot Code (R1)"));
    let code_scroll = gtk::ScrolledWindow::new();
    code_scroll.set_height_request(200);

    let code_view = gtk::TextView::new();
    code_view.set_editable(false);
    code_view.set_monospace(true);
    code_view.set_hexpand(true);
    code_scroll.set_child(Some(&code_view));
    code_frame.set_child(Some(&code_scroll));
    main_box.append(&code_frame);

    let stack_frame = gtk::Frame::new(Some("Stack"));
    let stack_view = gtk::TextView::new();
    stack_view.set_editable(false);
    stack_view.set_monospace(true);
    stack_view.set_hexpand(true);
    stack_view.set_vexpand(true);

    let stack_scroll = gtk::ScrolledWindow::new();
    stack_scroll.set_child(Some(&stack_view));
    stack_scroll.set_height_request(100);
    stack_frame.set_child(Some(&stack_scroll));
    main_box.append(&stack_frame);

    let status_label = gtk::Label::new(Some("Ready - Click Step or Chronon to debug"));
    main_box.append(&status_label);

    let button_box = gtk::Box::new(gtk::Orientation::Vertical, 5);
    button_box.set_halign(gtk::Align::Center);

    let step_btn = gtk::Button::with_label("Step");
    let chronon_btn = gtk::Button::with_label("Chronon");
    let stop_btn = gtk::Button::with_label("Stop Debugging");
    let terminate_btn = gtk::Button::with_label("Terminate");

    button_box.append(&step_btn);
    button_box.append(&chronon_btn);
    button_box.append(&stop_btn);
    button_box.append(&terminate_btn);
    main_box.append(&button_box);

    window.set_child(Some(&main_box));

    let status_label_clone = status_label.clone();
    let state_clone = state.clone();
    step_btn.connect_clicked(move |_| {
        *state_clone.action.borrow_mut() = DebugAction::Step;
        status_label_clone.set_text("Stepping one instruction...");
    });

    let status_label2 = status_label.clone();
    let state_clone2 = state.clone();
    chronon_btn.connect_clicked(move |_| {
        *state_clone2.action.borrow_mut() = DebugAction::Chronon;
        status_label2.set_text("Stepping one chronon...");
    });

    let window_clone = window.clone();
    let status_label3 = status_label.clone();
    let state_clone3 = state.clone();
    stop_btn.connect_clicked(move |_| {
        *state_clone3.action.borrow_mut() = DebugAction::Stop;
        status_label3.set_text("Stopping debug session...");
        window_clone.close();
    });

    let window_clone2 = window.clone();
    let status_label4 = status_label.clone();
    let state_clone4 = state.clone();
    terminate_btn.connect_clicked(move |_| {
        *state_clone4.action.borrow_mut() = DebugAction::Terminate;
        status_label4.set_text("Terminating debug session...");
        window_clone2.close();
    });

    window
}

pub fn get_debugger_state() -> DebuggerState {
    DebuggerState::new()
}
