use gtk::prelude::*;
use gtk4 as gtk;

pub fn create_file_open_dialog(app: &gtk::Application, file_type: &str) -> gtk::Window {
    let window = gtk::Window::new();

    match file_type {
        "robot" => window.set_title(Some("Open Robot")),
        "tournament" => window.set_title(Some("Open Tournament")),
        _ => window.set_title(Some("Open File")),
    }

    window.set_default_size(500, 400);

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 10);
    main_box.set_margin_start(20);
    main_box.set_margin_end(20);
    main_box.set_margin_top(20);
    main_box.set_margin_bottom(20);

    let title = gtk::Label::new(Some(match file_type {
        "robot" => "<span size='large' weight='bold'>Open Robot File</span>",
        "tournament" => "<span size='large' weight='bold'>Open Tournament</span>",
        _ => "<span size='large' weight='bold'>Open File</span>",
    }));
    title.set_use_markup(true);
    main_box.append(&title);

    let dir_label = gtk::Label::new(Some("Directory:"));
    main_box.append(&dir_label);

    let dir_combo = gtk::ComboBoxText::new();
    dir_combo.append_text("resources/robots");
    dir_combo.append_text("resources/configs");
    dir_combo.set_active(Some(0));
    main_box.append(&dir_combo);

    let files_list = gtk::ListBox::new();
    files_list.set_hexpand(true);
    files_list.set_vexpand(true);

    let files_scroll = gtk::ScrolledWindow::new();
    files_scroll.set_child(Some(&files_list));
    files_scroll.set_height_request(200);
    main_box.append(&files_scroll);

    let button_box = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    button_box.set_halign(gtk::Align::Center);

    let open_btn = gtk::Button::with_label("Open");
    let cancel_btn = gtk::Button::with_label("Cancel");

    button_box.append(&open_btn);
    button_box.append(&cancel_btn);
    main_box.append(&button_box);

    window.set_child(Some(&main_box));

    let window_clone = window.clone();
    cancel_btn.connect_clicked(move |_| {
        window_clone.close();
    });

    window
}

pub fn create_save_dialog(app: &gtk::Application, file_type: &str) -> gtk::Window {
    let window = gtk::Window::new();

    match file_type {
        "robot" => window.set_title(Some("Save Robot As")),
        _ => window.set_title(Some("Save File As")),
    }

    window.set_default_size(500, 400);

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 10);
    main_box.set_margin_start(20);
    main_box.set_margin_end(20);
    main_box.set_margin_top(20);
    main_box.set_margin_bottom(20);

    let title = gtk::Label::new(Some(match file_type {
        "robot" => "<span size='large' weight='bold'>Save Robot As</span>",
        _ => "<span size='large' weight='bold'>Save File As</span>",
    }));
    title.set_use_markup(true);
    main_box.append(&title);

    let name_label = gtk::Label::new(Some("File Name:"));
    main_box.append(&name_label);

    let name_entry = gtk::Entry::new();
    name_entry.set_placeholder_text(Some("Enter file name"));
    main_box.append(&name_entry);

    let location_label = gtk::Label::new(Some("Location:"));
    main_box.append(&location_label);

    let location_combo = gtk::ComboBoxText::new();
    location_combo.append_text("resources/robots");
    location_combo.set_active(Some(0));
    main_box.append(&location_combo);

    let button_box = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    button_box.set_halign(gtk::Align::Center);

    let save_btn = gtk::Button::with_label("Save");
    let cancel_btn = gtk::Button::with_label("Cancel");

    button_box.append(&save_btn);
    button_box.append(&cancel_btn);
    main_box.append(&button_box);

    window.set_child(Some(&main_box));

    let window_clone = window.clone();
    cancel_btn.connect_clicked(move |_| {
        window_clone.close();
    });

    window
}
