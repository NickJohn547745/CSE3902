using System;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Factories;
using sprint0.Managers;
using sprint0.Utility;

namespace sprint0.Enemies
{
    public class AquamentusBoss: Enemy
    {
        private const int BehaviorDelay = 60;
        private const int FireBallShoot = 3;
        private const int FireBallOffsetY = 30;
        private const float FireBallDirection = (float) 2/3;
        private const int RandBound = 3;
        private const int AquamentusHealth= 6;

        private int fireBallTracker;

        public AquamentusBoss(Vector2 position, float speed)
        {
            Sprite = EnemySpriteFactory.Instance.CreateAquamentusSprite();
            behaviorTimer = new Timer(BehaviorDelay);
            fireBallTracker = 1;
            Physics = new PhysicsManager(position, Direction.Left, speed);
            Health = new HealthManager(AquamentusHealth, sound);
            Damage = 1;
            deadCount = 0;
            Type = ICollidable.ObjectType.Enemy;
        }

        protected override void Behavior(GameTime gameTime)
        {
            Random random = new Random();
            if (random.Next(0, RandBound) != 0) Physics.ReverseDirection();
            
            // shoot fireballs
            if (fireBallTracker % FireBallShoot == 0)
            {
                Vector2 fireBallSpawn = Physics.CurrentPosition;
                fireBallSpawn.Y += FireBallOffsetY;
                CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, FireBallDirection)));
                CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, 0)));
                CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, -FireBallDirection))); 
            }
            fireBallTracker++;
        }
    }
}
