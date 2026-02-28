use std::cell::RefCell;
use std::rc::Rc;

use gtk::prelude::*;
use gtk4 as gtk;

#[derive(Clone, Copy, PartialEq)]
pub enum TutorialPage {
    Introduction,
    CreatingRobot,
    Labels,
    IfIfgStatements,
    MathOperations,
    FireMissile,
    SpeedxSpeedy,
    Conclusion,
}

pub struct Tutorial {
    pub current_page: TutorialPage,
}

impl Tutorial {
    pub fn new() -> Self {
        Self {
            current_page: TutorialPage::Introduction,
        }
    }

    pub fn get_title(&self) -> &'static str {
        match self.current_page {
            TutorialPage::Introduction => "RoboWar Tutorial - Introduction",
            TutorialPage::CreatingRobot => "Creating A Robot",
            TutorialPage::Labels => "Labels",
            TutorialPage::IfIfgStatements => "IF & IFG Statements, Return, & Jump",
            TutorialPage::MathOperations => "Math Operations (+ - / *)",
            TutorialPage::FireMissile => "Fire & Missile",
            TutorialPage::SpeedxSpeedy => "Speedx & Speedy",
            TutorialPage::Conclusion => "Tutorial Complete",
        }
    }

    pub fn get_content(&self) -> String {
        match self.current_page {
            TutorialPage::Introduction => {
                r#"Welcome to the RoboWar tutorial! This guide will teach you how to program battle robots.

Topics covered:
• Creating a robot
• Labels
• IF & IFG statements
• Math operations
• Fire & Missile commands
• Speedx & Speedy

Click "Next" to begin learning how to create your first robot."#.to_string()
            }
            TutorialPage::CreatingRobot => {
                r#"Creating A Robot

To create a robot:
1. Open RoboWar
2. Select File > New
3. Type in a name for your robot
4. Select the directory you wish to save the robot in
5. Click Save

You now have a robot ready for programming. To program your robot, open the Drafting Board (located under VIEW). The typing area is the heart of your robot.

Remember to compile your robot after making changes, or it won't notice them. Compile is found under VIEW."#.to_string()
            }
            TutorialPage::Labels => {
                r#"Labels

Labels are essential for programming robots. They define points to jump to in your program.

To define a label: follow it with a colon (:)
  GoingUp:
  ISeeRobot:
  SoloMode:

To jump to a label: omit the colon
  GoingUp jump

Bad label names (RoboWar reserves these):
  Fire:
  Jump:

Tips:
• You can't use the same label name twice
• You can jump to a label as many times as you want
• Labels can't be over 20 characters
• Use descriptive names to help remember purpose"#.to_string()
            }
            TutorialPage::IfIfgStatements => {
                r#"IF & IFG Statements, Return, & Jump

IF and IFG statements check conditions. Format:
  Number1 Number2 Operator Label IF or IFG

Operators:
  >  Greater than
  <  Less than
  =  Equal
  !  Not equal

Examples:
  5 3 > YesItIs If
  x y = LetsKillEm Ifg
  range radar ! DieDieDie If

IF vs IFG:
• IF: Leaves a return address - use "Return" to come back
• IFG: No return address - use "Jump" to continue

Example (IF):
  Main:
    5 3 > YesItIs If
    Main jump

  YesItIs:
    # 5 is apparently over 3
    return

Example (IFG):
  Main:
    5 3 > YesItIs Ifg
    Main jump

  YesItIs:
    # 5 is apparently over 3
    Main jump

The # symbol adds comments/remarks."#.to_string()
            }
            TutorialPage::MathOperations => {
                r#"Math Operations (+ - / *)

RoboWar uses Reverse Polish Notation (RPN):
  Standard: 1 + 3
  RoboWar:  1 3 +

Examples:
  1 3 +      # Result: 4
  4 2 -      # Result: 2
  100 10 /   # Result: 10
  6 6 *      # Result: 36

You can use variables in math operations:
  aim 5 + aim' sto    # Add 5 to aim and store result
  energy 2 - energy' sto  # Subtract 2 from energy

The 'sto' command stores the result back into a variable."#.to_string()
            }
            TutorialPage::FireMissile => {
                r#"Fire & Missile

Fire and Missile are used to shoot other robots.

Format:
  variable fire' sto
  variable missile' sto

Examples:
  1 fire' sto          # Fire with 1 energy
  15 missile' sto      # Fire missile with 15 energy
  energy bullet' sto  # Fire with all current energy

Bullet Types (set in Hardware Store):
  • Explosive: 2x damage multiplier
  • Normal: 1x damage (equal to energy used)
  • Rubber: 0.5x damage (half energy used)

Missiles:
  • Always do 2x damage
  • Move at slower speed
  • More expensive but devastating

Note: Use 'bullet' instead of 'fire' with explosive bullets when close to enemies to avoid blast radius damage."#.to_string()
            }
            TutorialPage::SpeedxSpeedy => {
                r#"Speedx & Speedy

Move your robot using speedx (x-axis) and speedy (y-axis).

Format:
  variable speedx' sto
  variable speedy' sto

The arena is 300 x 300 pixels.

Key rules:
  • Speed stays set until changed
  • Maximum speed in any direction: 20
  • Cost: 2 x speed in energy per chronon
    - Setting speed to 4 costs 8 energy
    - Changing from 4 to -4 costs 16 energy

Example - Moving up and down while firing:
  Main:
    range 0 > ShootEm If
    aim 5 + aim' sto
    Main jump

  ShootEm:
    10 fire' sto
    return

Note: Once a speed is set, your robot keeps moving!"#.to_string()
            }
            TutorialPage::Conclusion => {
                r#"Congratulations!

You've completed the RoboWar basics tutorial. Your robot can now:
• Use labels for program flow
• Make decisions with IF/IFG
• Perform math operations
• Fire weapons
• Move around the arena

Practice ideas:
1. Create a robot that fires different power based on energy
2. Try making a fast missile-swarming bot
3. Design a robot that can beat all your previous bots!

Hardware matters: The same code with different hardware settings can perform dramatically differently.

Next steps:
• Learn about advanced robot programming
• Experiment with different weapon types
• Study the example robots included with RoboWar

Good luck, and may your robots battle well!"#.to_string()
            }
        }
    }

    pub fn can_go_next(&self) -> bool {
        self.current_page != TutorialPage::Conclusion
    }

    pub fn can_go_prev(&self) -> bool {
        self.current_page != TutorialPage::Introduction
    }

    pub fn next(&mut self) {
        if self.can_go_next() {
            self.current_page = match self.current_page {
                TutorialPage::Introduction => TutorialPage::CreatingRobot,
                TutorialPage::CreatingRobot => TutorialPage::Labels,
                TutorialPage::Labels => TutorialPage::IfIfgStatements,
                TutorialPage::IfIfgStatements => TutorialPage::MathOperations,
                TutorialPage::MathOperations => TutorialPage::FireMissile,
                TutorialPage::FireMissile => TutorialPage::SpeedxSpeedy,
                TutorialPage::SpeedxSpeedy => TutorialPage::Conclusion,
                TutorialPage::Conclusion => TutorialPage::Conclusion,
            };
        }
    }

    pub fn prev(&mut self) {
        if self.can_go_prev() {
            self.current_page = match self.current_page {
                TutorialPage::Introduction => TutorialPage::Introduction,
                TutorialPage::CreatingRobot => TutorialPage::Introduction,
                TutorialPage::Labels => TutorialPage::CreatingRobot,
                TutorialPage::IfIfgStatements => TutorialPage::Labels,
                TutorialPage::MathOperations => TutorialPage::IfIfgStatements,
                TutorialPage::FireMissile => TutorialPage::MathOperations,
                TutorialPage::SpeedxSpeedy => TutorialPage::FireMissile,
                TutorialPage::Conclusion => TutorialPage::SpeedxSpeedy,
            };
        }
    }
}

