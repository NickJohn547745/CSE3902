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
        public ICollidable.ObjectType Type { get; set; }


        public void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            // Not needed
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public Vector2 GetVelocity()
        {
            return Vector2.Zero;
        }

        public abstract Rectangle GetHitBox();

        public void Reset()
        {
            // Not needed
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
