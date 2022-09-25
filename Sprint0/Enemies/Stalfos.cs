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
        private float speed;
        private EnemySprite sprite;


        public Stalfos(Vector2 position)
        {
            this.position = position;
            sprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
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

        public void Update(GameTime gameTime)
        {



        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }

    }
}
