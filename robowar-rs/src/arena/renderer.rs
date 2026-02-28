const ARENA_SIZE: f64 = 300.0;
const ROBOT_SIZE: f64 = 20.0;
const SHOT_SIZE: f64 = 6.0;

const COLOR_ARENA_BG: (f64, f64, f64) = (0.02, 0.15, 0.08);
const COLOR_GRID: (f64, f64, f64) = (0.05, 0.25, 0.12);
const COLOR_WALL: (f64, f64, f64) = (0.4, 0.2, 0.1);
const COLOR_ROBOT: [(f64, f64, f64); 6] = [
    (1.0, 0.3, 0.3),
    (0.3, 0.6, 1.0),
    (0.3, 1.0, 0.3),
    (1.0, 1.0, 0.3),
    (1.0, 0.3, 1.0),
    (0.3, 1.0, 1.0),
];
const COLOR_SHOT: (f64, f64, f64) = (1.0, 0.8, 0.2);

pub struct Renderer {
    pub width: u32,
    pub height: u32,
    pub scale: f64,
}

impl Renderer {
    pub fn new(width: u32, height: u32) -> Self {
        let scale = (width.min(height) as f64) / ARENA_SIZE;
        Self {
            width,
            height,
            scale,
        }
    }

    pub fn resize(&mut self, width: u32, height: u32) {
        self.width = width;
        self.height = height;
        self.scale = (width.min(height) as f64) / ARENA_SIZE;
    }
}

impl Default for Renderer {
    fn default() -> Self {
        Self::new(400, 400)
    }
}
