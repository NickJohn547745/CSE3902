using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;

namespace sprint0.Factories
{
    public class ItemSpriteFactory
    {

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

        /*
         * Add create item functions when classes have been made
        public ISprite CreateItemSprite()
        {
            return new ItemSprite();
        }
        */
    }
}
