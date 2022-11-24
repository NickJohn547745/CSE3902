using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Managers;

namespace sprint0.Enemies
{
    public class StalfosEnemy : Enemy
    {
        private const int BehaviorDelay = 50;
        private const int RandBound = 4;
        private const int StalfosHealth = 2;

        private Dictionary<int, Vector2> DirectionChoice;
        
        public StalfosEnemy(Vector2 position, float speed)
        {
            initPosition = position;
            Position = position;
            PreviousPosition = position;
            Sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            this.speed = speed;
            Velocity = Vector2.Zero;
            delay = BehaviorDelay;
            Health = new HealthManager(StalfosHealth, sound);
            Damage = 1;
            
            InitEnemyFields();

            DirectionChoice = new Dictionary<int, Vector2>();
            DirectionChoice.Add(0, new Vector2(0, -1));
            DirectionChoice.Add(1, new Vector2(-1, 0));
            DirectionChoice.Add(2, new Vector2(1, 0));
            DirectionChoice.Add(3, new Vector2(0, 1));
        }

        protected override void Stun()
        {
            stunCount++;
        }
        
        protected override void Behavior(GameTime gameTime)
        {
            // randomly choose movement direction
            int direction = rand.Next(0, RandBound);
            if (DirectionChoice.ContainsKey(direction)) Velocity = DirectionChoice[direction];
        }
    }
}
