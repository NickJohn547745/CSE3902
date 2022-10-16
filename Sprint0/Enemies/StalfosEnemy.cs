using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using sprint0.Factories;

namespace sprint0.Enemies
{
    public class StalfosEnemy : Enemy
    {
        private const int behaviorDelay = 40;
        private const int randBound = 4;

        private Dictionary<int, Vector2> directionChoice;
        public StalfosEnemy(Vector2 position, float speed)
        {
            initPosition = position;
            this.position = position;
            sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            this.speed = speed;
            velocity = Vector2.Zero;
            delay = behaviorDelay;
            health = 2;

            directionChoice = new Dictionary<int, Vector2>();
            directionChoice.Add(0, new Vector2(0, -1));
            directionChoice.Add(1, new Vector2(-1, 0));
            directionChoice.Add(2, new Vector2(1, 0));
            directionChoice.Add(3, new Vector2(0, 1));
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            Random rand = new Random();

            // randomly choose movement direction
            int direction = rand.Next(0, randBound);
            if (directionChoice.ContainsKey(direction)) velocity = directionChoice[direction];
        }
    }
}
