﻿using System;
using Microsoft.Xna.Framework;
using sprint0.Factories;

namespace sprint0.Enemies
{
    public class KeeseEnemy : Enemy
    {
        private const int BehaviorDelay = 40;
        private const int DirectionChange = 2;
        private const int RandBound = 2;

        private int previous;
        public KeeseEnemy(Vector2 position, float speed)
        {
            initPosition = position;
            Position = position;
            Sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            this.speed = speed;
            Velocity = Vector2.One;
            delay = BehaviorDelay;
            previous = 1;
            MaxHealth = 2;
            Health = MaxHealth;
            Damage = 1;
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            Random rand = new Random();
            Random rand2 = new Random();

            // randomly choose movement direction
            int x = rand.Next(-1, RandBound) % DirectionChange;
            int y = rand2.Next(-1, RandBound) % DirectionChange;
            if (x == 0 && y == 0) x = previous *= -1;
            Velocity = new Vector2 (x, y);
        }
    }
}
