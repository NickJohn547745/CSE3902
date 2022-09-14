using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace Sprint0
{
    public class MovingAnimatedPlayerSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Queue<Vector2> LocationQueue { get; set; }
        public string Contents { get; set; }
        public bool RequiresTexture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public SpriteFont Font { get; set; }
        public SpriteBatch SpriteBatch { get; set; }

        private Vector2 nextPoint;
        private Vector2 currentPoint;
        private int currentMoveFrame = 0;
        private int currentAnimationFrame = 0;
        private int steps = 150;
        private int spriteScale = 3;
        private int totalFrames;

        public MovingAnimatedPlayerSprite(Vector2 initialPoint)
        {
            currentPoint = initialPoint;
            nextPoint = initialPoint;

            currentMoveFrame = 0;
            RequiresTexture = true;
        }

        public void Update()
        {
            totalFrames = Rows * Columns;

            currentMoveFrame++;

            if (currentMoveFrame == steps)
            {
                currentMoveFrame = 0;

                Vector2 lastLocation = LocationQueue.Dequeue();

                currentPoint = lastLocation;

                LocationQueue.Enqueue(lastLocation);

                nextPoint = LocationQueue.Peek();
            }
            
            if (currentMoveFrame % 2 == 0)
            {
                currentAnimationFrame++; 
                if (currentAnimationFrame == totalFrames)
                {
                    currentAnimationFrame = 0;
                }
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
                (int)(currentPoint.X + (float)((nextPoint.X - currentPoint.X) / (float)steps) * currentMoveFrame) - (int)(width * spriteScale / 2),
                (int)(currentPoint.Y + (float)((nextPoint.Y - currentPoint.Y) / (float)steps) * currentMoveFrame) - (int)(height * spriteScale / 2),
            width * spriteScale,
            height * spriteScale);

            SpriteBatch.Begin();
            SpriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            SpriteBatch.End();
        }
    }
}