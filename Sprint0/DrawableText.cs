using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class DrawableText : Drawable
    {
        private Vector2 _currentPosition;
        private Vector2 _nextPosition;
        private Queue<Locations> _locationQueue;

        private readonly Game1 _game;
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        private readonly SpriteBatch _spriteBatch;
        private readonly SpriteFont _font;

        private string _text;
        public DrawableText(Game1 p_game, SpriteFont p_font, string p_text)
        {
            _game = p_game;
            _font = p_font;
            _text = p_text;

            _spriteBatch = _game.GetSpriteBatch();
            _graphicsDeviceManager = _game.GetGraphicsDM();

            _currentPosition = new Vector2(0, 0);
            _nextPosition = new Vector2(0, 0);
            _locationQueue = new Queue<Locations>();
        }

        public override void Update(GameTime p_gameTime)
        {
            
        }

        public override void Draw()
        {
            _spriteBatch.Begin();

            List<String> stringList = _text.Split('\n').ToList();
            Vector2 textDimension;
            int textIndex = 0;

            foreach (string splitString in stringList)
            {
                textDimension = _font.MeasureString(splitString);

                _spriteBatch.DrawString(
                    _font, 
                    splitString, 
                    new Vector2(
                        _currentPosition.X - textDimension.X / 2,
                        _currentPosition.Y + 150 + (textDimension.Y * textIndex)), 
                    Color.Black);
                textIndex++;
            }

            _spriteBatch.End();
        }

        public override void MoveLeft(int p_pixels)
        {
            throw new NotImplementedException();
        }

        public override void MoveRight(int p_pixels)
        {
            throw new NotImplementedException();
        }

        public override void MoveUp(int p_pixels)
        {
            throw new NotImplementedException();
        }

        public override void MoveDown(int p_pixels)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Vector2 p_position)
        {
            throw new NotImplementedException();
        }
    }
}
