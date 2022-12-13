using System;
using Microsoft.Xna.Framework;
using sprint0.Utility;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;

namespace sprint0.Enemies
{
    public class TrapEnemy : Enemy
    {
        private const int BehaviorDelay = 15;
        private const int ReduceSpeed = 3;
        private const int Proximity = 5;
        private const int TrapHealth = 1;
        private const int UpperBound = 120;
        private const int TrapDamage = 1;

        private IPlayer player;
        private bool ready;

        public TrapEnemy(Vector2 position, float speed, IPlayer player)
        {
            Sprite = EnemySpriteFactory.Instance.CreateTrapSprite();
            behaviorTimer = new Timer(BehaviorDelay);
            deathTimer = new Timer(DeathFrames);
            Physics = new PhysicsManager(position, Direction.None, speed);
            Health = new HealthManager(TrapHealth, sound);
            Damage = TrapDamage;
            this.player = player;
            ready = true;
            Type = ICollidable.ObjectType.Trap;
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            switch (obj.Type)
            {
                case ICollidable.ObjectType.Wall:
                case ICollidable.ObjectType.Tile:
                case ICollidable.ObjectType.Door:
                    Physics.Freeze();
                    ready = false;
                    break;
                case ICollidable.ObjectType.Player:
                    ready = false;
                    break;
            }
        }

        private void AdjustDirection(float diffX, float diffY)
        {
            if (diffX < 0)
            {
                Physics.ChangeDirection(Direction.Right);
            }
            else if (diffX > 0)
            {
                Physics.ChangeDirection(Direction.Left);
            }
            else if (diffY < 0)
            {
                Physics.ChangeDirection(Direction.Down);
            }
            else if (diffY > 0)
            {
                Physics.ChangeDirection(Direction.Up);
            }
        }

        private void ReturnToSpawn(GameTime gameTime)
        {
            Vector2 diffs = Physics.DifferenceFromStart();
            double diff = Math.Sqrt(diffs.X * diffs.X + diffs.Y * diffs.Y);

            AdjustDirection(diffs.X, diffs.Y);

            if (diff < UpperBound && diff > Proximity)
            {
                if (Physics.Speed >= ReduceSpeed) Physics.Accelerate(gameTime);
            } else if (diff < Proximity)
            {
                Physics.Reset();
            }     
        }

        protected override void Behavior(GameTime gameTime)
        {
            Vector2 playerPos = new Vector2(player.Position.X, player.Position.Y);

            int playerW = player.GetHitBox().Width;
            int playerH = player.GetHitBox().Height;
            int trapW = GetHitBox().Width;
            int trapH = GetHitBox().Height;

            bool xAlignTop = Physics.InitPosition.Y < playerPos.Y && Physics.InitPosition.Y + trapH > playerPos.Y;
            bool xAlignBottom = Physics.InitPosition.Y < playerPos.Y + playerH && Physics.InitPosition.Y + trapH > playerPos.Y + playerH;

            bool yAlignLeft = Physics.InitPosition.X < playerPos.X && Physics.InitPosition.X + trapW > playerPos.X;
            bool yAlignRight = Physics.InitPosition.X < playerPos.X + playerW && Physics.InitPosition.X + trapW > playerPos.X + playerW;

            if (Physics.DifferenceFromStart() == Vector2.Zero && !ready)
            {
                Physics.Reset();
                ready = true;               
            }
            else if (Physics.DifferenceFromStart() != Vector2.Zero && !ready)
            {
                ReturnToSpawn(gameTime);
            }
            else if ((xAlignTop || xAlignBottom) && Physics.CurrentVelocity.Y == 0)
            {
                Physics.ChangeDirection(Direction.Right);
                if (Physics.CurrentPosition.X > playerPos.X) Physics.CurrentVelocity *= -1;
            }
            else if ((yAlignLeft || yAlignRight) && Physics.CurrentVelocity.X == 0)
            {
                Physics.ChangeDirection(Direction.Down);
                if (Physics.CurrentPosition.Y > playerPos.Y) Physics.CurrentVelocity *= -1;
            }
            else if (ready && Physics.CurrentVelocity != Vector2.Zero)
            {
                ready = false;
            }
        }
    }
}
