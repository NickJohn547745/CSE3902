using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;

namespace sprint0
{
    public class BlockSpriteFactory
    {

        private Texture2D blockSpriteSheet;
        // any other textures needed

        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get { return instance; }
        }

        private BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            blockSpriteSheet = content.Load<Texture2D>("Block");
        }

        /*
         * Add create Block functions when classes have been made
        public IBlock CreateBlock()
        {
            return new Block();
        }
        */
    }
}
