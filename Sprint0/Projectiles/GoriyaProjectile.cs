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
            type = ICollidable.objectType.Projectile;
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            caught = returnThrow && obj == goriya.Goriya;

            Collision = caught || (obj.type != ICollidable.objectType.Projectile && obj.type != ICollidable.objectType.Enemy);

            if (Collision) goriya.BoomerangThrown = false;
        }

        protected override void Behavior(Game1 game)
        {
            bool xMax = Math.Abs(Position.X - initPosition.X) >= speed * 2;
            bool yMax = Math.Abs(Position.Y - initPosition.Y) >= speed * 2;

            // reverse velocity after 2 seconds
            if (!returnThrow &&  (xMax || yMax)) 
            {
                Velocity *= -1;
                returnThrow = true;
            }

            if (returnThrow && caught) 
            {
                goriya.BoomerangThrown = false;
            }
        }
    }
}
