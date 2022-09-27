using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Interfaces;
using sprint0.TileClasses;

namespace sprint0
{
    public class TileSpriteFactory
    {

        private Texture2D tileSpriteSheet;
        // any other textures needed

        private static TileSpriteFactory instance = new TileSpriteFactory();

        public static TileSpriteFactory Instance
        {
            get { return instance; }
        }

        private TileSpriteFactory()
        {
            this.tileSpriteSheet = TextureStorage.GetTilesSpritesheet();
        }

        public ITile CreateTileType1()
        {
            return new TileType1();
        }

        /*
         * Add create Block functions when classes have been made
        public ISprite CreateBlockSprite()
        {
            return new BlockSprite();
        }
        */
    }
}
