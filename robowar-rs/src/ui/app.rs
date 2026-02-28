use gtk4 as gtk;

pub fn create_app() -> gtk::Application {
    gtk::Application::new(
        Some("com.robowar.game"),
        gtk::gio::ApplicationFlags::default(),
    )
}
