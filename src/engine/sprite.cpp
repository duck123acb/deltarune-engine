#include "sprite.hpp"
#include <iostream>

Animation::Animation(int speed, int frames)
	: frameCounter(0),
	frameIndex(0),
	speed(speed),
	frames(frames)
{}

Sprite::Sprite(float x, float y, const char* texturePath, float boxLength, int row, int column)
    : texture(LoadTexture(texturePath)),
      position({ x, y }),
      frameRec({ row * boxLength, column * boxLength, boxLength, boxLength }),
      boxLength(boxLength)
{}

void Sprite::Animate(Animation& animation) {
	animation.frameCounter++;

	if (animation.frameCounter >= (60 / animation.speed)) {
		animation.frameCounter = 0;
		animation.frameIndex++;

		if (animation.frameIndex >= animation.frames)
			animation.frameIndex = 0;
                
		frameRec.x = animation.frameIndex * boxLength;
	}

}
void Sprite::Draw() {
	DrawTextureRec(texture, frameRec, position, WHITE);
}