pub fn create_tutorial_window(_app: &gtk::Application) -> gtk::Window {
    let window = gtk::Window::new();
    window.set_title(Some("RoboWar Tutorial"));
    window.set_default_size(600, 500);

    let tutorial = Rc::new(RefCell::new(Tutorial::new()));

    let vbox = gtk::Box::new(gtk::Orientation::Vertical, 10);
    vbox.set_margin_start(20);
    vbox.set_margin_end(20);
    vbox.set_margin_top(20);
    vbox.set_margin_bottom(20);

    let title_label = gtk::Label::new(None);
    title_label.set_use_markup(true);
    title_label.set_halign(gtk::Align::Center);

    let content_label = gtk::Label::new(None);
    content_label.set_use_markup(true);
    content_label.set_halign(gtk::Align::Start);
    content_label.set_valign(gtk::Align::Start);
    content_label.set_wrap(true);
    content_label.set_selectable(true);

    let nav_box = gtk::Box::new(gtk::Orientation::Horizontal, 10);
    nav_box.set_halign(gtk::Align::Center);

    let prev_btn = gtk::Button::with_label("Previous");
    let next_btn = gtk::Button::with_label("Next");
    let close_btn = gtk::Button::with_label("Close");

    let page_indicator = gtk::Label::new(None);

    nav_box.append(&prev_btn);
    nav_box.append(&page_indicator);
    nav_box.append(&next_btn);
    nav_box.append(&close_btn);

    vbox.append(&title_label);
    vbox.append(&content_label);
    vbox.append(&nav_box);

    window.set_child(Some(&vbox));

    let tutorial_clone = tutorial.clone();
    let title_label_clone = title_label.clone();
    let content_label_clone = content_label.clone();
    let page_indicator_clone = page_indicator.clone();
    let next_btn_clone = next_btn.clone();
    let prev_btn_clone = prev_btn.clone();

    let update_view = Rc::new(move || {
        let t = tutorial_clone.borrow();
        title_label_clone.set_markup(&format!(
            "<span size='large' weight='bold'>{}</span>",
            t.get_title()
        ));
        content_label_clone.set_markup(&format!(
            "<span size='medium'>{}</span>",
            t.get_content().replace("\n", "\n")
        ));

        let page_num = match t.current_page {
            TutorialPage::Introduction => 1,
            TutorialPage::CreatingRobot => 2,
            TutorialPage::Labels => 3,
            TutorialPage::IfIfgStatements => 4,
            TutorialPage::MathOperations => 5,
            TutorialPage::FireMissile => 6,
            TutorialPage::SpeedxSpeedy => 7,
            TutorialPage::Conclusion => 8,
        };
        page_indicator_clone.set_text(&format!("Page {}/8", page_num));

        next_btn_clone.set_sensitive(t.can_go_next());
        prev_btn_clone.set_sensitive(t.can_go_prev());
    });

    let tutorial_next = tutorial.clone();
    let update_view_next = update_view.clone();
    next_btn.connect_clicked(move |_| {
        tutorial_next.borrow_mut().next();
        update_view_next();
    });

    let tutorial_prev = tutorial.clone();
    let update_view_prev = update_view.clone();
    prev_btn.connect_clicked(move |_| {
        tutorial_prev.borrow_mut().prev();
        update_view_prev();
    });

    let window_clone = window.clone();
    close_btn.connect_clicked(move |_| {
        window_clone.close();
    });

    update_view();

    window
}
