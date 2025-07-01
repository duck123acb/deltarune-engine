use raylib::prelude::*;

fn main() {
    // Initialize the window
    let (mut rl, thread) = raylib::init()
        .size(800, 600)
        .title("Deltarune Battle Engine")
        .vsync()
        .build();

    // Main game loop
    while !rl.window_should_close() {
        let mut d = rl.begin_drawing(&thread);
        d.clear_background(Color::BLACK);

        d.draw_text("BATTLE START!", 280, 280, 30, Color::WHITE);
    }
}
