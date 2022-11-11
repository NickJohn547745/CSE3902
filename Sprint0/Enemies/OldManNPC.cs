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
using sprint0.PlayerClasses;

namespace sprint0.Enemies
{
    public class OldManNPC : Enemy
    {
        private const int OldManHealth = 1000;
        private const int FireBallOffsetY = 30;
        private const float FireBallDirection = (float) 3/4;
        private const int FireBallShoot = 10;
        private const int HUDOffset = 134;
        private const int FireBallScale = 50;
        private const int HitBoxOffset = 20;

        private int fireBallTracker;
        
        public OldManNPC(Vector2 position)
        {
            initPosition = position;
            Position = position;
            Sprite = EnemySpriteFactory.Instance.CreateOldManNPCSprite();
            Velocity = Vector2.Zero;
            delay = 1;
            MaxHealth = OldManHealth;
            fireBallTracker = 1;

            InitEnemyFields();
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            if (Health < OldManHealth)
            {
                Position = new Vector2((game.GetWindowWidth() - GetHitBox().Width ) / 2, (game.GetWindowHeight() - GetHitBox().Height ) / 2 - HUDOffset);
                Vector2 fireBallSpawn = new Vector2(GetHitBox().Center.X - HitBoxOffset, GetHitBox().Center.Y - HitBoxOffset);
                if (fireBallTracker % FireBallShoot == 0)
                {
                    game.CollisionManager.collidables.Add(new AquamentusProjectile(fireBallSpawn,
                        new Vector2(-1, FireBallDirection)));
                    game.CollisionManager.collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, 0)));
                    game.CollisionManager.collidables.Add(new AquamentusProjectile(fireBallSpawn,
                        new Vector2(-1, -FireBallDirection)));
                    game.CollisionManager.collidables.Add(new AquamentusProjectile(fireBallSpawn,
                        new Vector2(1, FireBallDirection)));
                    game.CollisionManager.collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(1, 0)));
                    game.CollisionManager.collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(1, -FireBallDirection)));
                    game.CollisionManager.collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(0, 1)));
                    game.CollisionManager.collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(0, -1)));
                }

                if (fireBallTracker % (FireBallShoot * FireBallScale) == 0)
                {
                    Health = OldManHealth;
                    Position = initPosition;
                }

                fireBallTracker++;
            }
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            switch (obj.type)
            {
                case ICollidable.ObjectType.Player:
                    switch (edge)
                    {
                        case ICollidable.Edge.Top:
                            Position += new Vector2(0, -TileOffset);
                            break;
                        case ICollidable.Edge.Right:
                            Position += new Vector2(-TileOffset, 0);
                            break;
                        case ICollidable.Edge.Left:
                            Position += new Vector2(TileOffset, 0);
                            break;
                        case ICollidable.Edge.Bottom:
                            Position += new Vector2(0, TileOffset);
                            break;
                    }
                    break;
                case ICollidable.ObjectType.Sword:
                case ICollidable.ObjectType.Ability:
                    TakeDamage(obj.Damage);
                    break;
                case ICollidable.ObjectType.Wall: 
                case ICollidable.ObjectType.Door:
                case ICollidable.ObjectType.Tile:
                    switch (edge)
                    {
                        case ICollidable.Edge.Top:
                            Position += new Vector2(0, TileOffset);
                            break;
                        case ICollidable.Edge.Right:
                            Position += new Vector2(TileOffset, 0);
                            break;
                        case ICollidable.Edge.Left:
                            Position += new Vector2(-TileOffset, 0);
                            break;
                        case ICollidable.Edge.Bottom:
                            Position += new Vector2(0, -TileOffset);
                            break;
                    }
                    break;
            }
        }
    }
}
