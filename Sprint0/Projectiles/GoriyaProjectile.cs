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
using sprint0.Enemies;
using System.Reflection.Metadata.Ecma335;

namespace sprint0.Projectiles
{
    public class GoriyaProjectile : Projectile
    {
        private const int goriyaProjSpeed = 200;
        private const int goriyaProjDelay = 1;

        private GoriyaStateMachine goriya;
        private Boolean returnThrow;

        public GoriyaProjectile(Vector2 position, Vector2 velocity, GoriyaStateMachine thrower)
        {
            initPosition = position;
            this.position = position;
            sprite = ProjectileSpriteFactory.Instance.CreateGoriyaProjectileSprite();
            this.velocity = velocity;
            speed = goriyaProjSpeed;
            delay = goriyaProjDelay;
            goriya = thrower;
            returnThrow = false;
        }

        private Boolean Caught()
        {
            Boolean output = false;
            if (goriya.goriyaDirection == GoriyaStateMachine.Direction.Up)
            {
                output = position.Y >= initPosition.Y;
            } else if (goriya.goriyaDirection == GoriyaStateMachine.Direction.Down)
            {
                output = position.Y <= initPosition.Y + goriya.goriya.sprite.GetHeight();
            } else if (goriya.goriyaDirection == GoriyaStateMachine.Direction.Left)
            {
                output = position.X >= initPosition.X - goriya.goriya.sprite.GetWidth();
            }
            else if (goriya.goriyaDirection == GoriyaStateMachine.Direction.Right)
            {
                output = position.X <= initPosition.X + goriya.goriya.sprite.GetWidth();
            }

            return output;
        }

        protected override void Behavior(Game1 game)
        {
            Boolean xMax = Math.Abs(position.X - initPosition.X) >= speed;
            Boolean yMax = Math.Abs(position.Y - initPosition.Y) >= speed;

            // reverse velocity after 2 seconds
            if (!returnThrow &&  (xMax || yMax)) 
            {
                velocity *= -1;
                returnThrow = true;
            }
 
            if (returnThrow && Caught())
            {
                goriya.boomerangThrown = false;
            }
        }
    }
}
