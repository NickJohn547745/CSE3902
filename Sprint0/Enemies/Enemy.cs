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
    public abstract class Enemy : IEnemy
    {

        protected int health;
        protected int maxHealth { get; set; }
        protected int damage { get; set; }
        protected int frameDelay;
        protected Vector2 position { get; set; }
        protected Vector2 initPosition;
        protected float speed;
        public Vector2 velocity { get; set; }
        public BasicEnemySprite sprite { get; set; }

        protected abstract void Behavior();

        public void Update(GameTime gameTime, Game1 game)
        {
            this.position += this.speed * this.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (this.position.X < 0 || this.position.Y < 0 || this.position.X > game.GetWindowWidth() || this.position.Y > game.GetWindowHeight())
            {
                this.position = this.initPosition;
            }

            // change direction every 2 seconds
            if (gameTime.TotalGameTime.Seconds % this.frameDelay == 0)
            {
                Behavior();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }

    }
}
