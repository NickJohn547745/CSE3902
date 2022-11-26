using System;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Factories;
using sprint0.Enemies;
using sprint0.Managers;
using sprint0.Utility;

namespace sprint0.Projectiles
{
    public class GoriyaProjectile : PhysicsProjectile
    {
        private const int GoriyaProjSpeed = 100;
        private const int GoriyaProjDelay = 1;

        private GoriyaStateMachine goriya;
        private bool returnThrow;
        private bool caught;

        public GoriyaProjectile(Vector2 position, Direction direction, GoriyaStateMachine thrower)
        {
            Sprite = ProjectileSpriteFactory.Instance.CreateGoriyaProjectileSprite();
            Physics = new PhysicsManager(position, direction, GoriyaProjSpeed);
            behaviorTimer = new Timer(GoriyaProjDelay);
            goriya = thrower;
            returnThrow = false;
            Damage = 1;
            Collision = false;
            caught = false;
            type = ICollidable.ObjectType.Projectile;
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            caught = returnThrow && obj == goriya.Goriya;

            Collision = caught || (obj.type != ICollidable.ObjectType.Projectile && obj.type != ICollidable.ObjectType.Enemy);

            if (Collision) goriya.BoomerangThrown = false;
        }

        protected override void Behavior()
        {
            Vector2 diff = Physics.DifferenceFromStart();
            bool xMax = Math.Abs(diff.X) >= Physics.Speed * 2;
            bool yMax = Math.Abs(diff.Y) >= Physics.Speed * 2;

            // reverse velocity after 2 seconds
            if (!returnThrow &&  (xMax || yMax)) 
            {
                Physics.ReverseDirection();
                returnThrow = true;
            }

            if (returnThrow && caught) 
            {
                goriya.BoomerangThrown = false;
            }
        }
    }
}
