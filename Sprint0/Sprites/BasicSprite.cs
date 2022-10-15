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
    public class BasicSprite : Sprite
    {
        public BasicSprite(Texture2D spriteSheet, List<Rectangle> frameSources, Vector2 origin, int delay, float scale)
        {
            this.spriteSheet = spriteSheet;
            this.frameSources = frameSources;
            this.origin = origin;
            this.delay = delay;
            frame = 0;
            frameCount = frameSources.Count;
            delayCount = 0;
            this.scale = scale;
        }

        public BasicSprite(Texture2D spriteSheet, List<Rectangle> frameSources, int delay, float scale)
        {
            this.spriteSheet = spriteSheet;
            this.frameSources = frameSources;
            this.origin = Vector2.Zero;
            this.delay = delay;
            frame = 0;
            frameCount = frameSources.Count;
            delayCount = 0;
            this.scale = scale;
        }
    }
}
