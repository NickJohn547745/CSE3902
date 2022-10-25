using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Sprites;

namespace sprint0.Factories
{
    public class ItemSpriteFactory {
        private int ItemScale = 3;

        private Texture2D itemSpriteSheet;
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
    }
}
