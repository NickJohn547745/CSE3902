using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Sprites;

namespace sprint0.Factories
{
    public class ItemSpriteFactory {
        private int ItemScale = 5;

        //private Texture2D itemSpriteSheet;
        // any other textures needed

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get { return instance; }
        }

        private ItemSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //itemSpriteSheet = content.Load<Texture2D>("Items");
        }
        

        public ISprite ArrowSprite()
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 5, 16) };
            return new BasicSprite(TextureStorage.GetArrowSpritesheet(), frameSource, 1, ItemScale);
        }
        public ISprite BombSprite()
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 8, 14) };
            return new BasicSprite(TextureStorage.GetBombSpritesheet(), frameSource, 1, ItemScale);
        }
        public ISprite BoomerangSprite()
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 5, 8) };
            return new BasicSprite(TextureStorage.GetBoomerangSpritesheet(), frameSource, 1, ItemScale);
        }
        public ISprite KeySprite()
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 8, 16) };
            return new BasicSprite(TextureStorage.GetKeySpritesheet(), frameSource, 1, ItemScale);
        }
        public ISprite HeartSprite()
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 7, 8), new Rectangle(7,0,7,8) };
            return new BasicSprite(TextureStorage.GetHeartSpritesheet(), frameSource, 8, ItemScale);
        }
        public ISprite RupeeSprite()
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 8, 16), new Rectangle(8,0,8,16) };
            return new BasicSprite(TextureStorage.GetRupeeSpritesheet(), frameSource, 8, ItemScale);
        }
        public ISprite ClockSprite()
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 11, 16)};
            return new BasicSprite(TextureStorage.GetClockSpritesheet(), frameSource, 1, ItemScale);
        }
        public ISprite CompassSprite()
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 11, 12)};
            return new BasicSprite(TextureStorage.GetCompassSpritesheet(), frameSource, 1, ItemScale);
        }
        public ISprite MapSprite()
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 8, 16)};
            return new BasicSprite(TextureStorage.GetMapSpritesheet(), frameSource, 1, ItemScale);
        }
        public ISprite TriforceSprite(int scale)
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 10, 10), new Rectangle(10,0,10,10)};
            return new BasicSprite(TextureStorage.GetTriforceSpritesheet(), frameSource, 8, scale);
        }
        public ISprite HeartContainerSprite()
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 13, 13)};
            return new BasicSprite(TextureStorage.GetHeartcontainerSpritesheet(), frameSource, 1, ItemScale);
        }
        public ISprite BowSprite()
        {
            List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(0, 0, 8, 16)};
            return new BasicSprite(TextureStorage.GetBowSpritesheet(), frameSource, 1, ItemScale);
        }
        
    }
}
