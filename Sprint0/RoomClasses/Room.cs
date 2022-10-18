using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Interfaces;

namespace sprint0.RoomClasses
{
    public class Room
    {
        private Game1 game;
        public Room(Game1 game)
        {
            this.game = game;

            game.CollidableList.Add(new TopLeftWall());
            game.CollidableList.Add(new TopRightWall());
            game.CollidableList.Add(new RightTopWall());
            game.CollidableList.Add(new RightBottomWall());
            game.CollidableList.Add(new BottomRightWall());
            game.CollidableList.Add(new BottomLeftWall());
            game.CollidableList.Add(new LeftBottomWall());
            game.CollidableList.Add(new LeftTopWall());
        }

        public void Update(GameTime gameTime, Game1 game)
        {

        }
    }
}
