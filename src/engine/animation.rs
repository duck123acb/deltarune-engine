pub struct Animation {
    frame_counter: i32,
    frame_index: i32,
    frames_speed: i32,
    anim_frames: i32
}

impl Animation {
    pub fn new(speed: i32, num_frame: i32) -> Self {
    Self {
        frame_counter: 0,
        frame_index: 0,
        frames_speed: speed,
        frames: num_frames,
    }
  }
}
