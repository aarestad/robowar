use gtk::prelude::*;
use gtk4 as gtk;

pub fn create_about_window() -> gtk::Window {
    let window = gtk::Window::new();
    window.set_title(Some("About RoboWar 5"));
    window.set_default_size(400, 450);

    let main_box = gtk::Box::new(gtk::Orientation::Vertical, 20);
    main_box.set_margin_start(30);
    main_box.set_margin_end(30);
    main_box.set_margin_top(30);
    main_box.set_margin_bottom(30);

    let title = gtk::Label::new(Some("<span size='xx-large' weight='bold'>RoboWar 5</span>"));
    title.set_use_markup(true);
    title.set_halign(gtk::Align::Center);
    main_box.append(&title);

    let version = gtk::Label::new(Some("Version 5.4.0"));
    version.set_halign(gtk::Align::Center);
    main_box.append(&version);

    let separator = gtk::Separator::new(gtk::Orientation::Horizontal);
    main_box.append(&separator);

    let description = gtk::Label::new(Some(
        "A robot battle simulation game where you program\n\
        your own robots to battle against others.\n\n\
        Original concept by Kevin Hertzberg\n\
        Rebuilt by the RoboWar Community",
    ));
    description.set_halign(gtk::Align::Center);
    description.set_justify(gtk::Justification::Center);
    main_box.append(&description);

    let credits_title = gtk::Label::new(Some("<b>Credits</b>"));
    credits_title.set_use_markup(true);
    credits_title.set_halign(gtk::Align::Start);
    main_box.append(&credits_title);

    let credits = gtk::Label::new(Some(
        "Programming: Austin Barton\n\
        Additional Programming: Silas Warner\n\
        Music & Sound Effects: Various\n\
        Beta Testers: Community Members",
    ));
    credits.set_halign(gtk::Align::Start);
    main_box.append(&credits);

    let separator2 = gtk::Separator::new(gtk::Orientation::Horizontal);
    main_box.append(&separator2);

    let license = gtk::Label::new(Some("License: GPL-3.0"));
    license.set_halign(gtk::Align::Center);
    main_box.append(&license);

    let website = gtk::Label::new(Some("https://github.com/robowar/robowar"));
    website.set_halign(gtk::Align::Center);
    main_box.append(&website);

    let close_btn = gtk::Button::with_label("Close");
    close_btn.set_halign(gtk::Align::Center);
    close_btn.set_margin_top(20);
    main_box.append(&close_btn);

    window.set_child(Some(&main_box));

    let window_clone = window.clone();
    close_btn.connect_clicked(move |_| {
        window_clone.close();
    });

    window
}
