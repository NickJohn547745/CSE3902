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
        private const int BehaviorDelay = 60;
        private const int DirectionChange = 4;

        private GoriyaStateMachine goriyaStateMachine;
        private int boomerangTracker;

        public GoriyaEnemy(Vector2 position, float speed)
        {
            initPosition = position;
            Position = position;
            this.speed = speed;
            Velocity = Vector2.Zero;
            delay = BehaviorDelay;
            boomerangTracker = 1;
            goriyaStateMachine = new GoriyaStateMachine(this);
            goriyaStateMachine.ChangeDirection();
            MaxHealth = 3;
            Health = MaxHealth;
            Damage = 1;
            deadCount = 0;
        }
        
        protected override void ReverseDirection()
        {
            goriyaStateMachine.flipped = true;
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            // change direction 4 times
            if (boomerangTracker % DirectionChange == 0)
            {
                // throw boomerang
                goriyaStateMachine.ThrowBoomerang();
                game.CollidableList.Add(goriyaStateMachine.Boomerang);
                boomerangTracker++;
            } else if (!goriyaStateMachine.BoomerangThrown)
            {
                // change direction
                goriyaStateMachine.ChangeDirection();
                boomerangTracker++;
            }      
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Health <= 0)
            {
                EnemySpriteFactory.Instance.CreateEnemyExplosionSprite().Draw(spriteBatch, FinalPosition, goriyaStateMachine.SpriteEffect, Color.White);
                deadCount++;
            }
            else
            {
                Sprite.Draw(spriteBatch, FinalPosition, goriyaStateMachine.SpriteEffect, Color.White);
            }
        }
    }
}
