use gtk::prelude::*;
use gtk4 as gtk;

pub fn create_history_window(app: &gtk::Application) -> gtk::Window {
    let window = gtk::Window::new();
    window.set_title(Some("Battle History"));
    window.set_default_size(600, 500);

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 10);
    main_box.set_margin_start(20);
    main_box.set_margin_end(20);
    main_box.set_margin_top(20);
    main_box.set_margin_bottom(20);

    let title = gtk::Label::new(Some(
        "<span size='large' weight='bold'>Battle History</span>",
    ));
    title.set_use_markup(true);
    main_box.append(&title);

    let toolbar = gtk::Box::new(gtk::Orientation::Horizontal, 10);

    let clear_btn = gtk::Button::with_label("Clear History");
    let export_btn = gtk::Button::with_label("Export");
    let import_btn = gtk::Button::with_label("Import");

    toolbar.append(&clear_btn);
    toolbar.append(&export_btn);
    toolbar.append(&import_btn);
    main_box.append(&toolbar);

    let history_view = gtk::TextView::new();
    history_view.set_editable(false);
    history_view.set_monospace(true);
    history_view.set_hexpand(true);
    history_view.set_vexpand(true);
    let buffer = history_view.buffer();
    buffer.set_text("Battle history is empty.\n\nPrevious battle results will appear here.");

    let history_scroll = gtk::ScrolledWindow::new();
    history_scroll.set_child(Some(&history_view));
    main_box.append(&history_scroll);

    let stats_label = gtk::Label::new(Some("Total Battles: 0 | Wins: 0 | Losses: 0"));
    main_box.append(&stats_label);

    let button_box = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    button_box.set_halign(gtk::Align::Center);

    let close_btn = gtk::Button::with_label("Close");
    button_box.append(&close_btn);
    main_box.append(&button_box);

    window.set_child(Some(&main_box));

    let window_clone = window.clone();
    close_btn.connect_clicked(move |_| {
        window_clone.close();
    });

    window
}
