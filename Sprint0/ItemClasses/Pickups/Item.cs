using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;

namespace sprint0.ItemClasses.Pickups
{
    public abstract class Item : IItemPickup
    {
        public Vector2 Position { get; set; }
        
        public ISprite Sprite { get; set; }

        public ICollidable.ObjectType type { get; set; }
        public int Damage { get; set; }

        public virtual void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
        }

        public virtual Rectangle GetHitBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Sprite.GetWidth(), Sprite.GetHeight());
        }

        public virtual void Update(GameTime gameTime, Game1 game)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position, SpriteEffects.None, Color.White);
        }

        public void Reset() {
            
        }
    }
}
