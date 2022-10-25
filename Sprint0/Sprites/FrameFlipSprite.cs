using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;

namespace sprint0.Sprites
{
    public class FrameFlipSprite : Sprite
    {
        private Rectangle frameSource;
        private int dynamicDelay;
        private SpriteEffects effect;

        public FrameFlipSprite(Texture2D spriteSheet, Rectangle frameSource, Vector2 origin, int delay, float scale)
        {
            this.spriteSheet = spriteSheet;
            this.frameSource = frameSource;
            this.origin = origin;
            this.delay = delay;
            delayCount = 0;
            this.scale = scale;
            dynamicDelay = 0;
            effect = SpriteEffects.None;
        }

        public FrameFlipSprite(Texture2D spriteSheet, Rectangle frameSource, Vector2 origin, int delay, int dynamicDelay, float scale)
        {
            this.spriteSheet = spriteSheet;
            this.frameSource = frameSource;
            this.origin = origin;
            this.delay = delay;
            delayCount = 0;
            this.scale = scale;
            this.dynamicDelay = dynamicDelay;
            effect = SpriteEffects.None;
        }

        public override int GetWidth(int animationFrame = -1)
        {
            return (int) (frameSource.Width * scale);
        }

        public override int GetHeight(int animationFrame = -1)
        {
            return (int) (frameSource.Height * scale);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffect, Color color)
        {
            spriteBatch.Draw(spriteSheet, position, frameSource, color, 0f, origin, scale, effect, 0f);

            // delay change in frames
            delayCount++;
            if (delayCount % delay <= dynamicDelay)
            {
                if (effect == SpriteEffects.None)
                {
                    effect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    effect = SpriteEffects.None;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffect, SpriteEffects alternate, Color color)
        {
            spriteBatch.Draw(spriteSheet, position, frameSource, color, 0f, origin, scale, effect, 0f);

            // delay change in frames
            delayCount++;
            if (delayCount % delay == 0)
            {
                if (effect == SpriteEffects.None)
                {
                    effect = alternate;
                }
                else
                {
                    effect = SpriteEffects.None;
                }
            }
        }
    }
}
