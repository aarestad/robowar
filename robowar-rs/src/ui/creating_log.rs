use gtk::prelude::*;
use gtk4 as gtk;

pub fn create_creating_log_window(app: &gtk::Application) -> gtk::Window {
    let window = gtk::Window::new();
    window.set_title(Some("Creating Log"));
    window.set_default_size(450, 300);

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 20);
    main_box.set_margin_start(20);
    main_box.set_margin_end(20);
    main_box.set_margin_top(20);
    main_box.set_margin_bottom(20);

    let title = gtk::Label::new(Some("<span size='large' weight='bold'>Creating Log</span>"));
    title.set_use_markup(true);
    main_box.append(&title);

    let desc = gtk::Label::new(Some("Generating tournament battle log..."));
    main_box.append(&desc);

    let progress_bar = gtk::ProgressBar::new();
    progress_bar.set_hexpand(true);
    main_box.append(&progress_bar);

    let status_label = gtk::Label::new(Some("Preparing..."));
    main_box.append(&status_label);

    let log_view = gtk::TextView::new();
    log_view.set_editable(false);
    log_view.set_monospace(true);
    log_view.set_hexpand(true);
    log_view.set_vexpand(true);
    let buffer = log_view.buffer();
    buffer.set_text("Log output will appear here...");

    let log_scroll = gtk::ScrolledWindow::new();
    log_scroll.set_child(Some(&log_view));
    log_scroll.set_height_request(120);
    main_box.append(&log_scroll);

    let button_box = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    button_box.set_halign(gtk::Align::Center);

    let cancel_btn = gtk::Button::with_label("Cancel");
    button_box.append(&cancel_btn);
    main_box.append(&button_box);

    window.set_child(Some(&main_box));

    let window_clone = window.clone();
    cancel_btn.connect_clicked(move |_| {
        window_clone.close();
    });

    window
}
