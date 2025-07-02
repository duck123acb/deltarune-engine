use raylib::prelude::*;
use crate::animation::Animation;

pub struct Sprite {
    position: Vector2,
    texture: Texture2D,
    frame_rec: Rectangle
}

impl Sprite {
    pub fn new(x: f32, y: f32, texture_path: &str, frame_rec: Rectangle, rl: &RaylibHandle, thread: &RaylibThread) -> Self {
        Self {
            position: Vector2::new(x, y),
            texture: rl.load_texture(thread, texture_path).unwrap(),
            frame_rec,
        }
    }

    pub fn draw(animation: Animation) {
        /*** LOGIC ***/
        frame_counter += 1;
        if frame_counter >= 60 / frames_speed {
            frame_counter = 0;
            frame_index += 1;

            if frame_index > anim_frames {
                frame_rec.x = 0.0;
                frame_index = 0;
            }
            else {
                frame_rec.x += box_width;
            }
        }
    }
}

