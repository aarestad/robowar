use std::cell::RefCell;
use std::rc::Rc;

use gtk::prelude::*;
use gtk4 as gtk;

pub fn create_choose_icon_window(app: &gtk::Application) -> gtk::Window {
    let window = gtk::Window::new();
    window.set_title(Some("Choose Icon"));
    window.set_default_size(400, 350);

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 10);
    main_box.set_margin_start(20);
    main_box.set_margin_end(20);
    main_box.set_margin_top(20);
    main_box.set_margin_bottom(20);

    let title = gtk::Label::new(Some(
        "<span size='large' weight='bold'>Choose Robot Icon</span>",
    ));
    title.set_use_markup(true);
    main_box.append(&title);

    let desc = gtk::Label::new(Some("Select an icon for your robot:"));
    main_box.append(&desc);

    let icon_grid = gtk::Grid::new();
    icon_grid.set_row_spacing(5);
    icon_grid.set_column_spacing(5);

    let icons = ["1", "2", "3", "4", "5", "6"];

    let mut selected_icon = Rc::new(RefCell::new(0));
    let mut icon_buttons = Vec::new();

    for (i, icon_num) in icons.iter().enumerate() {
        let btn = gtk::Button::with_label(&format!("Icon {}", icon_num));
        let row = i / 3;
        let col = i % 3;
        icon_grid.attach(&btn, col as i32, row as i32, 1, 1);
        icon_buttons.push(btn);
    }

    main_box.append(&icon_grid);

    let preview_label = gtk::Label::new(Some("<b>Preview</b>"));
    preview_label.set_use_markup(true);
    main_box.append(&preview_label);

    let preview_box = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    preview_box.set_halign(gtk::Align::Center);
    preview_box.set_size_request(100, 100);
    preview_box.set_hexpand(true);

    let preview_frame = gtk::Frame::new(Some(""));
    preview_frame.set_child(Some(&preview_box));
    preview_frame.set_width_request(80);
    preview_frame.set_height_request(80);
    main_box.append(&preview_frame);

    let button_box = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    button_box.set_halign(gtk::Align::Center);

    let ok_btn = gtk::Button::with_label("OK");
    let cancel_btn = gtk::Button::with_label("Cancel");

    button_box.append(&ok_btn);
    button_box.append(&cancel_btn);
    main_box.append(&button_box);

    window.set_child(Some(&main_box));

    let window_clone = window.clone();
    ok_btn.connect_clicked(move |_| {
        window_clone.close();
    });

    let window_clone2 = window.clone();
    cancel_btn.connect_clicked(move |_| {
        window_clone2.close();
    });

    window
}
