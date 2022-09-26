using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Sprites;

namespace sprint0.Enemies
{
    public class Stalfos : IEnemy
    {

        private int health;
        private int damage;
        private Vector2 position;
        private Vector2 initPosition;
        private Vector2 speed;
        private Vector2 velocity;
        private EnemySprite sprite;


        public Stalfos(Vector2 position, Vector2 speed)
        {
            this.initPosition = position;
            this.position = position;
            sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            this.speed = speed;
            velocity = new Vector2(1, 0);
        }

        public void SetHealth(int health)
        {
            this.health = health;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public int GetAttackDamage()
        {
            return this.damage;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        private void ChooseDirection()
        {
            Random rand = new Random();

            // randomly choose movement direction
            switch (rand.Next(0, 3))
            {
                case 0:
                    // move up
                    velocity.Y = -1;
                    velocity.X = 0;
                    break;
                case 1:
                    // move left
                    velocity.Y = 0;
                    velocity.X = -1;
                    break;
                case 2:
                    // move right
                    velocity.Y = 0;
                    velocity.X = 1;
                    break;
                case 3:
                    // move down
                    velocity.Y = 1;
                    velocity.X = 0;
                    break;
                default:
                    break;    
            }
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            // change direction every 2 seconds
            if (gameTime.TotalGameTime.Seconds % 2 == 0)
            {
                ChooseDirection();
            }

            position.X += speed.X * velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += speed.Y * velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.X < 0 || position.Y < 0 || position.X > game.GetWindowWidth() || position.Y > game.GetWindowHeight())
            {
                position = initPosition;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }

    }
}
