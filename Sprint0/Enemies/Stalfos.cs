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
    public class Stalfos : Enemy
    {

        public Stalfos(Vector2 position, float speed)
        {
            this.initPosition = position;
            this.position = position;
            this.sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            this.speed = speed;
            this.velocity = new Vector2(1, 0);
            this.frameDelay = 2;
        }

        protected override void Behavior()
        {
            Random rand = new Random();

            // randomly choose movement direction
            switch (rand.Next(0, 4))
            {
                case 0:
                    // move up
                    this.velocity.Y = -1;
                    this.velocity.X = 0;
                    break;
                case 1:
                    // move left
                    this.velocity.Y = 0;
                    this.velocity.X = -1;
                    break;
                case 2:
                    // move right
                    this.velocity.Y = 0;
                    this.velocity.X = 1;
                    break;
                case 3:
                    // move down
                    this.velocity.Y = 1;
                    this.velocity.X = 0;
                    break;
                default:
                    break;    
            }
        }
    }
}
