using System;
using Microsoft.Xna.Framework;
using sprint0.Factories;

namespace sprint0.Enemies
{
    public class KeeseEnemy : Enemy
    {
        private const int behaviorDelay = 40;
        private const int directionChange = 2;
        private const int randBound = 2;

        private int previous;
        public KeeseEnemy(Vector2 position, float speed)
        {
            initPosition = position;
            this.position = position;
            sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            this.speed = speed;
            velocity = Vector2.One;
            delay = behaviorDelay;
            previous = 1;
            health = 2;
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            Random rand = new Random();
            Random rand2 = new Random();

            // randomly choose movement direction
            int x = rand.Next(-1, randBound) % directionChange;
            int y = rand2.Next(-1, randBound) % directionChange;
            if (x == 0 && y == 0) x = previous *= -1;
            velocity = new Vector2 (x, y);
        }
    }
}
