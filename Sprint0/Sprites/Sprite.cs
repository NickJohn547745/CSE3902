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

        public virtual int GetWidth()
        {
            return frameSources[frame % frameSources.Count].Width;
        }

        public virtual int GetHeight()
        {
            return frameSources[frame % frameSources.Count].Height;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {

            spriteBatch.Draw(spriteSheet, position, frameSources[frame % frameSources.Count], Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            // delay change in frames
            delayCount++;
            if (delayCount % delay == 0) frame++;

        }

        /*
         * use spriteEffects
        */
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffect)
        {
            spriteBatch.Draw(spriteSheet, position, frameSources[frame % frameSources.Count], Color.White, 0f, Vector2.Zero, scale, spriteEffect, 0f);

            // delay change in frames
            delayCount++;
            if (delayCount % delay == 0) frame++;
        }
    }
}
