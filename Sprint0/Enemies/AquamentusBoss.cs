using System;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Factories;

namespace sprint0.Enemies
{
    public class AquamentusBoss: Enemy
    {
        private const int behaviorDelay = 60;
        private const int fireBallShoot = 3;
        private const int fireBallOffsetY = 30;
        private const float fireBallDirection = (float) 2/3;
        private const int randBound = 3;

        private int fireBallTracker;

        public AquamentusBoss(Vector2 position, float speed)
        {
            initPosition = position;
            this.position = position;
            this.speed = speed;
            velocity = new Vector2(1, 0);
            sprite = EnemySpriteFactory.Instance.CreateAquamentusSprite();
            delay = behaviorDelay;
            fireBallTracker = 1;
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            Random random = new Random();
            if (random.Next(0, randBound) != 0) velocity *= -1;
            
            // shoot fireballs
            if (fireBallTracker % fireBallShoot == 0)
            {
                Vector2 fireBallSpawn = position;
                fireBallSpawn.Y += fireBallOffsetY;
                game.Projectiles.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, fireBallDirection)));
                game.Projectiles.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, 0)));
                game.Projectiles.Add(new AquamentusProjectile(fireBallSpawn, new Vector2(-1, -fireBallDirection))); 
            }
            fireBallTracker++;
        }
    }
}
