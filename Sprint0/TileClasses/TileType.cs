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
    public abstract class TileType : ICollidable
    {
        public Point Location { get; set; }

        private Vector2 textureCoords;

        private Texture2D texture;

        public int Damage { get; set; }
        public ICollidable.objectType type { get; set; }
        private bool collidable;


        public void Draw(SpriteBatch spriteBatch)
        {
            texture = TextureStorage.GetTilesSpritesheet();

            int col = (int)textureCoords.X;
            int row = (int)textureCoords.Y;

            Rectangle sourceRect = new Rectangle(16 * col, 16 * row, 16, 16);
            Rectangle destRect = GetHitBox();

            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }

        public void Collide(ICollidable obj, ICollidable.Edge Edge)
        {
            // Type type = obj.GetObjectType();

            // Code may be needed if some blocks are pushable / trap tiles
        }

        public Rectangle GetHitBox()
        {
            int tileWidth = 80;
            int tileHeight = 80;
            return new Rectangle(Location.X, Location.Y, tileWidth, tileHeight);
        }

        internal void SetTextureCoords(int col, int row)
        {
            textureCoords = new Vector2(col, row);
        }
        internal void SetLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        internal void SetCollidable(bool isCollidable)
        {
            this.collidable = isCollidable;
        }

        public abstract Type GetObjectType();

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
