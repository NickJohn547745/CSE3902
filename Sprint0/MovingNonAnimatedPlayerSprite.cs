using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0
{
    public class MovingNonAnimatedPlayerSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Queue<Vector2> LocationQueue { get; set; }
        public string Contents { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public bool RequiresTexture { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public SpriteFont Font { get; set; }

        private Vector2 nextPoint;
        private Vector2 currentPoint;
        private int currentFrame = 0;
        private int steps = 150;
        private int spriteScale = 3;

        public MovingNonAnimatedPlayerSprite(Vector2 initialPoint)
        {
            currentPoint = initialPoint;
            nextPoint = initialPoint;
            RequiresTexture = true;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == steps)
            {
                currentFrame = 0;

                Vector2 lastLocation = LocationQueue.Dequeue();

                currentPoint = lastLocation;

                LocationQueue.Enqueue(lastLocation);

                nextPoint = LocationQueue.Peek();
            }
        }

        public void Draw()
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Columns;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);

            Rectangle destinationRectangle = new Rectangle(
                (int)(currentPoint.X + (float)((nextPoint.X - currentPoint.X) / (float)steps) * currentFrame) - (int)(width * spriteScale / 2),
                (int)(currentPoint.Y + (float)((nextPoint.Y - currentPoint.Y) / (float)steps) * currentFrame) - (int)(height * spriteScale / 2), 
                width * spriteScale, 
                height * spriteScale);

            SpriteBatch.Begin();
            SpriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            SpriteBatch.End();
        }


    }
}