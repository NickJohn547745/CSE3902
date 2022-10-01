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
    public class Keese : Enemy
    {

        public Keese(Vector2 position, float speed)
        {
            this.initPosition = position;
            this.position = position;
            this.sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            this.speed = speed;
            this.velocity = Vector2.Zero;
            this.frameDelay = 2;
        }

        protected override void Behavior()
        {
            Random rand = new Random();
            Random rand2 = new Random();

            // randomly choose movement direction
            velocity = new Vector2 (rand.Next(-1, 2) % 2, rand2.Next(-1, 2) % 2);
        }
    }
}
