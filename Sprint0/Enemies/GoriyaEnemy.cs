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

        private GoriyaStateMachine goriyaStateMachine;
        private Timer boomerangTracker;

        public GoriyaEnemy(Vector2 position, float speed)
        {
            behaviorTimer = new Timer(BehaviorDelay);
            boomerangTracker = new Timer(DirectionChange);
            Physics = new PhysicsManager(position, Direction.None, speed);
            Health = new HealthManager(GoriyaHealth, sound);
            goriyaStateMachine = new GoriyaStateMachine(this);
            goriyaStateMachine.ChangeDirection(rand);
            Damage = 1;
            deadCount = 0;
            type = ICollidable.ObjectType.Enemy;
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
            if (boomerangTracker.UnconditionalUpdate())
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
            if (deadCount >= DeathFrames)
            {
                CollisionManager.Collidables.Remove(this);
                CollisionManager.Collidables.Remove(goriyaStateMachine.Boomerang);
                goriyaStateMachine.BoomerangThrown = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Health.Dead())
            {
                EnemySpriteFactory.Instance.CreateEnemyExplosionSprite().Draw(spriteBatch, Physics.CurrentPosition, goriyaStateMachine.SpriteEffect, Color.White);
                deadCount++;
            }
            else
            {
                Sprite.Draw(spriteBatch, Physics.CurrentPosition, goriyaStateMachine.SpriteEffect, Health.Color);
            }
        }
    }
}
