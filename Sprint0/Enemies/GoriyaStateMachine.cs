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
using sprint0.Projectiles;

namespace sprint0.Enemies
{
    public class GoriyaStateMachine
    {
        private const int directionChange = 4;

        public GoriyaEnemy goriya { get; set; }
        public enum Direction { Up, Down, Left, Right};
        public Direction goriyaDirection { get; private set; }
        public SpriteEffects spriteEffect { get; private set; }
        public bool boomerangThrown { get; set; }
        public GoriyaProjectile boomerang { get; set; }

        public GoriyaStateMachine(GoriyaEnemy goriya)
        {
            this.goriya = goriya;            
            boomerangThrown = false;
            spriteEffect = SpriteEffects.None;
        }

        public void ChangeDirection()
        {
                Random rand = new Random();

                // randomly choose direction
                switch (rand.Next(0, directionChange))
                {
                    case 0:
                        // move up
                        goriyaDirection = Direction.Up;
                        goriya.velocity = new Vector2(0, -1);
                        this.goriya.sprite = EnemySpriteFactory.Instance.CreateGoriyaFacingUpStateSprite();
                        spriteEffect = SpriteEffects.FlipHorizontally;
                        break;
                    case 1:
                        // move left
                        goriyaDirection = Direction.Left;
                        goriya.velocity = new Vector2(-1, 0);
                        this.goriya.sprite = EnemySpriteFactory.Instance.CreateGoriyaFacingSideStateSprite();
                        spriteEffect = SpriteEffects.FlipHorizontally;
                        break;
                    case 2:
                            // move right
                            goriyaDirection = Direction.Right;
                            goriya.velocity = new Vector2(1, 0);
                            this.goriya.sprite = EnemySpriteFactory.Instance.CreateGoriyaFacingSideStateSprite();
                            spriteEffect = SpriteEffects.None;
                            break;
                    case 3:
                            // move down
                            goriyaDirection = Direction.Down;
                            goriya.velocity = new Vector2(0, 1);
                            this.goriya.sprite = EnemySpriteFactory.Instance.CreateGoriyaFacingDownStateSprite();
                            spriteEffect = SpriteEffects.FlipHorizontally;
                            break;
                    default:
                            break;
                }
        }

        public void ThrowBoomerang()
        {
            boomerang = new GoriyaProjectile(goriya.position, goriya.velocity, this);
            goriya.velocity = Vector2.Zero;
            boomerangThrown = true;
        }
    }
}
