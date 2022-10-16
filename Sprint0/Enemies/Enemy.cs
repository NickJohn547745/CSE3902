using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.PlayerClasses;
using sprint0.Factories;

namespace sprint0.Enemies
{
    public abstract class Enemy : ICollidable
    {
        private const int tileOffset = 20;

        public int health { get; set; }
        public int damage { get; set; }
        protected int delay;
        private int delayCount;
        public Vector2 position { get; set; }
        protected Vector2 initPosition;
        protected float speed;
        public Vector2 velocity { get; set; }
        public ISprite sprite { get; set; }

        protected abstract void Behavior(GameTime gameTime, Game1 game);

        public void Update(GameTime gameTime, Game1 game)
        {
            position += speed * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.X < 0 || position.Y < 0 || position.X + sprite.GetWidth()> game.GetWindowWidth() || position.Y + sprite.GetHeight() > game.GetWindowHeight())
            {
                position = initPosition;
            }

            // change direction every delay seconds
            if (delayCount % delay == 0)
            {
                Behavior(gameTime, game);
            }
            delayCount++;

            if (health <= 0)
            {
                game.CollidableList.Remove(this);
            }
        }

        public virtual void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            Type type = obj.GetObjectType();

            if (type == typeof(Player))
            {
                
            } else if (type == typeof(ITile))
            {
                switch (edge)
                {
                    case ICollidable.Edge.Top:
                        position += new Vector2(0, -tileOffset);
                        break;
                    case ICollidable.Edge.Right:
                        position += new Vector2(-tileOffset, 0);
                        break;
                    case ICollidable.Edge.Left:
                        position += new Vector2(tileOffset, 0);
                        break;
                    case ICollidable.Edge.Bottom:
                        position += new Vector2(0, tileOffset);
                        break;
                    default:
                        break;
                }

            }
        }

        public Type GetObjectType()
        {
            return this.GetType().BaseType;
        }

        public Rectangle GetHitBox()
        {
            return new Rectangle((int) position.X, (int) position.Y, sprite.GetWidth(), sprite.GetHeight());
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position, SpriteEffects.None);
        }

        public void Reset()
        {
            position = initPosition;
        }
    }
}
