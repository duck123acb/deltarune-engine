#pragma once

#include "raylib.h"

struct Animation {
	int frameCounter;
        int frameIndex;
        int speed;
        int frames;

	Animation(int speed, int frames);
};

struct Sprite {
	Vector2 position;
	Texture2D texture;
	Rectangle frameRec;
	
	Sprite(float x, float y, const char* texturePath, float boxWidth, int row, int collumn);
	void Draw();
	void Animate(Animation animation);
};
