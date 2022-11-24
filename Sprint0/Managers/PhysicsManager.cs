using Microsoft.Xna.Framework;
using sprint0.Interfaces;

namespace sprint0.Managers
{
    public class PhysicsManager
    {
        private const int StunDelay = 80;

        public Vector2 InitPosition { get; private set; }
        private Vector2 initVelocity;
        private float initSpeed;
        private float acceleration;
        private float previousSpeed;
        private int stunCount;
        private Vector2 previousPosition;
        private bool canMove;
        public Direction Direction { get; private set; }
        public float Speed { get; private set;}
        public Vector2 CurrentVelocity { get; set; }
        public Vector2 CurrentPosition { get; set; }


        public PhysicsManager(Vector2 initPos, Direction direction, float speed, float acceleration = 0)
        {
            InitPosition = initPos;
            Direction = direction;
            initSpeed = speed;
            this.acceleration = acceleration;

            ChangeDirection(direction);
            initVelocity = CurrentVelocity;
            Reset();
        }

        public void Stun()
        {
            stunCount++;
        }

        public void Freeze()
        {
            canMove = false;
        }

        public void ChangeDirection(Direction direction)
        {
            Direction = direction;
            switch (direction)
            {
                case Direction.Up:
                    CurrentVelocity = new Vector2(0, -1);
                    break;
                case Direction.Left:
                    CurrentVelocity = new Vector2(-1, 0);
                    break;
                case Direction.Right:
                    CurrentVelocity = new Vector2(1, 0);
                    break;
                case Direction.Down:
                    CurrentVelocity = new Vector2(0, 1);
                    break;
                case Direction.None:
                    CurrentVelocity = Vector2.Zero;
                    break;
            }
        }

        public void ReverseDirection()
        {
            switch (Direction)
            {
                case Direction.Up:
                    Direction = Direction.Down;
                    break;
                case Direction.Left:
                    Direction = Direction.Right;
                    break;
                case Direction.Right:
                    Direction = Direction.Left;
                    break;
                case Direction.Down:
                    Direction = Direction.Up;
                    break;
                default:
                    break;
            }
            CurrentVelocity *= -1;
        }

        public Vector2 DifferenceFromStart()
        {
            return CurrentPosition - InitPosition;
        }

        public void Move(GameTime gameTime)
        {
            if (Stunned())
            {
                if (canMove)
                {
                    previousPosition = CurrentPosition;
                    CurrentPosition += Speed * CurrentVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    CurrentPosition = previousPosition;
                }
            }
            else
            {
                stunCount++;
            }

            canMove = true;
        }

        public void Accelerate(GameTime gameTime)
        {
            if (Stunned())
            {
                if (canMove)
                {
                    previousSpeed = Speed;
                    Speed -= acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    CurrentPosition = previousPosition;
                }
            }
            else
            {
                stunCount++;
            }          
        }

        public bool Stunned()
        {
            return stunCount % StunDelay == 0;
        }

        public void Reset()
        {
            CurrentPosition = InitPosition;
            previousPosition = InitPosition;
            CurrentVelocity = initVelocity;
            Speed = initSpeed;
            previousSpeed = initSpeed;
            stunCount = 0;
            canMove = true;
        }
    }
}
