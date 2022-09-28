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
        public ITile CreateTileType2()
        {
            return new TileType2();
        }
        public ITile CreateTileType3()
        {
            return new TileType3();
        }
        public ITile CreateTileType4()
        {
            return new TileType4();
        }
        public ITile CreateTileType5()
        {
            return new TileType5();
        }
        public ITile CreateTileType6()
        {
            return new TileType6();
        }
        public ITile CreateTileType7()
        {
            return new TileType7();
        }
        public ITile CreateTileType8()
        {
            return new TileType8();
        }
        public ITile CreateTileType9()
        {
            return new TileType9();
        }
        public ITile CreateTileType10()
        {
            return new TileType10();
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
