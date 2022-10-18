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
        private const int goriyaProjSpeed = 100;
        private const int goriyaProjDelay = 1;

        private GoriyaStateMachine goriya;
        private Boolean returnThrow;
        private bool caught;

        public GoriyaProjectile(Vector2 position, Vector2 velocity, GoriyaStateMachine thrower)
        {
            initPosition = position;
            this.Position = position;
            Sprite = ProjectileSpriteFactory.Instance.CreateGoriyaProjectileSprite();
            Velocity = velocity;
            speed = goriyaProjSpeed;
            delay = goriyaProjDelay;
            goriya = thrower;
            returnThrow = false;
            Damage = 1;
            Collision = false;
            caught = false;
        }

        private Boolean Caught()
        {
            Boolean output = false;
            if (goriya.goriyaDirection == GoriyaStateMachine.Direction.Up)
            {
                output = Position.Y >= initPosition.Y - goriya.goriya.sprite.GetHeight();
            } else if (goriya.goriyaDirection == GoriyaStateMachine.Direction.Down)
            {
                output = Position.Y <= initPosition.Y + goriya.goriya.sprite.GetHeight();
            } else if (goriya.goriyaDirection == GoriyaStateMachine.Direction.Left)
            {
                output = Position.X >= initPosition.X;
            }
            else if (goriya.goriyaDirection == GoriyaStateMachine.Direction.Right)
            {
                output = Position.X <= initPosition.X + goriya.goriya.sprite.GetWidth();
            }

            return output;
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            caught = returnThrow && obj.GetObjectType() == typeof(GoriyaEnemy) ;

            Collision = caught || (Collision = obj.GetObjectType().BaseType != typeof(Projectile) && obj.GetObjectType().BaseType != typeof(Enemy));

            if (Collision) goriya.boomerangThrown = false;
        }

        protected override void Behavior(Game1 game)
        {
            Boolean xMax = Math.Abs(Position.X - initPosition.X) >= speed * 2;
            Boolean yMax = Math.Abs(Position.Y - initPosition.Y) >= speed * 2;

            // reverse velocity after 2 seconds
            if (!returnThrow &&  (xMax || yMax)) 
            {
                Velocity *= -1;
                returnThrow = true;
            }
 
            if (returnThrow && caught) //Caught())
            {
                goriya.boomerangThrown = false;
            }
        }
    }
}
