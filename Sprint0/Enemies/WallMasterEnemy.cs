using System;
using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.Utility;

namespace sprint0.Enemies
{
    public class WallMasterEnemy : Enemy
    {
        private const int BehaviorDelay = 50;
        private const int WallMasterHealth = 3;
        private const int WallMasterDamage = 1;

        public WallMasterEnemy(Vector2 position, float speed)
        {
            Sprite = EnemySpriteFactory.Instance.CreateWallMasterSprite();
            behaviorTimer = new Timer(BehaviorDelay);
            deathTimer = new Timer(DeathFrames);
            Physics = new PhysicsManager(position, Direction.None, speed);
            health = new HealthManager(WallMasterHealth, sound);
            Damage = WallMasterDamage;
            Type = ICollidable.ObjectType.Enemy;
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            switch (obj.Type)
            {
                case ICollidable.ObjectType.Sword:
                case ICollidable.ObjectType.Ability:
                    health.TakeDamage(obj.Damage);
                    break;
                case ICollidable.ObjectType.Wall:
                case ICollidable.ObjectType.Tile:
                case ICollidable.ObjectType.Door:
                    Physics.ReverseDirection();
                    // canMove = false;
                    break;
                case ICollidable.ObjectType.Boomerang:
                    break;
            }
        }

        protected override void Behavior(GameTime gameTime)
        {

        }
    }
}
