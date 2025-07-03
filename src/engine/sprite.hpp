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
	float boxLength;
	
	Sprite(float x, float y, const char* texturePath, float boxLength, int row, int collumn);
	void Animate(Animation& animation);
	void Draw();
};
