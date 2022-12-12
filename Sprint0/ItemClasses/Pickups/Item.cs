using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.PlayerClasses;

namespace sprint0.ItemClasses.Pickups
{
    public abstract class Item : IItemPickup
    {
        public Vector2 Position { get; set; }
        
        public ISprite Sprite { get; set; }

        public ICollidable.ObjectType Type { get; set; }
        public int Damage { get; set; }

        protected PlayerInventory Inventory;

        public virtual void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
        }

        public Vector2 GetVelocity()
        {
            return Vector2.Zero;
        }

        public virtual Rectangle GetHitBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Sprite.GetWidth(), Sprite.GetHeight());
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position, SpriteEffects.None, Color.White);
        }

        public void Reset() {
            
        }

        public void Reset(bool healthCheat, bool bombCheat, bool rupeeCheat, bool mapCheat, bool compassCheat)
        {

        }
    }
}
