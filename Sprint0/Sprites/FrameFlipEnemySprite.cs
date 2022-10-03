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
    public class FrameFlipEnemySprite : Sprite
    {
        private Rectangle frameSource;
        private SpriteEffects spriteEffect;

        public FrameFlipEnemySprite(Texture2D spriteSheet, Rectangle frameSource, int delay, float scale)
        {
            this.spriteSheet = spriteSheet;
            this.frameSource = frameSource;
            this.delay = delay;
            delayCount = 0;
            this.scale = scale;
            spriteEffect = SpriteEffects.None;
        }

        public override int GetWidth()
        {
            return frameSource.Width;
        }

        public override int GetHeight()
        {
            return frameSource.Height;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(spriteSheet, position, frameSource, Color.White, 0f, Vector2.Zero, scale, spriteEffect, 0f);

            // delay change in frames
            delayCount++;
            if (delayCount % delay == 0)
            {
                if (spriteEffect == SpriteEffects.None)
                {
                    spriteEffect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    spriteEffect = SpriteEffects.None;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects alternate)
        {
            spriteBatch.Draw(spriteSheet, position, frameSource, Color.White, 0f, Vector2.Zero, scale, spriteEffect, 0f);

            // delay change in frames
            delayCount++;
            if (delayCount % delay == 0)
            {
                if (spriteEffect == SpriteEffects.None)
                {
                    spriteEffect = alternate;
                }
                else
                {
                    spriteEffect = SpriteEffects.None;
                }
            }
        }
    }
}
