using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.DoorClasses;
using sprint0.Interfaces;
using sprint0.TileClasses;

namespace sprint0.RoomClasses
{
    public class Room
    {
        private Game1 game;

        private List<ICollidable> tileList = new List<ICollidable>();
        private List<Door> doorList = new List<Door>();

        private Rectangle bounds = new Rectangle();

        public LevelConfig levelConfig { get; set; }
        public Room(Game1 game, LevelConfig levelConfig)
        {
            this.game = game;
            this.levelConfig = levelConfig;

            bounds = new Rectangle(0, 0, 1280, 880);

            List<ICollidable> removalList = new List<ICollidable>();

            foreach (ICollidable collidable in game.CollidableList)
            {
                Type type = collidable.GetObjectType();

                if (type == typeof(Wall) || type == typeof(TileType) || type == typeof(Door))
                    removalList.Add(collidable);
            }

            removalList.ForEach(removalItem => game.CollidableList.Remove(removalItem));

            game.CollidableList.Add(new TopLeftWall());
            game.CollidableList.Add(new TopRightWall());
            game.CollidableList.Add(new RightTopWall());
            game.CollidableList.Add(new RightBottomWall());
            game.CollidableList.Add(new BottomRightWall());
            game.CollidableList.Add(new BottomLeftWall());
            game.CollidableList.Add(new LeftBottomWall());
            game.CollidableList.Add(new LeftTopWall());

            int rows = levelConfig.TileIds.Count;

            for (int y = 0; y < rows; y++)
            {
                int columns = levelConfig.TileIds[y].Count;
                for (int x = 0; x < columns; x++)
                {
                    int currentTileId = levelConfig.TileIds[y][x];

                    TileType tile = GetTileFromId(currentTileId, 160 + x * 80, 160 + y * 80);
                    if (currentTileId != 0)
                    {
                        game.CollidableList.Add(tile);
                    }
                    tileList.Add(tile);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                int currentDoorId = levelConfig.DoorIds[i];

                Door door = GetDoorFromId(i);
                door.Id = currentDoorId;
                
                if (currentDoorId != 1)
                {
                    game.CollidableList.Add(door);
                }
                doorList.Add(door);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureStorage.GetWallsSpritesheet(), bounds, Color.White);

            foreach (ICollidable tile in tileList)
            {
                tile.Draw(spriteBatch);
            }
            foreach (Door door in doorList)
            {
                if (door.Id == 1)
                    door.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime, Game1 game)
        {

        }

        private TileType GetTileFromId(int id, int x, int y)
        {
            switch (id)
            {
                case 0:
                    return new TileType1(x, y);
                case 1:
                    return new TileType2(x, y);
                case 2:
                    return new TileType3(x, y);
                case 3:
                    return new TileType4(x, y);
                case 4:
                    return new TileType5(x, y);
                case 5:
                    return new TileType6(x, y);
                case 6:
                    return new TileType7(x, y);
                case 7:
                    return new TileType8(x, y);
                case 8:
                    return new TileType9(x, y);
                case 9:
                    return new TileType10(x, y);
            }
            return new TileType1(x, y);
        }
        private Door GetDoorFromId(int id)
        {
            switch (id)
            {
                case 0:
                    return new TopDoor();
                case 1:
                    return new RightDoor();
                case 2:
                    return new BottomDoor();
                case 3:
                    return new LeftDoor();
            }
            return null;
        }
    }
}
