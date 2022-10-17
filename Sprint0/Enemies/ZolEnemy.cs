using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Sprites;
using sprint0.Factories;

namespace sprint0.Enemies
{
    public class ZolEnemy : Enemy
    {
        private const int behaviorDelay = 40;
        private const int randBound = 6;

        private Dictionary<int, Vector2> directionChoice;

        public ZolEnemy(Vector2 position, float speed)
        {
            initPosition = position;
            this.position = position;
            sprite = EnemySpriteFactory.Instance.CreateZolSprite();
            this.speed = speed;
            velocity = Vector2.One;
            delay = behaviorDelay;
            maxHealth = 2;
            health = maxHealth;
            Damage = 1;

            directionChoice = new Dictionary<int, Vector2>();
            directionChoice.Add(0, new Vector2(0, -1));
            directionChoice.Add(1, new Vector2(-1, 0));
            directionChoice.Add(2, new Vector2(1, 0));
            directionChoice.Add(3, new Vector2(0, 1));
            directionChoice.Add(4, Vector2.Zero);
            directionChoice.Add(5, Vector2.Zero);
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
