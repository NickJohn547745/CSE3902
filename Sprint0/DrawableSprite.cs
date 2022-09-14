using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static Sprint0.IDrawableKernel;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace Sprint0
{
    public class DrawableSprite : Drawable
    {
        private readonly Game1 _game;
        private readonly SpriteBatch _spriteBatch;
        private readonly GraphicsDeviceManager _graphicsDeviceManager;

        private Queue<Locations> _locationQueue;
        private Vector2 _currentPosition;
        private Vector2 _nextPosition;

        private readonly Texture2D _texture;


        private readonly int _rows;
        private readonly int _columns;
        private readonly int _totalFrames;

        private int _currentFrame;
        private int _currentFrame_movement;
        private int _currentFrame_animation;
        private bool _isAnimated;
        private bool _isMobile;

        private readonly int _STEPS = 50;
        private readonly int _SCALE = 5;

        public DrawableSprite(Game1 p_game, Texture2D p_texture, int p_rows, int p_columns)
        {
            _game = p_game;
            _texture = p_texture;
            _rows = p_rows;
            _columns = p_columns;

            _spriteBatch = _game.GetSpriteBatch();
            _graphicsDeviceManager = _game.graphics;

            _currentPosition = new Vector2(0, 0);
            _nextPosition = new Vector2(0, 0);
            _locationQueue = new Queue<Locations>();

            _currentFrame = 0;
            _currentFrame_animation = 0;
            _currentFrame_movement = 0;
            _isAnimated = false;
            _isMobile = false;

            _totalFrames = _rows * _columns;
        }

        public override void Update(GameTime p_gameTime)
        {
            if (_isMobile)
            { 
                if (_currentFrame_movement == _STEPS || _currentFrame_movement == 0)
                {
                    _currentFrame_movement = 0;

                    Locations lastLocation = _locationQueue.Dequeue();

                    _currentPosition = calculatePointFromLocation(lastLocation);

                    _locationQueue.Enqueue(lastLocation);

                    _nextPosition = calculatePointFromLocation(_locationQueue.Peek());
                }
                _currentFrame_movement++;
            }

            _currentFrame++;

            if (_isAnimated)
            {
                if (_currentFrame % 15 == 0 || _currentFrame == 0)
                {
                    _currentFrame_animation++;
                }
            }
        }

        public override void Draw()
        {
            int width = _texture.Width / _columns;
            int height = _texture.Height / _rows;

            int row = _currentFrame_animation / _columns;
            int column = _currentFrame_animation % _columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * column, width, height);


            Rectangle destinationRectangle = new Rectangle(
                (int)(_currentPosition.X + (float)(
                    (_nextPosition.X - _currentPosition.X) / 
                    _STEPS * _currentFrame_movement) - (width * _SCALE) / 2),
                (int)(_currentPosition.Y + (float)(
                    (_nextPosition.Y - _currentPosition.Y) / 
                    _STEPS * _currentFrame_movement) - (height * _SCALE) / 2),
                width,
                height);

            destinationRectangle.Width *= _SCALE;
            destinationRectangle.Height *= _SCALE;

            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public override void MoveLeft(int p_pixels)
        {
            _currentPosition = new Vector2(_currentPosition.X - Math.Abs(p_pixels), _currentPosition.Y);
        }

        public override void MoveRight(int p_pixels)
        {
            _currentPosition = new Vector2(_currentPosition.X + Math.Abs(p_pixels), _currentPosition.Y);
        }

        public override void MoveUp(int p_pixels)
        {
            _currentPosition = new Vector2(_currentPosition.X, _currentPosition.Y + Math.Abs(p_pixels));
        }

        public override void MoveDown(int p_pixels)
        {
            _currentPosition = new Vector2(_currentPosition.X, _currentPosition.Y - Math.Abs(p_pixels));
        }

        public override void Draw(Vector2 p_position)
        {
            _currentPosition = p_position;
            this.Draw();
        }

        public void EnqueueLocation(Locations p_location)
        {
            _locationQueue.Enqueue(p_location);
            _currentPosition = calculatePointFromLocation(_locationQueue.Peek());
        }

        public Locations DequeueLocation()
        {
            return _locationQueue.Dequeue();
        }

        public void SetAnimationStatus(bool status)
        {
            _isAnimated = status;
        }
        public void SetMobileStatus(bool status)
        {
            _isMobile = status;
        }
    }
}