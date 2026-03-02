use std::cell::RefCell;
use std::rc::Rc;

use gtk::prelude::*;
use gtk4 as gtk;

use crate::arena::robot::{Robot, RobotHardware};

#[derive(Clone)]
pub struct HardwareStore {
    pub robot: Rc<RefCell<Robot>>,
    pub points_used: Rc<RefCell<i32>>,
    pub max_points: i32,
}

impl HardwareStore {
    pub fn new(robot: Robot, max_points: i32) -> Self {
        let points = Self::calculate_points(&robot.hardware);
        Self {
            robot: Rc::new(RefCell::new(robot)),
            points_used: Rc::new(RefCell::new(points)),
            max_points,
        }
    }

    fn calculate_points(hw: &RobotHardware) -> i32 {
        let mut points = 0;
        points += (hw.energy as i32 - 100) / 5;
        points += hw.damage as i32 / 2;
        points += hw.shield as i32 / 2;
        points += hw.processor as i32 * 5;
        points += hw.nne as i32 * 5;
        points += hw.turret as i32 * 3;
        points += hw.bullets as i32;
        points += hw.missiles as i32 * 3;
        points += hw.tac_nukes as i32 * 5;
        points += hw.hellbores as i32 * 5;
        points += hw.mines as i32 * 3;
        points += hw.stunners as i32 * 3;
        points += hw.drones as i32 * 5;
        points += hw.lasers as i32 * 3;
        points += hw.probes as i32 * 3;
        points
    }
}

