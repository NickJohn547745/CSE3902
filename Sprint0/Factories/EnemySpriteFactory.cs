using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Sprites;
using sprint0.Interfaces;
using System.Collections.Generic;

namespace sprint0.Factories
{
    public class EnemySpriteFactory
    {
        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get { return instance; }
        }

        private EnemySpriteFactory()
        {
        }
         
        public EnemySprite CreateStalfosSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetStalfosSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width / 2, spriteSheet.Height));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, 0, spriteSheet.Width / 2, spriteSheet.Height));

            return new EnemySprite(spriteSheet, frameSources, 6, 5);
        }
        
    }
}
