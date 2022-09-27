using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.TileClasses
{
    public class TileType1 : ITile
    {

        public Vector2 Location { get; set; }
        Texture2D texture;


        public TileType1()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = TextureStorage.GetTilesSpritesheet();
            /* Rectangle texturePos = TileSpriteFactory.GetTile1Sprite();
             spriteBatch.Draw(texture, texturePos)
            */
        }
    }
}
