#include "raylib.h"

#include "engine/sprite.hpp"

int main() {
	InitWindow(640, 480, "Deltarune Engine");
	SetWindowState(FLAG_VSYNC_HINT);
	SetTargetFPS(60);

	Texture2D texture = LoadTexture("assets/sprites/kris.png");
	Vector2 position = { 350.0f, 280.0f };
	
	float boxWidth = texture.width / 16.0f;
    	Rectangle frameRec = {
        	0.0f,
        	boxWidth * 4.0f,
        	boxWidth,
        	boxWidth
    	};
	
	int frameCounter = 0;
	int frameIndex = 0;
	int framesSpeed = 18;
	int animFrames = 6;

	while (!WindowShouldClose()) {
		frameCounter++;
        	if (frameCounter >= (60 / framesSpeed)) {
            		frameCounter = 0;
            		frameIndex++;
            		if (frameIndex >= animFrames) frameIndex = 0;
			frameRec.x = frameIndex * boxWidth;
        	}

		BeginDrawing();
		ClearBackground(BLACK);
		DrawTextureRec(texture, frameRec, position, WHITE);
		EndDrawing();
	}

	CloseWindow();
	return 0;
}
