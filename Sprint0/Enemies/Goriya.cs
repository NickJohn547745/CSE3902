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
    public class Goriya: Enemy
    {

        private IEnemyState EnemyState { get; set; }
        public Boolean stop { get; set; }

        public Goriya(Vector2 position, float speed)
        {
            this.initPosition = position;
            this.position = position;
            this.speed = speed;
            this.velocity = Vector2.Zero;
            this.frameDelay = 2;
            //EnemyState = new GoriyaFacingLeftState(this);
        }

        protected override void Behavior()
        {
            Random rand = new Random();

            // randomly choose movement direction
            switch (rand.Next(0, 4))
            {
                case 0:
                    // move up

                    break;
                case 1:
                    // move left

                    break;
                case 2:
                    // move right

                    break;
                case 3:
                    // move down

                    break;
                default:
                    break;
            }

            EnemyState.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position, new Vector2(-1, 1));

        }
    }
}
