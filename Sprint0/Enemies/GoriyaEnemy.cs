using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Factories;
using sprint0.Managers;
using sprint0.Utility;

namespace sprint0.Enemies
{
    public class GoriyaEnemy: Enemy
    {
        private const int BehaviorDelay = 70;
        private const int DirectionChange = 4;
        private const int GoriyaHealth = 3;
        private const int GoriyaDamage = 1;

        private GoriyaStateMachine goriyaStateMachine;
        private Timer boomerangTracker;

        public GoriyaEnemy(Vector2 position, float speed)
        {
            behaviorTimer = new Timer(BehaviorDelay);
            boomerangTracker = new Timer(DirectionChange);
            deathTimer = new Timer(DeathFrames);
            Physics = new PhysicsManager(position, Direction.None, speed);
            health = new HealthManager(GoriyaHealth, sound);
            goriyaStateMachine = new GoriyaStateMachine(this);
            goriyaStateMachine.ChangeDirection(rand);
            Damage = GoriyaDamage;
            Type = ICollidable.ObjectType.Enemy;
        }

        protected override void WallBehavior()
        {
            goriyaStateMachine.flipped = true;
            Physics.Freeze();
        }
        
        protected override void BoomerangBehavior()
        {
            Physics.Stun();
        }

        protected override void Behavior(GameTime gameTime)
        {
            // change direction 4 times
            if (boomerangTracker.ConditionalUpdate(!goriyaStateMachine.BoomerangThrown || boomerangTracker.Status()))
            {
                // throw boomerang
                goriyaStateMachine.ThrowBoomerang();
                CollisionManager.Collidables.Add(goriyaStateMachine.Boomerang);
            } else if (!goriyaStateMachine.BoomerangThrown)
            {
                // change direction
                goriyaStateMachine.ChangeDirection(rand);
            }      
        }

        protected override void Death()
        {
            if (deathTimer.Status() && deathTimer.HasStarted())
            {
                CollisionManager.Collidables.Remove(this);
                CollisionManager.Collidables.Remove(goriyaStateMachine.Boomerang);
                goriyaStateMachine.BoomerangThrown = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!deathTimer.ConditionalUpdate(health.Dead()))
            {
                EnemySpriteFactory.Instance.CreateEnemyExplosionSprite().Draw(spriteBatch, Physics.CurrentPosition, goriyaStateMachine.SpriteEffect, Color.White);
            }
            else
            {
                Sprite.Draw(spriteBatch, Physics.CurrentPosition, goriyaStateMachine.SpriteEffect, health.Color);
            }
        }
    }
}
