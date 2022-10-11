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
        private const int StalfosDelay = 6;
        private const float StalfosScale = 5;

        private const int KeeseDelay = 6;
        private const float KeeseScale = 5;

        private const int GoriyaDelay = 8;
        private const float GoriyaScale = 5;
        private const int GoriyaWidth = 15;
        private const int GoriyaHeight = 15;
        private const int GoriyaUpX = 20;
        private const int GoriyaSideY1 = 19;
        private const int GoriyaSideY2 = 20;
        private const int GoriyaSideX2 = 19;

        private const int ZolDelay = 8;
        private const float ZolScale = 5;
        private const int ZolX1 = 2;
        private const int ZolX2 = 16;
        private const int ZolWidth1 = 12;
        private const int ZolWidth2 = 15;

        private const int OldManDelay = 2;
        private const float OldManScale = 5;

        private const int AquamentusDelay = 8;
        private const float AquamentusScale = 5;

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

            return new BasicEnemySprite(spriteSheet, frameSources, StalfosDelay, StalfosScale);
        }

        public Sprite CreateKeeseSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetKeeseSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width / 2, spriteSheet.Height));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2 + 1, 0, spriteSheet.Width / 2, spriteSheet.Height));

            return new BasicEnemySprite(spriteSheet, frameSources, KeeseDelay, KeeseScale);
        }

        public Sprite CreateGoriyaFacingUpStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            Rectangle frameSource = new Rectangle(GoriyaUpX, 1, GoriyaWidth, GoriyaHeight);

            return new FrameFlipEnemySprite(spriteSheet, frameSource, GoriyaDelay, GoriyaScale);
        }

        public Sprite CreateGoriyaFacingDownStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            Rectangle frameSource = new Rectangle(1, 1, GoriyaWidth, GoriyaHeight);

            return new FrameFlipEnemySprite(spriteSheet, frameSource, GoriyaDelay, GoriyaScale);
        }

        public Sprite CreateGoriyaFacingSideStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();

            frameSources.Add(new Rectangle(1, GoriyaSideY1, GoriyaWidth, GoriyaHeight));
            frameSources.Add(new Rectangle(GoriyaSideX2, GoriyaSideY2, GoriyaWidth, GoriyaHeight));

            return new BasicEnemySprite(spriteSheet, frameSources, GoriyaDelay, GoriyaScale);
        }

        public Sprite CreateZolSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetZolSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();

            frameSources.Add(new Rectangle(ZolX1, 0, ZolWidth1, spriteSheet.Height));
            frameSources.Add(new Rectangle(ZolX2, 0, ZolWidth2, spriteSheet.Height));

            return new BasicEnemySprite(spriteSheet, frameSources, ZolDelay, ZolScale);
        }

        public Sprite CreateOldManNPCSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetOldManSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();

            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width, spriteSheet.Height));

            return new BasicEnemySprite(spriteSheet, frameSources, OldManDelay, OldManScale);
        }
        public Sprite CreateAquamentusSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetAquamentusSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(1, 0, spriteSheet.Width / 2, spriteSheet.Height / 2));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, 0, spriteSheet.Width / 2, spriteSheet.Height / 2));
            frameSources.Add(new Rectangle(1, spriteSheet.Height / 2, spriteSheet.Width / 2, spriteSheet.Height / 2));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, spriteSheet.Height / 2, spriteSheet.Width / 2, spriteSheet.Height / 2));

            return new BasicEnemySprite(spriteSheet, frameSources, AquamentusDelay, AquamentusScale);

        }
    }
}
