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
        public ICollidable.ObjectType Type { get; set; }
        public bool IsCollidable { get; set; }


        public void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, new Point());
        }

        public void Draw(SpriteBatch spriteBatch, Point offset)
        {
            texture = TextureStorage.GetTilesSpritesheet();

            int col = (int)textureCoords.X;
            int row = (int)textureCoords.Y;

            Rectangle sourceRect = new Rectangle(16 * col, 16 * row, 16, 16);

            Rectangle hitBox = GetHitBox();
            Rectangle destRect = new Rectangle(hitBox.Location + offset, hitBox.Size);

            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }

        public void Collide(ICollidable obj, ICollidable.Edge Edge)
        {
            // Type Type = obj.GetObjectType();

            // Code may be needed if some blocks are pushable / trap tiles
        }

        public Direction GetMoveDirection()
        {
            return Direction.None;
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

        public void Update(GameTime gameTime)
        {
            // Empty - Not used
        }

        public void Reset()
        {
            // Empty - Not used
        }
    }
}
