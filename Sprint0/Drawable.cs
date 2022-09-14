using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public abstract class Drawable : IDrawable
    {
        public enum Locations
        {
            Center,
            CenterRight,
            CenterLeft,
            CenterTop,
            CenterBottom,
            TopRight,
            TopLeft,
            BottomRight,
            BottomLeft
        };

        private GraphicsDeviceManager _graphics;

        public abstract void Update(GameTime p_gameTime);

        public abstract void Draw();

        public void SetGraphicsDM(GraphicsDeviceManager p_graphics)
        {
            _graphics = p_graphics;
        }

        public Vector2 calculatePointFromLocation(Locations location)
        {
            int windowWidth = _graphics.PreferredBackBufferWidth;
            int windowHeight = _graphics.PreferredBackBufferHeight;

            Vector2 returnPoint = new Vector2(0, 0);

            switch (location)
            {
                case Locations.Center:
                    returnPoint = new Vector2((int)(windowWidth / 2), (int)(windowHeight / 2));
                    break;
                case Locations.CenterRight:
                    returnPoint = new Vector2(windowWidth, (int)(windowHeight / 2));
                    break;
                case Locations.CenterLeft:
                    returnPoint = new Vector2(0, (int)(windowHeight / 2));
                    break;
                case Locations.CenterTop:
                    returnPoint = new Vector2((int)(windowWidth / 2), 0);
                    break;
                case Locations.CenterBottom:
                    returnPoint = new Vector2((int)(windowWidth / 2), windowHeight);
                    break;
                case Locations.TopRight:
                    returnPoint = new Vector2(windowWidth, 0);
                    break;
                case Locations.TopLeft:
                    returnPoint = new Vector2(0, 0);
                    break;
                case Locations.BottomRight:
                    returnPoint = new Vector2(windowWidth, windowHeight);
                    break;
                case Locations.BottomLeft:
                    returnPoint = new Vector2(0, windowHeight);
                    break;
            }

            return returnPoint;
        }

        public abstract void MoveLeft(int p_pixels);
        public abstract void MoveRight(int p_pixels);
        public abstract void MoveUp(int p_pixels);
        public abstract void MoveDown(int p_pixels);
        public abstract void Draw(Vector2 p_position);
    }
}
