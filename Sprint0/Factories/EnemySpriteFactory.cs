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
         
        public Sprite CreateStalfosSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetStalfosSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width / 2, spriteSheet.Height));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, 0, spriteSheet.Width / 2, spriteSheet.Height));

            return new BasicEnemySprite(spriteSheet, frameSources, 6, 5);
        }
        public Sprite CreateKeeseSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetKeeseSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width / 2, spriteSheet.Height));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2 + 1, 0, spriteSheet.Width / 2, spriteSheet.Height));

            return new BasicEnemySprite(spriteSheet, frameSources, 6, 5);
        }

        public Sprite CreateGoriyaFacingUpStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            Rectangle frameSource = new Rectangle(20, 1, 15, 15);

            return new FrameFlipEnemySprite(spriteSheet, frameSource, 8, 5);
        }

        public Sprite CreateGoriyaFacingDownStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            Rectangle frameSource = new Rectangle(1, 1, 15, 15);

            return new FrameFlipEnemySprite(spriteSheet, frameSource, 8, 5);
        }

        public Sprite CreateGoriyaFacingSideStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();

            frameSources.Add(new Rectangle(1, 19, 15, 15));
            frameSources.Add(new Rectangle(19, 20, 16, 15));

            return new BasicEnemySprite(spriteSheet, frameSources, 8, 5);
        }

        public Sprite CreateZolSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetZolSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();

            frameSources.Add(new Rectangle(2, 0, 12, spriteSheet.Height));
            frameSources.Add(new Rectangle(16, 0, 15, spriteSheet.Height));

            return new BasicEnemySprite(spriteSheet, frameSources, 8, 5);
        }
    }
}
