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
        private const int KeeseWidth = 16;
        private const int KeeseHeight1 = 8;
        private const int KeeseHeight2 = 10;
        private const int KeeseX1 = 0;
        private const int KeeseX2 = 16;
        private const int KeeseY = 4;
        

        private const int GoriyaDelay = 8;
        private const float GoriyaScale = 5;
        private const int GoriyaWidth = 15;
        private const int GoriyaHeight = 15;
        private const int GoriyaUpX = 20;
        private const int GoriyaUpY = 1;
        private const int GoriyaDownX = 1;
        private const int GoriyaDownY = 1;
        private const int GoriyaSideY1 = 19;
        private const int GoriyaSideY2 = 20;
        private const int GoriyaSideX1 = 1;
        private const int GoriyaSideX2 = 19;

        private const int ZolDelay = 8;
        private const float ZolScale = 5;
        private const int ZolX1 = 0;
        private const int ZolX2 = 16;
        private const int ZolWidth = 15;

        private const int OldManDelay = 2;
        private const float OldManScale = 5;

        private const int AquamentusDelay = 8;
        private const float AquamentusScale = 5;
        
        private const int ExplosionDelay = 8;
        private const float ExplosionScale = 5;

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get { return instance; }
        }

        private EnemySpriteFactory()
        {
        }
         
        public ISprite CreateStalfosSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetStalfosSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width / 2, spriteSheet.Height));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, 0, spriteSheet.Width / 2, spriteSheet.Height));

            return new BasicSprite(spriteSheet, frameSources, StalfosDelay, StalfosScale);
        }

        public ISprite CreateKeeseSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetKeeseSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(KeeseX1, KeeseY, KeeseWidth, KeeseHeight1));
            frameSources.Add(new Rectangle(KeeseX2, KeeseY, KeeseWidth, KeeseHeight2));

            return new BasicSprite(spriteSheet, frameSources, KeeseDelay, KeeseScale);
        }

        public ISprite CreateGoriyaFacingUpStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            Rectangle frameSource = new Rectangle(GoriyaUpX, GoriyaUpY, GoriyaWidth, GoriyaHeight);

            return new FrameFlipSprite(spriteSheet, frameSource, Vector2.Zero, GoriyaDelay, GoriyaScale);
        }

        public ISprite CreateGoriyaFacingDownStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            Rectangle frameSource = new Rectangle(GoriyaDownX, GoriyaDownY, GoriyaWidth, GoriyaHeight);

            return new FrameFlipSprite(spriteSheet, frameSource, Vector2.Zero, GoriyaDelay, GoriyaScale);
        }

        public ISprite CreateGoriyaFacingSideStateSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();

            frameSources.Add(new Rectangle(GoriyaSideX1, GoriyaSideY1, GoriyaWidth, GoriyaHeight));
            frameSources.Add(new Rectangle(GoriyaSideX2, GoriyaSideY2, GoriyaWidth, GoriyaHeight));

            return new BasicSprite(spriteSheet, frameSources, GoriyaDelay, GoriyaScale);
        }

        public ISprite CreateZolSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetZolSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();

            frameSources.Add(new Rectangle(ZolX1, 0, ZolWidth, spriteSheet.Height));
            frameSources.Add(new Rectangle(ZolX2, 0, ZolWidth, spriteSheet.Height));

            return new BasicSprite(spriteSheet, frameSources, ZolDelay, ZolScale);
        }

        public ISprite CreateOldManNPCSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetOldManSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();

            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width, spriteSheet.Height));

            return new BasicSprite(spriteSheet, frameSources, OldManDelay, OldManScale);
        }
        public ISprite CreateAquamentusSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetAquamentusSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(1, 0, spriteSheet.Width / 2, spriteSheet.Height / 2));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, 0, spriteSheet.Width / 2, spriteSheet.Height / 2));
            frameSources.Add(new Rectangle(1, spriteSheet.Height / 2, spriteSheet.Width / 2, spriteSheet.Height / 2));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, spriteSheet.Height / 2, spriteSheet.Width / 2, spriteSheet.Height / 2));

            return new BasicSprite(spriteSheet, frameSources, AquamentusDelay, AquamentusScale);
        }
        
        public ISprite CreateEnemyExplosionSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetEnemyexplosionSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width / 4, spriteSheet.Height));
            frameSources.Add(new Rectangle(spriteSheet.Width / 4, 0, spriteSheet.Width / 4, spriteSheet.Height));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, 0, spriteSheet.Width / 4, spriteSheet.Height));
            frameSources.Add(new Rectangle(spriteSheet.Width * 3 / 4, 0, spriteSheet.Width / 2, spriteSheet.Height));

            return new BasicSprite(spriteSheet, frameSources, ExplosionDelay, ExplosionScale);
        }

        public ISprite CreateWallMasterSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetWallmasterSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width / 2, spriteSheet.Height));
            frameSources.Add(new Rectangle(spriteSheet.Width / 2, 0, spriteSheet.Width / 2, spriteSheet.Height));

            return new BasicSprite(spriteSheet, frameSources, KeeseDelay, KeeseScale);
        }

        public ISprite CreateTrapSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetTrapSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 0, spriteSheet.Width, spriteSheet.Height));

            return new BasicSprite(spriteSheet, frameSources, KeeseDelay, KeeseScale);
        }
    }
}
