﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses
{
    public class PlayerSword : ICollidable
    {
        private const int playerOffset = 15;
        private const int swordWidth = 4;
        private const int sideOffset = 7;
        private const int topOffset = 3;
        private const int bottomOffset = 7;
        private readonly int[] swordLen = {0, 11, 7, 3};

        public ICollidable.ObjectType Type { get; set; }
        public int Damage { get; set; }
        private Player player;
        private Point swordPosition;
        private Point swordWH;
        public int currentFrame { get; set; }
        private ICollidable.Edge Direction;

        public PlayerSword(Player link, ICollidable.Edge edge)
        {
            Damage = 1;
            Type = ICollidable.ObjectType.Sword;
            player = link;
            currentFrame = 0;
            Direction = edge;
        }

        public void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            // nothing
        }
        public Vector2 GetVelocity()
        {
            return player.Velocity;
        }

        public Rectangle GetHitBox()
        {
            int length = swordLen[currentFrame] * player.ScaleFactor;
            int width = swordWidth * player.ScaleFactor;

            switch (Direction)
            {
                case ICollidable.Edge.Bottom:
                    swordPosition = new Point((int)player.Position.X + topOffset * player.ScaleFactor, (int)player.Position.Y - (player.PlayerState.sprite.GetHeight(currentFrame) - 64));
                    swordWH = new Point(width, length);
                    break;
                case ICollidable.Edge.Right:
                    swordPosition = new Point((int)player.Position.X + playerOffset * player.ScaleFactor, (int)player.Position.Y + sideOffset * player.ScaleFactor);
                    swordWH = new Point(length, width);
                    break;
                case ICollidable.Edge.Left:
                    swordPosition = new Point((int)player.Position.X - (player.PlayerState.sprite.GetWidth(currentFrame) - 64), (int)player.Position.Y + sideOffset * player.ScaleFactor);
                    swordWH = new Point(length, width);
                    break;
                case ICollidable.Edge.Top:
                    swordPosition = new Point((int)player.Position.X + bottomOffset * player.ScaleFactor, (int)player.Position.Y + playerOffset * player.ScaleFactor);
                    swordWH = new Point(width, length);
                    break;
            }
            return new Rectangle(swordPosition, swordWH); 
        }
        public void Update(GameTime gameTime)
        {
            // nothing
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // nothing
        }

        public void Reset()
        {
            // nothing
        }

        public void Reset(bool healthCheat, bool bombCheat, bool rupeeCheat, bool mapCheat, bool compassCheat)
        {

        }
    }
}
