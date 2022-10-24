using System;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Factories;
using sprint0.Enemies;

namespace sprint0.Projectiles
{
    public class GoriyaProjectile : Projectile
    {
        private const int GoriyaProjSpeed = 100;
        private const int GoriyaProjDelay = 1;

        private GoriyaStateMachine goriya;
        private Boolean returnThrow;
        private bool caught;

        public GoriyaProjectile(Vector2 position, Vector2 velocity, GoriyaStateMachine thrower)
        {
            initPosition = position;
            Position = position;
            Sprite = ProjectileSpriteFactory.Instance.CreateGoriyaProjectileSprite();
            Velocity = velocity;
            speed = GoriyaProjSpeed;
            delay = GoriyaProjDelay;
            goriya = thrower;
            returnThrow = false;
            Damage = 1;
            Collision = false;
            caught = false;
        }

        private Boolean Caught()
        {
            Boolean output = false;
            if (goriya.GoriyaDirection == GoriyaStateMachine.Direction.Up)
            {
                output = Position.Y >= initPosition.Y - goriya.Goriya.Sprite.GetHeight();
            } else if (goriya.GoriyaDirection == GoriyaStateMachine.Direction.Down)
            {
                output = Position.Y <= initPosition.Y + goriya.Goriya.Sprite.GetHeight();
            } else if (goriya.GoriyaDirection == GoriyaStateMachine.Direction.Left)
            {
                output = Position.X >= initPosition.X;
            }
            else if (goriya.GoriyaDirection == GoriyaStateMachine.Direction.Right)
            {
                output = Position.X <= initPosition.X + goriya.Goriya.Sprite.GetWidth();
            }

            return output;
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            caught = returnThrow && obj == goriya.Goriya;

            Collision = caught || (Collision = obj.GetObjectType() != typeof(Projectile) && obj.GetObjectType() != typeof(Enemy));

            if (Collision) goriya.BoomerangThrown = false;
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
                goriya.BoomerangThrown = false;
            }
        }
    }
}
