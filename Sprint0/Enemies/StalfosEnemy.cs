using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;

namespace sprint0.Enemies
{
    public class StalfosEnemy : Enemy
    {
        private const int BehaviorDelay = 50;
        private const int RandBound = 4;
        private const int StalfosHealth = 2;
        
        public StalfosEnemy(Vector2 position, float speed)
        {
            Sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            delay = BehaviorDelay;
            Physics = new PhysicsManager(position, Direction.None, speed);
            Health = new HealthManager(StalfosHealth, sound);
            Damage = 1;
            
            InitEnemyFields();
        }

        protected override void BoomerangBehavior()
        {
            Physics.Stun();
        }
        
        protected override void Behavior(GameTime gameTime)
        {
            // randomly choose movement direction
            int direction = rand.Next(0, RandBound);
            Physics.ChangeDirection((Direction)direction);
        }
    }
}
