using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0
{
    public class NonMovingNonAnimatedPlayerSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Queue<Vector2> LocationQueue { get; set; }
        public string Contents { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public bool RequiresTexture { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public SpriteFont Font { get; set; }

        private Vector2 currentPoint;
        private int spriteScale = 3;

        public NonMovingNonAnimatedPlayerSprite(Vector2 initialPoint)
        {
            currentPoint = initialPoint;
            RequiresTexture = true;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Columns;

            int row = 1 / Columns;
            int column = 1 % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            Rectangle destinationRectangle = new Rectangle(
                (int)currentPoint.X - (int)(width * spriteScale / 2), 
                (int)currentPoint.Y - (int)(height * spriteScale / 2), 
                width * spriteScale,
                height * spriteScale);

            SpriteBatch.Begin();
            SpriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            SpriteBatch.End();
        }
    }
}