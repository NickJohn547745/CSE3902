using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.Utility;

namespace sprint0.Enemies
{
    public class KeeseEnemy : Enemy
    {
        private const int BehaviorDelay = 50;
        private const int DirectionChange = 2;
        private const int RandBound = 2;
        private const int KeeseHealth = 1;

        private int previous;
        public KeeseEnemy(Vector2 position, float speed)
        {
            Sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            behaviorTimer = new Timer(BehaviorDelay);
            previous = 1;
            Physics = new PhysicsManager(position, Direction.None, speed);
            Health = new HealthManager(KeeseHealth, sound);
            Damage = 1;
            deadCount = 0;
            type = ICollidable.ObjectType.Enemy;
        }

        protected override void BoomerangBehavior()
        {
            Health.TakeDamage(1);
        }

        protected override void Behavior(GameTime gameTime)
        {
            // randomly choose movement direction
            int x = rand.Next(-1, RandBound) % DirectionChange;
            int y = rand.Next(-1, RandBound) % DirectionChange;
            if (x == 0 && y == 0) x = previous;
            Physics.CurrentVelocity = new Vector2 (x, y);
        }
    }
}
