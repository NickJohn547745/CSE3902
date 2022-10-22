﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Sprites;
using sprint0.Factories;
using sprint0.Projectiles;

namespace sprint0.Enemies
{
    public class GoriyaStateMachine
    {
        private const int DirectionChange = 4;

        public GoriyaEnemy Goriya { get; set; }
        public enum Direction { Up, Down, Left, Right};
        public Direction GoriyaDirection { get; private set; }
        public SpriteEffects SpriteEffect { get; private set; }
        public bool BoomerangThrown { get; set; }
        public GoriyaProjectile Boomerang { get; set; }

        public GoriyaStateMachine(GoriyaEnemy goriya)
        {
            Goriya = goriya;            
            BoomerangThrown = false;
            SpriteEffect = SpriteEffects.None;
        }

        public void ChangeDirection()
        {
                Random rand = new Random();

                // randomly choose direction
                switch (rand.Next(0, DirectionChange))
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
                    default:
                            break;
                }
        }

        public void ThrowBoomerang()
        {
            Boomerang = new GoriyaProjectile(Goriya.Position, Goriya.Velocity, this);
            Goriya.Velocity = Vector2.Zero;
            BoomerangThrown = true;
        }
    }
}
