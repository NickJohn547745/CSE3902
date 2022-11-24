using System.Collections.Generic;
using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;

namespace sprint0.Enemies
{
    public class ZolEnemy : Enemy
    {
        private const int BehaviorDelay = 50;
        private const int RandBound = 6;
        private const int ZolHealth = 1;

        public ZolEnemy(Vector2 position, float speed)
        {
            Sprite = EnemySpriteFactory.Instance.CreateZolSprite();
            delay = BehaviorDelay;
            Damage = 1;
            Physics = new PhysicsManager(position, Direction.None, speed);
            Health = new HealthManager(ZolHealth, sound);
            InitEnemyFields();
        }

        protected override void Behavior(GameTime gameTime)
        {
            // randomly choose movement direction
            int direction = rand.Next(0, RandBound);
            if (direction == RandBound) direction--;
            Physics.ChangeDirection((Direction) direction);         
        }
    }
}
