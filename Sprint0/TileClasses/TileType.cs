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
    public abstract class TileType : ITile
    {
        public Point Location { get; set; }

        private Vector2 textureCoords;

        private Texture2D texture;

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = TextureStorage.GetTilesSpritesheet();

            int col = (int)textureCoords.X;
            int row = (int)textureCoords.Y;

            Rectangle sourceRect = new Rectangle(16 * col, 16 * row, 16, 16);
            Rectangle destRect = new Rectangle(Location, new Point(80, 80));

            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }

        internal void SetTextureCoords(int col, int row)
        {
            textureCoords = new Vector2(col, row);
        }
        internal void SetLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        public void Update(GameTime gameTime)
        {
            // Empty - Not used
        }
    }
}
