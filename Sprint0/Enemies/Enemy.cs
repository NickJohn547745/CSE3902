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

        protected readonly Random rand = new();
        protected readonly SoundEffect sound = SoundManager.Manager.enemyDamageSound();

        public PhysicsManager Physics { get; protected set; }
        protected HealthManager Health;
        protected int deadCount;

        public int Damage { get; set; }
        protected int delay;
        private int delayCount;
        public ICollidable.ObjectType type { get; set; }
        public ISprite Sprite { get; set; }

        protected void InitEnemyFields()
        {
            deadCount = 0;
            type = ICollidable.ObjectType.Enemy;
        }

        protected virtual void BoomerangBehavior() {}

        protected virtual void WallBehavior()
        {
            Physics.ReverseDirection();
            Physics.Freeze();
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

            Physics.Move(gameTime);

            if (Physics.Stunned())
            {

                // Ex: change direction every delay seconds
                if (delayCount % delay == 0)
                {
                    Behavior(gameTime);
                }

                delayCount++;
            }

            Death();
            
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
                    WallBehavior();
                    break;
                case ICollidable.ObjectType.Boomerang:
                    BoomerangBehavior();
                    break;
            }
        }
        

        public Rectangle GetHitBox()
        {
            return new Rectangle((int) Physics.CurrentPosition.X, (int) Physics.CurrentPosition.Y, Sprite.GetWidth(), Sprite.GetHeight());
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Health.Dead())
            {
                EnemySpriteFactory.Instance.CreateEnemyExplosionSprite().Draw(spriteBatch, Physics.CurrentPosition, SpriteEffects.None, Color.White);
                deadCount++;
            }
            else
            {
                Sprite.Draw(spriteBatch, Physics.CurrentPosition, SpriteEffects.None, Health.Color);
            }
        }

        public void Reset()
        {
            Physics.Reset();
            Health.Reset();
            deadCount = 0;
        }
    }
}
