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
using Microsoft.Xna.Framework.Audio;

namespace sprint0.Enemies
{
    public class GoriyaEnemy: Enemy
    {
        private const int behaviorDelay = 40;
        private const int directionChange = 4;

        private GoriyaStateMachine goriyaStateMachine;
        private int boomerangTracker;

        public GoriyaEnemy(Vector2 position, float speed)
        {
            initPosition = position;
            this.position = position;
            this.speed = speed;
            velocity = Vector2.Zero;
            delay = behaviorDelay;
            boomerangTracker = 1;
            goriyaStateMachine = new GoriyaStateMachine(this);
            goriyaStateMachine.ChangeDirection();
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            // change direction 4 times
            if (boomerangTracker % directionChange == 0)
            {
                // throw boomerang
                goriyaStateMachine.ThrowBoomerang();
                game.Projectiles.Add(goriyaStateMachine.boomerang);
                boomerangTracker++;
            } else if (!goriyaStateMachine.boomerangThrown)
            {
                game.Projectiles.Remove(goriyaStateMachine.boomerang);
                goriyaStateMachine.boomerang = null;

                // change direction
                goriyaStateMachine.ChangeDirection();
                boomerangTracker++;
            }      
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position, goriyaStateMachine.spriteEffect);
        }
    }
}
