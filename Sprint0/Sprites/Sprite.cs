using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;

namespace sprint0.Sprites
{
    public class Sprite : ISprite
    {
        
        protected Texture2D spriteSheet;
        protected int delay;
        protected int delayCount;
        protected int frame;
        protected int frameCount;
        protected float scale;
        protected List<Rectangle> frameSources;
        protected Vector2 origin;

        public virtual int GetWidth(int animationFrame = -1)
        {
            if (animationFrame != -1) {
                frame = animationFrame;
            }
            return (int) (scale * frameSources[frame % frameCount].Width);
        }

        public virtual int GetHeight(int animationFrame = -1)
        {
            if (animationFrame != -1) {
                frame = animationFrame;
            }
            return (int) (scale * frameSources[frame % frameCount].Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffect)
        {
            spriteBatch.Draw(spriteSheet, position, frameSources[frame % frameCount], Color.White, 0f, origin, scale, spriteEffect, 0f);

            // delay change in frames
            delayCount++;
            if (delayCount % delay == 0) frame++;
        }

        // manual frame change
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, int currentFrame, SpriteEffects spriteEffect)
        {
            spriteBatch.Draw(spriteSheet, position, frameSources[currentFrame % frameCount], Color.White, 0f, origin, scale, spriteEffect, 0f);
            frame = currentFrame;
        }
    }
}
