using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Sprites;
using System.Collections.Generic;

namespace sprint0.Factories
{
    public class ProjectileSpriteFactory
    {

        //private Texture2D projectileSpriteSheet;
        // any other textures needed

        private static ProjectileSpriteFactory instance = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance
        {
            get { return instance; }
        }

        private ProjectileSpriteFactory()
        {
        }
        public Sprite CreateGoriyaProjectileSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetGoriyaProjectileSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(1, 4, 5, 8));
            frameSources.Add(new Rectangle(9, 4, 8, 8));
            frameSources.Add(new Rectangle(19, 6, 7, 5));

            return new BasicProjectileSprite(spriteSheet, frameSources, 6, 5);
        }

        public Sprite CreateAquamentusProjectileSprite()
        {
            Texture2D spriteSheet = TextureStorage.GetFireballSpritesheet();
            List<Rectangle> frameSources = new List<Rectangle>();
            frameSources.Add(new Rectangle(0, 2, 8, 11));
            frameSources.Add(new Rectangle(8, 2, 8, 11));
            frameSources.Add(new Rectangle(0, 18, 8, 11));
            frameSources.Add(new Rectangle(8, 18, 8, 11));

            return new BasicProjectileSprite(spriteSheet, frameSources, 6, 5);
        }

    }
}
