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
    public class Keese : IEnemy
    {

        private int health;
        private int damage;
        private Vector2 position;
        private Vector2 initPosition;
        private float speed;
        private Vector2 velocity;
        private EnemySprite sprite;


        public Keese(Vector2 position, float speed)
        {
            this.initPosition = position;
            this.position = position;
            sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
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
            Random rand2 = new Random();

            // randomly choose movement direction
            velocity.X = rand.Next(-1, 2) % 2;
            velocity.Y = rand2.Next(-1, 2) % 2;
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            // change direction every 2 seconds
            if (gameTime.TotalGameTime.Seconds % 2 == 0)
            {
                ChooseDirection();
            }

            position += speed * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

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
