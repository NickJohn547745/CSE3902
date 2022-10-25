using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.Enemies
{
    public class StalfosEnemy : Enemy
    {
        private const int BehaviorDelay = 50;
        private const int RandBound = 4;

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
            MaxHealth = 2;
            Health = MaxHealth;
            Damage = 1;
            deadCount = 0;
            type = ICollidable.objectType.Enemy;

            DirectionChoice = new Dictionary<int, Vector2>();
            DirectionChoice.Add(0, new Vector2(0, -1));
            DirectionChoice.Add(1, new Vector2(-1, 0));
            DirectionChoice.Add(2, new Vector2(1, 0));
            DirectionChoice.Add(3, new Vector2(0, 1));
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            Random rand = new Random();

            // randomly choose movement direction
            int direction = rand.Next(0, RandBound);
            if (DirectionChoice.ContainsKey(direction)) Velocity = DirectionChoice[direction];
        }
    }
}
