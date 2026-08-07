use gio::Settings;
use gtk::prelude::*;
use gtk::{Align, Application, ApplicationWindow, Switch, gio, glib};

const APP_ID: &str = "org.mikanullvik.jfw";

fn main() -> glib::ExitCode {
    let app = Application::builder().application_id(APP_ID).build();

    app.connect_activate(build_ui);

    app.run()
}

fn build_ui(app: &Application) {
    let settings = Settings::new(APP_ID);

    let is_switch_enabled = settings.boolean("is-switch-enabled");

    let switch = Switch::builder()
        .margin_top(48)
        .margin_bottom(48)
        .margin_start(48)
        .margin_end(48)
        .valign(Align::Center)
        .halign(Align::Center)
        .state(is_switch_enabled)
        .build();

    switch.connect_state_set(move |_, is_enabled| {
        settings
            .set_boolean("is-switch-enabled", is_enabled)
            .expect("Could not set settings.");
        glib::Propagation::Proceed
    });

    let window = ApplicationWindow::builder()
        .application(app)
        .title("Just Fucking Write")
        .child(&switch)
        .build();

    window.present();
}
