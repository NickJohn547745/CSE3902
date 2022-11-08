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

namespace sprint0.DoorClasses
{
    public abstract class Door : ICollidable
    {
        public int Damage { get; set; }
        public ICollidable.objectType type { get; set; }

        public int Id { get; set; }

        public void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            // Not needed
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract Rectangle GetHitBox();
        public abstract Type GetObjectType();

        public void Reset(Game1 game)
        {
            // Not needed
        }

        public void Update(GameTime gameTime, Game1 game)
        {

        }
    }
}
