using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Projectiles;
using sprint0.Interfaces;

namespace sprint0.Enemies
{
    public class GoriyaStateMachine
    {
        private const int DirectionChange = 4;

        public GoriyaEnemy Goriya { get; set; }
        public Direction GoriyaDirection { get; private set; }
        public SpriteEffects SpriteEffect { get; private set; }
        public bool BoomerangThrown { get; set; }
        public GoriyaProjectile Boomerang { get; set; }
        public bool flipped { private get; set; }

        public GoriyaStateMachine(GoriyaEnemy goriya)
        {
            Goriya = goriya;            
            BoomerangThrown = false;
            SpriteEffect = SpriteEffects.None;
            flipped = false;
        }

        private int Flip()
        {
            int flip = 0;
            switch (GoriyaDirection)
            {
                case Direction.Up:
                    // move down
                    flip = 3;
                    break;
                case Direction.Left:
                    // move right
                    flip = 2;
                    break;
                case Direction.Right:
                    // move left
                    flip = 1;
                    break;
            }
            return flip;
        }
        
        public void ChangeDirection()
        {
                Random rand = new Random();
                int dir = rand.Next(0, DirectionChange);
                if (flipped) dir = Flip();
                // randomly choose direction
                switch (dir)
                {
                    case 0:
                        // move up
                        GoriyaDirection = Direction.Up;
                        Goriya.Velocity = new Vector2(0, -1);
                        Goriya.Sprite = EnemySpriteFactory.Instance.CreateGoriyaFacingUpStateSprite();
                        SpriteEffect = SpriteEffects.FlipHorizontally;
                        break;
                    case 1:
                        // move left
                        GoriyaDirection = Direction.Left;
                        Goriya.Velocity = new Vector2(-1, 0);
                        Goriya.Sprite = EnemySpriteFactory.Instance.CreateGoriyaFacingSideStateSprite();
                        SpriteEffect = SpriteEffects.FlipHorizontally;
                        break;
                    case 2:
                        // move right
                        GoriyaDirection = Direction.Right;
                        Goriya.Velocity = new Vector2(1, 0);
                        Goriya.Sprite = EnemySpriteFactory.Instance.CreateGoriyaFacingSideStateSprite();
                        SpriteEffect = SpriteEffects.None;
                        break;
                    case 3:
                        // move down
                        GoriyaDirection = Direction.Down;
                        Goriya.Velocity = new Vector2(0, 1);
                        Goriya.Sprite = EnemySpriteFactory.Instance.CreateGoriyaFacingDownStateSprite();
                        SpriteEffect = SpriteEffects.FlipHorizontally;
                        break;
                }

                flipped = false;
        }

        public void ThrowBoomerang()
        {
            Boomerang = new GoriyaProjectile(Goriya.Position, Goriya.Velocity, this);
            Goriya.Velocity = Vector2.Zero;
            BoomerangThrown = true;
        }
    }
}
