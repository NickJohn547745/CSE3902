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
    public class StalfosEnemy : Enemy
    {

        public StalfosEnemy(Vector2 position, float speed)
        {
            this.initPosition = position;
            this.position = position;
            this.sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            this.speed = speed;
            this.velocity = Vector2.Zero;
            this.delay = 20;
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            Random rand = new Random();

            // randomly choose movement direction
            switch (rand.Next(0, 4))
            {
                case 0:
                    // move up
                    this.velocity = new Vector2(0, -1);
                    break;
                case 1:
                    // move left
                    this.velocity = new Vector2(-1, 0);
                    break;
                case 2:
                    // move right
                    this.velocity = new Vector2(1, 0);
                    break;
                case 3:
                    // move down
                    this.velocity = new Vector2(0, 1);
                    break;
                default:
                    break;    
            }
        }
    }
}
