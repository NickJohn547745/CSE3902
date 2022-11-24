using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Factories;
using sprint0.Sound;
using sprint0.Managers;
using System;
using Microsoft.Xna.Framework.Audio;

namespace sprint0.Enemies
{
    public abstract class Enemy : ICollidable
    {
        protected const int TileOffset = 5;
        protected const int DeathFrames = 4;       
        private const int StunDelay = 80;

        protected readonly Random rand = new();
        protected readonly SoundEffect sound = SoundManager.Manager.enemyDamageSound();

        protected HealthManager Health;
        protected int deadCount;

        public int Damage { get; set; }
        protected int delay;
        private int delayCount;
        protected int stunCount;
        public ICollidable.ObjectType type { get; set; }
        public Vector2 PreviousPosition { get; set; }
        public Vector2 Position { get; set; }
        protected Vector2 initPosition;
        protected float speed;

        protected bool canMove = true;

        public Vector2 Velocity { get; set; }
        public ISprite Sprite { get; set; }

        protected void InitEnemyFields()
        {
            stunCount = 0;
            deadCount = 0;
            type = ICollidable.ObjectType.Enemy;
        }

        protected virtual void Stun() {}

        protected virtual void ReverseDirection()
        {
            Velocity *= -1;
        }

        private void Move(GameTime gameTime)
        {
            if (canMove)
            {
                PreviousPosition = Position;
                Position += speed * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                Position = PreviousPosition;
            }
        }

        protected virtual void Death()
        {
            if (deadCount >= DeathFrames)
            {
                CollisionManager.Collidables.Remove(this);
                SoundManager.Manager.enemyDeadSound().Play();
            }
        }
        
        protected abstract void Behavior(GameTime gameTime);

        public virtual void Update(GameTime gameTime)
        {
            Health.UpdateCounters();

            if (stunCount % StunDelay == 0)
            {
                Move(gameTime);

                // Ex: change direction every delay seconds
                if (delayCount % delay == 0)
                {
                    Behavior(gameTime);
                }

                delayCount++;
            } else
            {
                stunCount++;
            }

            Death();
            
            canMove = true;
        }

        public virtual void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            switch (obj.type)
            {
                case ICollidable.ObjectType.Sword:
                case ICollidable.ObjectType.Ability:
                    Health.TakeDamage(obj.Damage);
                    break;
                case ICollidable.ObjectType.Wall:
                case ICollidable.ObjectType.Tile:
                case ICollidable.ObjectType.Door:
                    ReverseDirection();
                    canMove = false;
                    break;
                case ICollidable.ObjectType.Boomerang:
                    Stun();
                    break;
            }
        }
        

        public Rectangle GetHitBox()
        {
            return new Rectangle((int) Position.X, (int) Position.Y, Sprite.GetWidth(), Sprite.GetHeight());
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Health.Dead())
            {
                EnemySpriteFactory.Instance.CreateEnemyExplosionSprite().Draw(spriteBatch, Position, SpriteEffects.None, Color.White);
                deadCount++;
            }
            else
            {
                Sprite.Draw(spriteBatch, Position, SpriteEffects.None, Health.Color);
            }
        }

        public void Reset()
        {
            Position = initPosition;
            Health.Reset();
            deadCount = 0;
        }
    }
}
