/* MODULES */
mod engine;

use raylib::prelude::*;

fn main() {
    // Initialize the window
    let (mut rl, thread) = raylib::init()
        .size(800, 600)
        .title("Deltarune Battle Engine")
        .vsync()
        .build();

    let texture = rl.load_texture(&thread, "assets/sprites/kris.png").unwrap();
    let position = Vector2::new(350.0, 280.0);
    let mut frame_rec = Rectangle::new(
        0.0,
        0.0,
        132.0,
        132.0,
    );

    let mut frame_counter = 0;
    let mut frame_index = 0;
    let frames_speed = 8;

    // Main game loop
    while !rl.window_should_close() {
        /*** LOGIC ***/
        frame_counter += 1;
        if frame_counter >= 60 / frames_speed {
            frame_counter = 0;
            frame_index += 1;

            if frame_index > 7 {
                frame_rec.x = 0.0;
                frame_index = 0;
            }
            else {
                frame_rec.x += 132.0;
            }
        }


        /*** DRAWING ***/
        let mut d = rl.begin_drawing(&thread);
        d.clear_background(Color::BLACK);

        d.draw_texture_rec(&texture, frame_rec, position, Color::WHITE);
    }
}
