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
        public ZolEnemy(Vector2 position, float speed)
        {
            initPosition = position;
            this.position = position;
            sprite = EnemySpriteFactory.Instance.CreateZolSprite();
            this.speed = speed;
            velocity = Vector2.One;
            delay = 40;
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            Random rand = new Random();

            // randomly choose movement direction
            switch (rand.Next(0, 6))
            {
                case 0:
                    // move up
                    velocity = new Vector2(0, -1);
                    break;
                case 1:
                    // move left
                    velocity = new Vector2(-1, 0);
                    break;
                case 2:
                    // move right
                    velocity = new Vector2(1, 0);
                    break;
                case 3:
                    // move down
                    velocity = new Vector2(0, 1);
                    break;
                case 4:
                case 5:
                    // stop
                    velocity = Vector2.Zero;
                    break;
                default:
                    break;
            }
        }
    }
}
