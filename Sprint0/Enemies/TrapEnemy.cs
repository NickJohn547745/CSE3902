using System;
using Microsoft.Xna.Framework;
using sprint0.PlayerClasses;
using sprint0.Factories;
using sprint0.Interfaces;
namespace sprint0.Enemies
{
    public class TrapEnemy : Enemy
    {
        private const int BehaviorDelay = 15;
        private const int ReduceSpeed = 3;
        private const float Acceleration = 20;
        private const int Proximity = 5;

        private IPlayer player;
        private bool ready;
        private float initSpeed;

        public TrapEnemy(Vector2 position, float speed, IPlayer player)
        {
            initPosition = position;
            Position = position;
            PreviousPosition = position;
            Sprite = EnemySpriteFactory.Instance.CreateTrapSprite();
            this.speed = speed;
            initSpeed = speed;
            Velocity = Vector2.Zero;
            delay = BehaviorDelay;
            MaxHealth = 1;
            Damage = 1;
            this.player = player;
            ready = true;
            
            InitEnemyFields();
            type = ICollidable.ObjectType.Trap;
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            switch (obj.type)
            {
                case ICollidable.ObjectType.Wall:
                case ICollidable.ObjectType.Tile:
                case ICollidable.ObjectType.Door:
                    canMove = false;
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
                Velocity = new Vector2(1, Velocity.Y);
            }
            else if (diffX > 0)
            {
                Velocity = new Vector2(-1, Velocity.Y);
            }

            if (diffY < 0)
            {
                Velocity = new Vector2(Velocity.X, 1);
            }
            else if (diffY > 0)
            {
                Velocity = new Vector2(Velocity.X, -1);
            }
        }

        private void ReturnToSpawn(GameTime gameTime)
        {
            float diffX = Position.X - initPosition.X;
            float diffY = Position.Y - initPosition.Y;
            double diff = Math.Sqrt(diffX * diffX + diffY * diffY);

            AdjustDirection(diffX, diffY);

            if (diff < initSpeed && diff > Proximity)
            {
                if (speed >= ReduceSpeed);
                    speed -= Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            } else if (diff < Proximity)
            {
                Position = initPosition;
                Velocity = Vector2.Zero;
            }     
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            Vector2 playerPos = new Vector2(player.Position.X, player.Position.Y);

            int playerW = player.GetHitBox().Width;
            int playerH = player.GetHitBox().Height;
            int trapW = GetHitBox().Width;
            int trapH = GetHitBox().Height;

            bool xAlignTop = initPosition.Y < playerPos.Y && initPosition.Y + trapH > playerPos.Y;
            bool xAlignBottom = initPosition.Y < playerPos.Y + playerH && initPosition.Y + trapH > playerPos.Y + playerH;

            bool yAlignLeft = initPosition.X < playerPos.X && initPosition.X + trapW > playerPos.X;
            bool yAlignRight = initPosition.X < playerPos.X + playerW && initPosition.X + trapW > playerPos.X + playerW;

            if (Position == initPosition && !ready)
            {
                speed = initSpeed;
                ready = true;
                Velocity = Vector2.Zero;
            }
            else if (Position != initPosition && !ready)
            {
                ReturnToSpawn(gameTime);
            }
            else if ((xAlignTop || xAlignBottom) && Velocity.Y == 0)
            {
                Velocity = new Vector2(1, 0);
                if (Position.X > playerPos.X) Velocity *= -1;
            }
            else if ((yAlignLeft || yAlignRight) && Velocity.X == 0)
            {
                Velocity = new Vector2(0, 1);
                if (Position.Y > playerPos.Y) Velocity *= -1;
            }
            else if (ready && Velocity != Vector2.Zero)
            {
                ready = false;
            }
        }
    }
}
