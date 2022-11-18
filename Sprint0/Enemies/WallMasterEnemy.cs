using System;
using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
namespace sprint0.Enemies
{
    public class WallMasterEnemy : Enemy
    {
        private const int BehaviorDelay = 50;
        private const int WallMasterHealth = 3;

        public WallMasterEnemy(Vector2 position, float speed)
        {
            initPosition = position;
            Position = position;
            PreviousPosition = position;
            Sprite = EnemySpriteFactory.Instance.CreateWallMasterSprite();
            this.speed = speed;
            Velocity = Vector2.One;
            delay = BehaviorDelay;
            MaxHealth = WallMasterHealth;
            Damage = 1;
            
            InitEnemyFields();
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            switch (obj.type)
            {
                case ICollidable.ObjectType.Sword:
                case ICollidable.ObjectType.Ability:
                    TakeDamage(obj.Damage);
                    break;
                case ICollidable.ObjectType.Wall:
                case ICollidable.ObjectType.Tile:
                case ICollidable.ObjectType.Door:
                    ReverseDirection();
                    // canMove = false;
                    break;
                case ICollidable.ObjectType.Boomerang:
                    Stun();
                    break;
            }
        }

        protected override void Behavior(GameTime gameTime)
        {

        }
    }
}
