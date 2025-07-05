#include "raylib.h"

#include "engine/sprite.hpp"

int main() {
	InitWindow(640, 480, "Deltarune Engine");
	SetWindowState(FLAG_VSYNC_HINT);
	SetTargetFPS(60);

	InitAudioDevice();

	Sound egg;
	Music rude_buster = LoadMusicStream("assets/audio/songs/rude_buster.mp3");
	PlayMusicStream(rude_buster);

	Sprite kris(200, 200, "assets/sprites/kris.png", 128, 0, 4);
	Animation slash(12, 6);

	while (!WindowShouldClose()) {
		UpdateMusicStream(rude_buster);

		kris.Animate(slash);

		BeginDrawing();
		ClearBackground(BLACK);

		kris.Draw();
		
		EndDrawing();
	}

	CloseWindow();
	return 0;
}
