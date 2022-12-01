using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Factories;
using sprint0.Sound;
using sprint0.Managers;
using System;
using Microsoft.Xna.Framework.Audio;
using sprint0.Utility;

namespace sprint0.Enemies
{
    public abstract class Enemy : ICollidable
    {
        protected const int TileOffset = 5;
        protected const int DeathFrames = 4;       

        protected static Random rand = new();
        protected readonly SoundEffect sound = SoundManager.Manager.enemyDamageSound();

        public PhysicsManager Physics { get; protected set; }
        protected HealthManager Health;
        protected int deadCount;

        public int Damage { get; set; }
        protected Timer behaviorTimer;
        public ICollidable.ObjectType Type { get; set; }
        public ISprite Sprite { get; set; }

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

            if (Physics.NotStunned())
            {

                Physics.Move(gameTime);

                // Ex: change direction every delay seconds
                if (behaviorTimer.UnconditionalUpdate())
                {
                    Behavior(gameTime);
                }
            }

            Death();
            
        }

        public virtual void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            switch (obj.Type)
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

        public Direction GetMoveDirection()
        {
            return Physics.Direction;
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
            behaviorTimer.Reset();
            deadCount = 0;
        }
    }
}
