using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.PlayerClasses;
using sprint0.PlayerClasses.Abilities;
using sprint0.RoomClasses;

namespace sprint0.Enemies
{
    public abstract class Enemy : ICollidable
    {
        protected const int TileOffset = 20;

        public int Health { get; set; }
        public int MaxHealth { get; protected set; }
        public int Damage { get; set; }
        protected int delay;
        private int delayCount;
        private int damageDelay;
        public Vector2 FinalPosition { get; set; }
        public Vector2 Position { get; set; }
        protected Vector2 initPosition;
        protected float speed;

        private bool canMove = true;

        public Vector2 Velocity { get; set; }
        public ISprite Sprite { get; set; }

        private void TakeDamage(int damage)
        {
            if (damageDelay % 12 == 0)
            {
                Health -= damage;
            }
            damageDelay++;
        }

        protected abstract void Behavior(GameTime gameTime, Game1 game);

        public void Update(GameTime gameTime, Game1 game)
        {
            Position += speed * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (canMove)
            {
                FinalPosition = Position;
            }
            
            // Ex: change direction every delay seconds
            if (delayCount % delay == 0)
            {
                Behavior(gameTime, game);
            }
            delayCount++;

            if (Health <= 0)
            {
                game.CollidableList.Remove(this);
            }

            canMove = true;
        }

        public virtual void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            Type type = obj.GetObjectType();

            if (type == typeof(Player) || type == typeof(Ability))
            {
                TakeDamage(obj.Damage);
            } else if (type == typeof(Wall))
            {
                canMove = false;
            } else if (type == typeof(ITile))
            {
                switch (edge)
                {
                    case ICollidable.Edge.Top:
                        Position += new Vector2(0, -TileOffset);
                        break;
                    case ICollidable.Edge.Right:
                        Position += new Vector2(-TileOffset, 0);
                        break;
                    case ICollidable.Edge.Left:
                        Position += new Vector2(TileOffset, 0);
                        break;
                    case ICollidable.Edge.Bottom:
                        Position += new Vector2(0, TileOffset);
                        break;
                    default:
                        break;
                }

            }
        }

        public Type GetObjectType()
        {
            return this.GetType();
        }

        public Rectangle GetHitBox()
        {
            return new Rectangle((int) Position.X, (int) Position.Y, Sprite.GetWidth(), Sprite.GetHeight());
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, FinalPosition, SpriteEffects.None);
        }

        public void Reset(Game1 game)
        {
            Position = initPosition;
            Health = MaxHealth;       
        }
    }
}
