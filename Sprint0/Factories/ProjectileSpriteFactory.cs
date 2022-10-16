using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Projectiles;
using sprint0.Sprites;
using System.Collections.Generic;

namespace sprint0.Factories
{
    public class ProjectileSpriteFactory
    {
        private const int GoriyaProjectileX1 = 1;
        private const int GoriyaProjectileX2 = 9;
        private const int GoriyaProjectileX3 = 19;
        private const int GoriyaProjectileY1 = 4;
        private const int GoriyaProjectileY2 = 4;
        private const int GoriyaProjectileY3 = 6;
        private const int GoriyaProjectileWidth1 = 5;
        private const int GoriyaProjectileWidth2 = 8;
        private const int GoriyaProjectileWidth3 = 7;
        private const int GoriyaProjectileHeight1 = 8;
        private const int GoriyaProjectileHeight2 = 8;
        private const int GoriyaProjectileHeight3 = 5;
        private const int GoriyaProjectileDelay = 6;
        private const int GoriyaProjectileScale = 5;

        private const int AquamentusProjectileX = 8;
        private const int AquamentusProjectileY1 = 2;
        private const int AquamentusProjectileY2 = 18;
        private const int AquamentusProjectileWidth = 8;
        private const int AquamentusProjectileHeight = 11;
        private const int AquamentusProjectileDelay = 6;
        private const int AquamentusProjectileScale = 5;


        private static ProjectileSpriteFactory instance = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance
        {
            get { return instance; }
        }

        private ProjectileSpriteFactory()
        {
        }
        public ISprite CreateGoriyaProjectileSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaProjectileSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(GoriyaProjectileX1, GoriyaProjectileY1, GoriyaProjectileWidth1, GoriyaProjectileHeight1));
            frameSources.Add(new Rectangle(GoriyaProjectileX2, GoriyaProjectileY2, GoriyaProjectileWidth2, GoriyaProjectileHeight2));
            frameSources.Add(new Rectangle(GoriyaProjectileX3, GoriyaProjectileY3, GoriyaProjectileWidth3, GoriyaProjectileHeight3));

            return new BasicSprite(spriteSheet, frameSources, Vector2.Zero, GoriyaProjectileDelay, GoriyaProjectileScale);
        }

        public ISprite CreateAquamentusProjectileSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetFireballSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, AquamentusProjectileY1, AquamentusProjectileWidth, AquamentusProjectileHeight));
            frameSources.Add(new Rectangle(AquamentusProjectileX, AquamentusProjectileY1, AquamentusProjectileWidth, AquamentusProjectileHeight));
            frameSources.Add(new Rectangle(0, AquamentusProjectileY2, AquamentusProjectileWidth, AquamentusProjectileHeight));
            frameSources.Add(new Rectangle(AquamentusProjectileX, AquamentusProjectileY2, AquamentusProjectileWidth, AquamentusProjectileHeight));

            return new BasicSprite(spriteSheet, frameSources, AquamentusProjectileDelay, AquamentusProjectileScale);
        }

    }
}
