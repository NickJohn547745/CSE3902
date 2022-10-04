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
    public class KeeseEnemy : Enemy
    {
        private int previous = 1;
        public KeeseEnemy(Vector2 position, float speed)
        {
            this.initPosition = position;
            this.position = position;
            this.sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            this.speed = speed;
            this.velocity = Vector2.One;
            this.delay = 40;
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            Random rand = new Random();
            Random rand2 = new Random();

            // randomly choose movement direction
            int x = rand.Next(-1, 2) % 2;
            int y = rand2.Next(-1, 2) % 2;
            if (x == 0 && y == 0) x = previous *= -1;
            velocity = new Vector2 (x, y);
        }
    }
}
