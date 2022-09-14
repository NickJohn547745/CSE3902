using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class TextSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public SpriteBatch SpriteBatch { get; set ; }
        public Queue<Vector2> LocationQueue { get; set; }
        public string Contents { get; set; }
        public bool RequiresTexture { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public SpriteFont Font { get; set; }

        private Vector2 location;
        public TextSprite(Vector2 location)
        {
            this.location = location;
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            SpriteBatch.Begin();

            List<String> stringList = Contents.Split('\n').ToList();
            Vector2 textDimension = new Vector2(0, 0);
            int textIndex = 0;

            foreach (string splitString in stringList)
            {
                textDimension = Font.MeasureString(splitString);

                SpriteBatch.DrawString(
                    Font, 
                    splitString, 
                    new Vector2(
                        location.X - textDimension.X / 2, 
                        location.Y + 150 + (textDimension.Y * textIndex)), 
                    Color.Black);
                textIndex++;
            }

            SpriteBatch.End();
        }
    }
}
