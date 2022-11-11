using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses;
using sprint0.Sprites;
using sprint0.Interfaces;
using static sprint0.Interfaces.ICollidable;

namespace sprint0.Interfaces
{
    public class PlayerSword : ICollidable
    {
        private const int playerOffset = 15;
        private const int swordWidth = 4;
        private const int sideOffset = 7;
        private const int topOffset = 3;
        private const int bottomOffset = 7;
        private readonly int[] swordLen = {0, 11, 7, 3};

        public ObjectType type { get; set; }
        public int Damage { get; set; }
        private Player player;
        private Point swordPosition;
        private Point swordWH;
        public int currentFrame { get; set; }
        private Edge Edge;

        public PlayerSword(Player link, Edge edge)
        {
            Damage = 1;
            type = ObjectType.Sword;
            player = link;
            currentFrame = 0;
            Edge = edge;
        }

        public void Collide(ICollidable obj, Edge edge)
        {
            // nothing
        }
        public Rectangle GetHitBox()
        {
            int length = swordLen[currentFrame] * player.ScaleFactor;
            int width = swordWidth * player.ScaleFactor;

            switch (Edge)
            {
                case Edge.Top:
                    swordPosition = new Point((int)player.Position.X + topOffset * player.ScaleFactor, (int)player.Position.Y - (player.PlayerState.sprite.GetHeight(currentFrame) - 64));
                    swordWH = new Point(width, length);
                    break;
                case Edge.Right:
                    swordPosition = new Point((int)player.Position.X + playerOffset * player.ScaleFactor, (int)player.Position.Y + sideOffset * player.ScaleFactor);
                    swordWH = new Point(length, width);
                    break;
                case Edge.Left:
                    swordPosition = new Point((int)player.Position.X - (player.PlayerState.sprite.GetWidth(currentFrame) - 64), (int)player.Position.Y + sideOffset * player.ScaleFactor);
                    swordWH = new Point(length, width);
                    break;
                case Edge.Bottom:
                    swordPosition = new Point((int)player.Position.X + bottomOffset * player.ScaleFactor, (int)player.Position.Y + playerOffset * player.ScaleFactor);
                    swordWH = new Point(width, length);
                    break;
            }
            return new Rectangle(swordPosition, swordWH); ;
        }
        public void Update(GameTime gameTime, Game1 game)
        {
            // nothing
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // nothing
        }

        public void Reset(Game1 game)
        {
            // nothing
        }
    }
}
