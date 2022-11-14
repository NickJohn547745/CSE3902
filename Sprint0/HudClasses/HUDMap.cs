using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.PlayerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.HudClasses
{
    public class HUDMap : IMap
    {
        public Point PlayerPosition { get; set; }
        public bool MapFound { get; set; }
        public Game1 game { get; set; }

        public HUDMap(Game1 Game, Point position, bool hasMap)
        {
            PlayerPosition = position;
            MapFound = hasMap;
            game = Game;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // get colored square
            Texture2D whiteRectangle = new Texture2D(game.GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });
            Rectangle playerRectangle = new Rectangle(0, 0, 8, 8);

            spriteBatch.Draw(whiteRectangle, playerRectangle, Color.White);
        }
        public void Reset()
        {

        }
        public void Update(Game1 game)
        {

        }

    }
}
