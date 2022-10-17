using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Interfaces;
using sprint0.TileClasses;

namespace sprint0.RoomClasses
{
    public class Room
    {
        private Game1 game;
        private List<ITile> tileList = new List<ITile>();
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

            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    tileList.Add(new TileType1(160 + x * 80, 160 + y * 80));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ITile tile in tileList)
            {
                tile.Draw(spriteBatch);
            } 
        }

        public void Update(GameTime gameTime, Game1 game)
        {

        }
    }
}
