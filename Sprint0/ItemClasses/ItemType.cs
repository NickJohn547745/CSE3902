using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.ItemClasses
{
    public abstract class ItemType : IItem
    {
        public Point Location { get; set; }

        private Rectangle sourceRect;

        private Texture2D texture;

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle(Location, new Point(sourceRect.Width * 6, sourceRect.Height * 6));

            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }

        internal void SetLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        internal void SetTexture(Texture2D texture, Rectangle area)
        {
            this.texture = texture;
            this.sourceRect = area;
        }

        public void Update(GameTime gameTime)
        {
            // Empty - Not used
        }
    }
}
