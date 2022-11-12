using System;
using Microsoft.Xna.Framework;
using sprint0.Classes;
using sprint0.Interfaces;
using sprint0.Factories;

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
            initPosition = position;
            Position = position;
            PreviousPosition = position;
            this.speed = speed;
            Velocity = new Vector2(1, 0);
            Sprite = EnemySpriteFactory.Instance.CreateAquamentusSprite();
            delay = BehaviorDelay;
            fireBallTracker = 1;
            MaxHealth = AquamentusHealth;
            Damage = 1;
            
            InitEnemyFields();
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            Random random = new Random();
            if (random.Next(0, RandBound) != 0) Velocity *= -1;
            
            // shoot fireballs
            if (fireBallTracker % FireBallShoot == 0)
            {
                Vector2 fireBallSpawn = Position;
                fireBallSpawn.Y += FireBallOffsetY;
                CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, FireBallDirection)));
                CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, 0)));
                CollisionManager.Collidables.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, -FireBallDirection))); 
            }
            fireBallTracker++;
        }
    }
}
