use gtk::prelude::*;
use gtk4 as gtk;

pub fn create_test_tourney_window(app: &gtk::Application) -> gtk::Window {
    let window = gtk::Window::new();
    window.set_title(Some("Test Tournament"));
    window.set_default_size(600, 400);

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 20);
    main_box.set_margin_start(20);
    main_box.set_margin_end(20);
    main_box.set_margin_top(20);
    main_box.set_margin_bottom(20);

    let title = gtk::Label::new(Some(
        "<span size='large' weight='bold'>Test Tournament</span>",
    ));
    title.set_use_markup(true);
    main_box.append(&title);

    let desc = gtk::Label::new(Some(
        "This is a quick test mode where two robots battle\neach other repeatedly to test performance."
    ));
    desc.set_justify(gtk::Justification::Center);
    main_box.append(&desc);

    let grid = gtk::Grid::new();
    grid.set_row_spacing(10);
    grid.set_column_spacing(10);

    let robot1_label = gtk::Label::new(Some("Robot 1:"));
    grid.attach(&robot1_label, 0, 0, 1, 1);
    let robot1_combo = gtk::ComboBoxText::new();
    robot1_combo.append_text("Standard");
    robot1_combo.set_active(Some(0));
    grid.attach(&robot1_combo, 1, 0, 1, 1);

    let robot2_label = gtk::Label::new(Some("Robot 2:"));
    grid.attach(&robot2_label, 0, 1, 1, 1);
    let robot2_combo = gtk::ComboBoxText::new();
    robot2_combo.append_text("Standard");
    robot2_combo.set_active(Some(0));
    grid.attach(&robot2_combo, 1, 1, 1, 1);

    let rounds_label = gtk::Label::new(Some("Number of Battles:"));
    grid.attach(&rounds_label, 0, 2, 1, 1);
    let rounds_spin = gtk::SpinButton::with_range(1.0, 100.0, 1.0);
    rounds_spin.set_value(10.0);
    grid.attach(&rounds_spin, 1, 2, 1, 1);

    main_box.append(&grid);

    let results_view = gtk::TextView::new();
    results_view.set_editable(false);
    results_view.set_monospace(true);
    results_view.set_hexpand(true);
    results_view.set_vexpand(true);

    let results_scroll = gtk::ScrolledWindow::new();
    results_scroll.set_child(Some(&results_view));
    results_scroll.set_height_request(150);
    main_box.append(&results_scroll);

    let status_label = gtk::Label::new(Some("Ready"));
    main_box.append(&status_label);

    let button_box = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    button_box.set_halign(gtk::Align::Center);

    let run_btn = gtk::Button::with_label("Run Test");
    let close_btn = gtk::Button::with_label("Close");

    button_box.append(&run_btn);
    button_box.append(&close_btn);
    main_box.append(&button_box);

    window.set_child(Some(&main_box));

    let window_clone = window.clone();
    close_btn.connect_clicked(move |_| {
        window_clone.close();
    });

    window
}
