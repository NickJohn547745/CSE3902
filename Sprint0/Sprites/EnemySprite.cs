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
    public class EnemySprite : ISprite
    {
        
        private Texture2D spriteSheet;
        private List<Rectangle> frameSources;
        private int delay;
        private int delayCount;
        private int frame;
        private int frameCount;
        private float scale;

        public EnemySprite(Texture2D spriteSheet, List<Rectangle> frameSources, int delay, float scale)
        {
            this.spriteSheet = spriteSheet;
            this.frameSources = frameSources;
            this.delay = delay;
            frame = 0;
            frameCount = frameSources.Count;
            delayCount = 0;
            this.scale = scale;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {

            spriteBatch.Draw(spriteSheet, position, frameSources[frame], Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            // delay change in frames
            delayCount++;
            if (delayCount % delay == 0)
            {
                frame++;
                if (frame >= frameCount) frame = 0;
            }

        }
    }
}
