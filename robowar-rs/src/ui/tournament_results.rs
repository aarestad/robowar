use gtk::prelude::*;
use gtk4 as gtk;

pub fn create_tournament_results_window(app: &gtk::Application) -> gtk::Window {
    let window = gtk::Window::new();
    window.set_title(Some("Tournament Results"));
    window.set_default_size(500, 400);

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 10);
    main_box.set_margin_start(20);
    main_box.set_margin_end(20);
    main_box.set_margin_top(20);
    main_box.set_margin_bottom(20);

    let title = gtk::Label::new(Some(
        "<span size='large' weight='bold'>Tournament Results</span>",
    ));
    title.set_use_markup(true);
    main_box.append(&title);

    let results_view = gtk::TextView::new();
    results_view.set_editable(false);
    results_view.set_monospace(true);
    results_view.set_hexpand(true);
    results_view.set_vexpand(true);
    let buffer = results_view.buffer();
    buffer.set_text("No tournament results yet.\nRun a tournament to see results here.");

    let results_scroll = gtk::ScrolledWindow::new();
    results_scroll.set_child(Some(&results_view));
    main_box.append(&results_scroll);

    let button_box = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    button_box.set_halign(gtk::Align::Center);

    let save_btn = gtk::Button::with_label("Save to File");
    let close_btn = gtk::Button::with_label("Close");

    button_box.append(&save_btn);
    button_box.append(&close_btn);
    main_box.append(&button_box);

    window.set_child(Some(&main_box));

    let window_clone = window.clone();
    close_btn.connect_clicked(move |_| {
        window_clone.close();
    });

    window
}
