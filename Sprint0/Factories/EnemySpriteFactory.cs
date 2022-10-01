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
         
        public BasicEnemySprite CreateStalfosSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetStalfosSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width / 2, spriteSheet.Height));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, 0, spriteSheet.Width / 2, spriteSheet.Height));

            return new BasicEnemySprite(spriteSheet, frameSources, 6, 5);
        }
        public BasicEnemySprite CreateKeeseSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetKeeseSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width / 2, spriteSheet.Height));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2 + 1, 0, spriteSheet.Width / 2, spriteSheet.Height));

            return new BasicEnemySprite(spriteSheet, frameSources, 6, 5);
        }

        public BasicEnemySprite CreateGoriyaFacingUpStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            //frameSources.Add(new Rectangle(0, 0, spriteSheet.Width / 2, spriteSheet.Height / 2));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2 , 0, spriteSheet.Width / 2, spriteSheet.Height / 2));


            //frameSources.Add(new Rectangle(0, spriteSheet.Height / 2, spriteSheet.Width / 2, spriteSheet.Height / 2));
            //frameSources.Add(new Rectangle(spriteSheet.Width / 2, spriteSheet.Height / 2, spriteSheet.Width / 2, spriteSheet.Height / 2));

            return new BasicEnemySprite(spriteSheet, frameSources, 6, 5);
        }

        public BasicEnemySprite CreateGoriyaFacingDownStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width / 2, spriteSheet.Height / 2));

            return new BasicEnemySprite(spriteSheet, frameSources, 6, 5);
        }

        public BasicEnemySprite CreateGoriyaFacingRightStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();

            frameSources.Add(new Rectangle(0, spriteSheet.Height / 2, spriteSheet.Width / 2, spriteSheet.Height / 2));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, spriteSheet.Height / 2, spriteSheet.Width / 2, spriteSheet.Height / 2));

            return new BasicEnemySprite(spriteSheet, frameSources, 6, 5);
        }

        public BasicEnemySprite CreateGoriyaFacingLeftStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();

            frameSources.Add(new Rectangle(0, spriteSheet.Height / 2, spriteSheet.Width / 2, spriteSheet.Height / 2));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, spriteSheet.Height / 2, spriteSheet.Width / 2, spriteSheet.Height / 2));

            return new BasicEnemySprite(spriteSheet, frameSources, 6, 5);
        }

    }
}
