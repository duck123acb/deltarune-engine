#include "sprite.hpp"

Animation::Animation(int speed, int frames)
	: frameCounter(0),
	frameIndex(0),
	speed(speed),
	frames(frames)
{}

Sprite(float x, float y, const char* texturePath, float boxLength, int row, int collumn);
    : texture(LoadTexture(texturePath)),
      position({ x, y }),
      frameRec({ row * boxLength, collumn * boxLength, boxLength, boxLength })
{}

Sprite::Animate(Animation animation) {
	animation.frameCounter++;
	if (animation.frameCounter >= (60 / animation.speed)) {
		animation.frameCounter = 0;
		animation.frameIndex++;

		if (animation.frameIndex >= animation.frames)
			frameIndex = 0;
                
		frameRec.x = frameIndex * boxLength;
	}

}
Sprite::Draw() {
	DrawTextureRec(texture, frameRec, position, WHITE);
}
