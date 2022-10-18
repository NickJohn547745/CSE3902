using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Interfaces;
using sprint0.PlayerClasses;

namespace sprint0.RoomClasses
{
    public abstract class Wall : ICollidable
    {
        public int Damage { get; set; }

        private Rectangle bounds = new Rectangle();

        public void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            // Not needed
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureStorage.GetWallsSpritesheet(), bounds, Color.White);
        }

        public abstract Rectangle GetHitBox();

        public Type GetObjectType()
        {
            return typeof(Wall);
        }

        public void Reset(Game1 game)
        {
            // Not needed
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            bounds = game.GraphicsDevice.PresentationParameters.Bounds;
        }
    }
}
