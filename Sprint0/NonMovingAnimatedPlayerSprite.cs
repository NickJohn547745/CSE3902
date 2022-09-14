using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0
{
    public class NonMovingAnimatedPlayerSprite : ISprite
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
        private int currentAnimationFrame = 0;
        private int totalFrames;
        private int spriteScale = 3;

        public NonMovingAnimatedPlayerSprite(Vector2 initialPoint)
        {
            currentPoint = initialPoint;
            currentAnimationFrame = 0;
            RequiresTexture = true;
        }

        public void Update()
        {
            totalFrames = Rows * Columns;

            currentAnimationFrame++;
            if (currentAnimationFrame == totalFrames)
            {
                currentAnimationFrame = 0;
            }
        }

        public void Draw()
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Columns;

            int row = currentAnimationFrame / Columns;
            int column = currentAnimationFrame % Columns;

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