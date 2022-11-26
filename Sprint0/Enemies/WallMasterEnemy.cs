using System;
using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;

namespace sprint0.Enemies
{
    public class WallMasterEnemy : Enemy
    {
        private const int BehaviorDelay = 50;
        private const int WallMasterHealth = 3;

        public WallMasterEnemy(Vector2 position, float speed)
        {
            Sprite = EnemySpriteFactory.Instance.CreateWallMasterSprite();
            delay = BehaviorDelay;
            Physics = new PhysicsManager(position, Direction.None, speed);
            Health = new HealthManager(WallMasterHealth, sound);
            Damage = 1;
            deadCount = 0;
            type = ICollidable.ObjectType.Enemy;
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            switch (obj.type)
            {
                case ICollidable.ObjectType.Sword:
                case ICollidable.ObjectType.Ability:
                    Health.TakeDamage(obj.Damage);
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
