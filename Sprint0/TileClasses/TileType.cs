using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.TileClasses
{
    public abstract class TileType : ITile, ICollidable
    {
        public Point Location { get; set; }
        public int Damage { get; set; }

        private Vector2 textureCoords;

        private Texture2D texture;

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = TextureStorage.GetTilesSpritesheet();

            int col = (int)textureCoords.X;
            int row = (int)textureCoords.Y;

            Rectangle sourceRect = new Rectangle(16 * col, 16 * row, 16, 16);
            Rectangle destRect = GetHitBox();

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

        public void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            // Empty - Not used
        }

        public abstract Type GetObjectType();

        public Rectangle GetHitBox()
        {
            return new Rectangle(Location, new Point(80, 80));
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            // Empty - Not used
        }

        public void Reset(Game1 game)
        {
            // Empty - Not used
        }
    }
}