pub fn create_hardware_window(
    _app: &gtk::Application,
    robot: Robot,
    max_points: i32,
) -> gtk::Window {
    let store = HardwareStore::new(robot.clone(), max_points);

    let window = gtk::Window::new();
    window.set_title(Some("Hardware Store"));
    window.set_default_size(500, 600);
    window.set_transient_for(Some(&window));

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 10);
    main_box.set_margin_start(20);
    main_box.set_margin_end(20);
    main_box.set_margin_top(20);
    main_box.set_margin_bottom(20);

    let title = gtk::Label::new(Some(
        "<span size='large' weight='bold'>Hardware Store</span>",
    ));
    title.set_use_markup(true);
    main_box.append(&title);

    let robot_name_label = gtk::Label::new(Some(&format!("Robot: {}", robot.name)));
    main_box.append(&robot_name_label);

    let points_label = gtk::Label::new(Some(&format!(
        "Points Used: {} / {}",
        store.points_used.borrow().clone(),
        max_points
    )));
    main_box.append(&points_label);

    let grid = gtk::Grid::new();
    grid.set_row_spacing(10);
    grid.set_column_spacing(10);

    let mut row = 0;

    let energy_label = gtk::Label::new(Some("Energy:"));
    grid.attach(&energy_label, 0, row, 1, 1);
    let energy_spin = gtk::SpinButton::with_range(50.0, 500.0, 5.0);
    energy_spin.set_value(robot.hardware.energy as f64);
    grid.attach(&energy_spin, 1, row, 1, 1);
    let energy_val_label = gtk::Label::new(Some(&format!("{}", robot.hardware.energy)));
    grid.attach(&energy_val_label, 2, row, 1, 1);
    row += 1;

    let damage_label = gtk::Label::new(Some("Damage:"));
    grid.attach(&damage_label, 0, row, 1, 1);
    let damage_spin = gtk::SpinButton::with_range(0.0, 100.0, 5.0);
    damage_spin.set_value(robot.hardware.damage as f64);
    grid.attach(&damage_spin, 1, row, 1, 1);
    row += 1;

    let shield_label = gtk::Label::new(Some("Shield:"));
    grid.attach(&shield_label, 0, row, 1, 1);
    let shield_spin = gtk::SpinButton::with_range(0.0, 100.0, 5.0);
    shield_spin.set_value(robot.hardware.shield as f64);
    grid.attach(&shield_spin, 1, row, 1, 1);
    row += 1;

    let processor_label = gtk::Label::new(Some("Processor (speed):"));
    grid.attach(&processor_label, 0, row, 1, 1);
    let processor_spin = gtk::SpinButton::with_range(1.0, 10.0, 1.0);
    processor_spin.set_value(robot.hardware.processor as f64);
    grid.attach(&processor_spin, 1, row, 1, 1);
    row += 1;

    let nne_label = gtk::Label::new(Some("NNE (memory):"));
    grid.attach(&nne_label, 0, row, 1, 1);
    let nne_spin = gtk::SpinButton::with_range(1.0, 10.0, 1.0);
    nne_spin.set_value(robot.hardware.nne as f64);
    grid.attach(&nne_spin, 1, row, 1, 1);
    row += 1;

    let turret_label = gtk::Label::new(Some("Turret (turn speed):"));
    grid.attach(&turret_label, 0, row, 1, 1);
    let turret_spin = gtk::SpinButton::with_range(0.0, 10.0, 1.0);
    turret_spin.set_value(robot.hardware.turret as f64);
    grid.attach(&turret_spin, 1, row, 1, 1);
    row += 1;

    let bullets_label = gtk::Label::new(Some("Bullets:"));
    grid.attach(&bullets_label, 0, row, 1, 1);
    let bullets_spin = gtk::SpinButton::with_range(0.0, 50.0, 1.0);
    bullets_spin.set_value(robot.hardware.bullets as f64);
    grid.attach(&bullets_spin, 1, row, 1, 1);
    row += 1;

    let missiles_label = gtk::Label::new(Some("Missiles:"));
    grid.attach(&missiles_label, 0, row, 1, 1);
    let missiles_spin = gtk::SpinButton::with_range(0.0, 20.0, 1.0);
    missiles_spin.set_value(robot.hardware.missiles as f64);
    grid.attach(&missiles_spin, 1, row, 1, 1);
    row += 1;

    let drones_label = gtk::Label::new(Some("Drones:"));
    grid.attach(&drones_label, 0, row, 1, 1);
    let drones_spin = gtk::SpinButton::with_range(0.0, 10.0, 1.0);
    drones_spin.set_value(robot.hardware.drones as f64);
    grid.attach(&drones_spin, 1, row, 1, 1);
    row += 1;

    let lasers_label = gtk::Label::new(Some("Lasers:"));
    grid.attach(&lasers_label, 0, row, 1, 1);
    let lasers_spin = gtk::SpinButton::with_range(0.0, 10.0, 1.0);
    lasers_spin.set_value(robot.hardware.lasers as f64);
    grid.attach(&lasers_spin, 1, row, 1, 1);
    row += 1;

    let mines_label = gtk::Label::new(Some("Mines:"));
    grid.attach(&mines_label, 0, row, 1, 1);
    let mines_spin = gtk::SpinButton::with_range(0.0, 10.0, 1.0);
    mines_spin.set_value(robot.hardware.mines as f64);
    grid.attach(&mines_spin, 1, row, 1, 1);
    row += 1;

    let hellbores_label = gtk::Label::new(Some("Hellbores:"));
    grid.attach(&hellbores_label, 0, row, 1, 1);
    let hellbores_spin = gtk::SpinButton::with_range(0.0, 5.0, 1.0);
    hellbores_spin.set_value(robot.hardware.hellbores as f64);
    grid.attach(&hellbores_spin, 1, row, 1, 1);
    row += 1;

    let tac_nukes_label = gtk::Label::new(Some("Tac Nukes:"));
    grid.attach(&tac_nukes_label, 0, row, 1, 1);
    let tac_nukes_spin = gtk::SpinButton::with_range(0.0, 5.0, 1.0);
    tac_nukes_spin.set_value(robot.hardware.tac_nukes as f64);
    grid.attach(&tac_nukes_spin, 1, row, 1, 1);
    row += 1;

    let stunners_label = gtk::Label::new(Some("Stunners:"));
    grid.attach(&stunners_label, 0, row, 1, 1);
    let stunners_spin = gtk::SpinButton::with_range(0.0, 10.0, 1.0);
    stunners_spin.set_value(robot.hardware.stunners as f64);
    grid.attach(&stunners_spin, 1, row, 1, 1);
    row += 1;

    let probes_label = gtk::Label::new(Some("Probes:"));
    grid.attach(&probes_label, 0, row, 1, 1);
    let probes_spin = gtk::SpinButton::with_range(0.0, 10.0, 1.0);
    probes_spin.set_value(robot.hardware.probes as f64);
    grid.attach(&probes_spin, 1, row, 1, 1);

    main_box.append(&grid);

    let button_box = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    button_box.set_halign(gtk::Align::Center);

    let ok_btn = gtk::Button::with_label("OK");
    let cancel_btn = gtk::Button::with_label("Cancel");

    button_box.append(&ok_btn);
    button_box.append(&cancel_btn);
    main_box.append(&button_box);

    window.set_child(Some(&main_box));

    let window_clone = window.clone();
    let robot_clone = store.robot.clone();
    ok_btn.connect_clicked(move |_| {
        let mut r = robot_clone.borrow_mut();
        r.hardware.energy = energy_spin.value() as i16;
        r.hardware.damage = damage_spin.value() as i16;
        r.hardware.shield = shield_spin.value() as i16;
        r.hardware.processor = processor_spin.value() as u8;
        r.hardware.nne = nne_spin.value() as u8;
        r.hardware.turret = turret_spin.value() as u8;
        r.hardware.bullets = bullets_spin.value() as u8;
        r.hardware.missiles = missiles_spin.value() as u8;
        r.hardware.drones = drones_spin.value() as u8;
        r.hardware.lasers = lasers_spin.value() as u8;
        r.hardware.mines = mines_spin.value() as u8;
        r.hardware.hellbores = hellbores_spin.value() as u8;
        r.hardware.tac_nukes = tac_nukes_spin.value() as u8;
        r.hardware.stunners = stunners_spin.value() as u8;
        r.hardware.probes = probes_spin.value() as u8;
        window_clone.close();
    });

    let window_clone2 = window.clone();
    cancel_btn.connect_clicked(move |_| {
        window_clone2.close();
    });

    window
}
