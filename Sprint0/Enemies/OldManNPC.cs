using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Factories;
using sprint0.Managers;
using sprint0.Projectiles;
using sprint0.Utility;

namespace sprint0.Enemies
{
    public class OldManNPC : Enemy
    {
        private const int OldManHealth = 1000;
        private const float FireBallDirection = (float) 3/4;
        private const int FireBallShoot = 10;
        private const int HUDOffset = 134;
        private const int FireBallEnd = 500;
        private const int HitBoxOffset = 20;

        private Timer fireBallTracker;
        private Timer fireBallStop;
        
        public OldManNPC(Vector2 position)
        {
            Sprite = EnemySpriteFactory.Instance.CreateOldManNPCSprite();
            behaviorTimer = new Timer(1);
            deathTimer = new Timer(DeathFrames);
            Physics = new PhysicsManager(position, Direction.None, 0);
            Health = new HealthManager(OldManHealth, sound);
            fireBallTracker = new Timer(FireBallShoot);
            fireBallStop = new Timer(FireBallEnd);
            deadCount = 0;
            Type = ICollidable.ObjectType.Enemy;
        }

        protected override void Behavior(GameTime gameTime)
        {
            if (Health.CurrentHealth < OldManHealth)
            {
                Physics.CurrentPosition = new Vector2((Game1.WindowWidth - GetHitBox().Width ) / 2, (Game1.WindowHeight - GetHitBox().Height ) / 2 - HUDOffset);
                Vector2 fireBallSpawn = new Vector2(GetHitBox().Center.X - HitBoxOffset, GetHitBox().Center.Y - HitBoxOffset);
                if (fireBallTracker.UnconditionalUpdate() && fireBallTracker.HasStarted())
                {
                    CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, FireBallDirection)));
                    CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, 0)));
                    CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, -FireBallDirection)));
                    CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(1, FireBallDirection)));
                    CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(1, 0)));
                    CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(1, -FireBallDirection)));
                    CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(0, 1)));
                    CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(0, -1)));
                }

                if (fireBallStop.UnconditionalUpdate() && fireBallStop.HasStarted())
                {
                    Health.Reset();
                    Physics.Reset();
                    fireBallStop.Reset();
                    fireBallTracker.Reset();
                }
            }
        }
    }
}
