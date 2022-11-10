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
using sprint0.Classes;

namespace sprint0.Enemies
{
    public class GoriyaEnemy: Enemy
    {
        private const int BehaviorDelay = 70;
        private const int DirectionChange = 4;
        private const int GoriyaHealth = 3;

        private GoriyaStateMachine goriyaStateMachine;
        private int boomerangTracker;

        public GoriyaEnemy(Vector2 position, float speed)
        {
            initPosition = position;
            Position = position;
            PreviousPosition = position;
            this.speed = speed;
            Velocity = Vector2.Zero;
            delay = BehaviorDelay;
            boomerangTracker = 1;
            goriyaStateMachine = new GoriyaStateMachine(this);
            goriyaStateMachine.ChangeDirection();
            MaxHealth = GoriyaHealth;
            Health = MaxHealth;
            Damage = 1;
            damageDelay = 0;
            damaged = false;
            color = Color.White;
            deadCount = 0;
            type = ICollidable.objectType.Enemy;
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
                game.CollisionManager.collidables.Add(goriyaStateMachine.Boomerang);
                boomerangTracker++;
            } else if (!goriyaStateMachine.BoomerangThrown)
            {
                // change direction
                goriyaStateMachine.ChangeDirection();
                boomerangTracker++;
            }      
        }

        protected override void Death(CollisionManager manager)
        {
            if (deadCount >= DeathFrames)
            {
                manager.collidables.Remove(this);
                manager.collidables.Remove(goriyaStateMachine.Boomerang);
                goriyaStateMachine.BoomerangThrown = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Health <= 0)
            {
                EnemySpriteFactory.Instance.CreateEnemyExplosionSprite().Draw(spriteBatch, Position, goriyaStateMachine.SpriteEffect, Color.White);
                deadCount++;
            }
            else
            {
                Sprite.Draw(spriteBatch, Position, goriyaStateMachine.SpriteEffect, color);
            }
        }
    }
}
