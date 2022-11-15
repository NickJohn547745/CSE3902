using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.PlayerClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace sprint0.HudClasses
{
    public class HUDMap
    {
        public int CurrentRoom { get; set; }
        public bool MapFound { get; set; } = true;
        public Game1 game { get; set; }

        public float XMin { get; set; }
        public float YMin { get; set; }
        public float YMax { get; set; }
        public float XMax { get; set; }

        private float MapSquareWidth;
        private float MapSquareHeight;
        // room index will give the coords of square that the user is in
        private List<List<Tuple<int, Vector2>>> RoomDrawnAt;
        public HUDMap(Game1 Game, int currentRoom, bool hasMap, float xMin, float yMin, float xMax, float yMax)
        {
            CurrentRoom = currentRoom;
            MapFound = hasMap;
            game = Game;
            XMin = xMin;
            YMin = yMin;
            YMax = yMax;
            XMax = xMax;

            RoomDrawnAt = new List<List<Tuple<int, Vector2>>>();
            PopulateMap();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // get solid 8x8 square
            const int SquareWidth = 8;
            const int SquareHeight = 8;
            Texture2D rectTexture = new Texture2D(game.GraphicsDevice, SquareWidth, SquareHeight);
            Color[] data = new Color[SquareWidth * SquareHeight];
            for (int i = 0; i < data.Length; ++i)
                data[i] = Color.White;

            rectTexture.SetData(data);

            // only draw map of rooms if found
            // set to true for now
            MapFound = true;
            if (MapFound)
            {
                // draws square at each coordinate
                for (int x = 0; x < 7; x++)
                {
                    for (int y = 0; y < 6; y++)
                    {
                        int id = RoomDrawnAt[x][y].Item1;
                        Vector2 current = RoomDrawnAt[x][y].Item2;

                        Rectangle destinationRectangle = new Rectangle((int)current.X, (int)current.Y, 
                                                    (int)MapSquareWidth - 5, (int)MapSquareHeight - 5);
                        spriteBatch.Draw(rectTexture, destinationRectangle, Color.DarkBlue);

                        Rectangle currentRoomRect = new Rectangle((int)current.X + 5, (int)current.Y + 5, 
                                                    (int)MapSquareWidth - 15, (int)MapSquareHeight - 15);

                        if (id == CurrentRoom)
                        {
                            spriteBatch.Draw(rectTexture, currentRoomRect, Color.Yellow);
                        }
                    }
                }
            }
            Vector2 position = new Vector2(XMin, YMin);
            // spriteBatch.Draw(rectTexture, new Vector2(position.X + 8, position.Y + 8), Color.LightGreen);
        }
        public void Reset()
        {

        }
        public void Update(int currentRoom, bool hasMap)
        {
            CurrentRoom = currentRoom;
            MapFound = hasMap;
        }

        public void PopulateMap()
        {
            float mapWidth = XMax - XMin;
            float mapHeight = YMax - YMin;

            MapSquareWidth = 24;
            MapSquareHeight = 24;

            for (int x = 0; x < 7; x++)
            {
                RoomDrawnAt.Add(new List<Tuple<int, Vector2>>());
                for (int y = 0; y < 6; y++)
                {
                    List<Tuple<int, Vector2>> current = RoomDrawnAt[x];
                    current.Add(new Tuple<int, Vector2>(-1, new Vector2(0, 0)));
                }
            }

            RoomDrawnAt[5][3] = new Tuple<int, Vector2>(13, new Vector2(1, 1));

            RoomDrawnAt[4][5] = new Tuple<int, Vector2>(12, new Vector2(1, 1));
            RoomDrawnAt[4][3] = new Tuple<int, Vector2>(9, new Vector2(1, 1));
            RoomDrawnAt[4][2] = new Tuple<int, Vector2>(7, new Vector2(1, 1));
            RoomDrawnAt[4][0] = new Tuple<int, Vector2>(3, new Vector2(1, 1));

            RoomDrawnAt[3][5] = new Tuple<int, Vector2>(11, new Vector2(1, 1));
            RoomDrawnAt[3][4] = new Tuple<int, Vector2>(8, new Vector2(1, 1));
            RoomDrawnAt[3][3] = new Tuple<int, Vector2>(5, new Vector2(1, 1));
            RoomDrawnAt[3][2] = new Tuple<int, Vector2>(4, new Vector2(1, 1));
            RoomDrawnAt[3][1] = new Tuple<int, Vector2>(1, new Vector2(1, 1));
            RoomDrawnAt[3][0] = new Tuple<int, Vector2>(0, new Vector2(1, 1));

            RoomDrawnAt[2][3] = new Tuple<int, Vector2>(10, new Vector2(1, 1));
            RoomDrawnAt[2][0] = new Tuple<int, Vector2>(2, new Vector2(1, 1));
            RoomDrawnAt[2][2] = new Tuple<int, Vector2>(6, new Vector2(1, 1));

            RoomDrawnAt[1][4] = new Tuple<int, Vector2>(14, new Vector2(1, 1));
            RoomDrawnAt[1][3] = new Tuple<int, Vector2>(15, new Vector2(1, 1));

            RoomDrawnAt[0][4] = new Tuple<int, Vector2>(16, new Vector2(1, 1));

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    Vector2 result = new Vector2(mapWidth / 2 - (x - 3) * MapSquareWidth,
                                                 YMax - (y) * MapSquareHeight);
                    int id = RoomDrawnAt[x][y].Item1;
                    Vector2 current = RoomDrawnAt[x][y].Item2;

                    current.X *= result.X;
                    current.Y *= result.Y;

                    RoomDrawnAt[x][y] = new Tuple<int, Vector2>(id, current);
                }
            }
        }

    }
}
