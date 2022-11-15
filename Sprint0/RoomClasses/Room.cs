using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.DoorClasses;
using sprint0.Enemies;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.TileClasses;

namespace sprint0.RoomClasses
{
    public class Room
    {
        private Game1 game;

        private List<TileType> tileList = new List<TileType>();
        private List<Door> doorList = new List<Door>();
        private Dictionary<Direction, LevelConfig> roomMap = new Dictionary<Direction, LevelConfig>();

        private Rectangle bounds = new Rectangle();

        public Point roomOffset = new Point();
        private Boolean transitioning = false;
        public Boolean RoomReady { get; set; }
        private Direction transitionDirection = Direction.Left;

        private Room nextRoom;

        public LevelConfig levelConfig { get; set; }
        public Room(Game1 game, LevelConfig cfg)
        {
            this.game = game;
            levelConfig = cfg;
            RoomReady = false;

            bounds = new Rectangle(0, 0, 1280, 880);

            game.CollisionManager.Reset();
            CollisionManager.Collidables.Add(new TopLeftWall());
            CollisionManager.Collidables.Add(new TopRightWall());
            CollisionManager.Collidables.Add(new RightTopWall());
            CollisionManager.Collidables.Add(new RightBottomWall());
            CollisionManager.Collidables.Add(new BottomRightWall());
            CollisionManager.Collidables.Add(new BottomLeftWall());
            CollisionManager.Collidables.Add(new LeftBottomWall());
            CollisionManager.Collidables.Add(new LeftTopWall());

            DungeonMap.Instance.Map[DungeonMap.Instance.CurrentRoom[0], DungeonMap.Instance.CurrentRoom[1]] = 16;
            int rows = levelConfig.TileIds.Count;

            for (int y = 0; y < rows; y++)
            {
                int columns = levelConfig.TileIds[y].Count;
                for (int x = 0; x < columns; x++)
                {
                    int currentTileId = levelConfig.TileIds[y][x];

                    TileType tile = GetTileFromId(currentTileId, 160 + x * 80, 160 + y * 80);
                    tileList.Add(tile);
                    if (tile.IsCollidable)
                        CollisionManager.Collidables.Add(tile);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                int currentDoorId = levelConfig.DoorIds[i];
                int currentDestination = levelConfig.Destinations[i];

                Door door = DoorObjectFactory.Instance.CreateDoorById((Direction)i, currentDoorId);

                doorList.Add(door);

                if (currentDestination != -1)
                {
                    LevelConfig destinationLevelConfig = game.GameConfig.LevelConfigs[currentDestination];

                    roomMap.Add((Direction)i, destinationLevelConfig);
                }
            }
        }

        public void Initialize()
        {
            foreach (Door door in doorList)
            {
                CollisionManager.Collidables.Add(door);
            }
            foreach (TileType tile in tileList)
            {
                if (tile.IsCollidable)
                    CollisionManager.Collidables.Add(tile);
            }

            foreach (Tuple<int, Point, int> enemy in levelConfig.Enemies)
            {
                CollisionManager.Collidables.Add(
                    EnemyObjectFactory.Instance.CreateEnemyById(enemy.Item1, enemy.Item2.X, enemy.Item2.Y, enemy.Item3));
            }

            foreach (Tuple<int, Point> item in levelConfig.Items)
            {
                CollisionManager.Collidables.Add(
                    ItemObjectFactory.Instance.CreateItemById(item.Item1, item.Item2.X, item.Item2.Y));
            }
            RoomReady = true;
        }

        public void Update(GameTime gameTime)
        {
            if (RoomReady)
            {
                foreach (Door door in doorList)
                {
                    if (!transitioning && door.HasCollided)
                    {
                        CollisionManager.Collidables.Remove(door);
                        transitionDirection = door.TransitionDirection;
                        transitioning = true;

                        if (roomMap.ContainsKey(transitionDirection))
                        {
                            LevelConfig destinationLevelConfig = roomMap[transitionDirection];

                            nextRoom = new Room(game, destinationLevelConfig);
                            nextRoom.levelConfig = destinationLevelConfig;
                            nextRoom.transitioning = true;
                        }

                        door.HasCollided = false;
                    }
                    else
                    {
                        Transition(transitionDirection);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureStorage.GetWallsSpritesheet(),
                             new Rectangle(bounds.Location + roomOffset, bounds.Size), Color.White);

            foreach (TileType tile in tileList)
            {
                tile.Draw(spriteBatch, roomOffset);
            }

            foreach (Door door in doorList)
            {
                if (door.HasCollided && (door.Id == 1 || door.Id == 4) && !transitioning && RoomReady)
                {
                    transitionDirection = door.TransitionDirection;
                    transitioning = true;

                    LevelConfig destinationLevelConfig = roomMap[door.TransitionDirection];

                    nextRoom = new Room(game, destinationLevelConfig);
                    nextRoom.levelConfig = destinationLevelConfig;
                }
                else
                {
                    door.HasCollided = false;
                }
                door.Draw(spriteBatch, roomOffset);
            }

            if (nextRoom != null && transitioning)
            {
                nextRoom.Draw(spriteBatch);
                foreach (Door nextDoor in nextRoom.doorList)
                {
                    nextDoor.Draw(spriteBatch, nextRoom.roomOffset);
                }
            }

        }

        public void Transition(Direction dir)
        {
            int step = 2;
            if (transitioning && RoomReady)
            {
                CollisionManager.Collidables.Remove(game.Player);
                if (dir == Direction.Left && roomOffset.X < 1285)
                {
                    roomOffset.X += step;

                    nextRoom.roomOffset.X = -1280 + roomOffset.X;
                    nextRoom.roomOffset.Y = 0;

                    game.Player.Position = new Vector2(1100 - game.Player.GetHitBox().Width, 880 / 2);
                }
                else if (dir == Direction.Right && Math.Abs(roomOffset.X) < 1285)
                {
                    roomOffset.X -= step;

                    nextRoom.roomOffset.X = 1280 + roomOffset.X;
                    nextRoom.roomOffset.Y = 0;

                    game.Player.Position = new Vector2(180 + game.Player.GetHitBox().Width, 880 / 2);
                }
                else if (dir == Direction.Down && roomOffset.Y < 885)
                {
                    roomOffset.Y += step;

                    nextRoom.roomOffset.X = 0;
                    nextRoom.roomOffset.Y = -880 + roomOffset.Y;

                    game.Player.Position = new Vector2(1280 / 2, 180 + game.Player.GetHitBox().Height);
                }
                else if (dir == Direction.Up && Math.Abs(roomOffset.Y) < 885)
                {
                    roomOffset.Y -= step;

                    nextRoom.roomOffset.X = 0;
                    nextRoom.roomOffset.Y = 880 + roomOffset.Y;

                    game.Player.Position = new Vector2(1280 / 2, 700 - game.Player.GetHitBox().Height);
                }
                else
                {
                    roomOffset = new Point(0, 0);
                    transitioning = false;

                    game.state.Room = nextRoom;
                    game.state.Room.transitioning = false;
                    game.state.Room.roomOffset = new Point();
                    game.state.Room.Initialize();
                    
                    DungeonMap.Instance.AddRoomToMap(dir);

                    CollisionManager.Collidables.Add(game.Player);

                    foreach (Door door in doorList)
                    {
                        door.HasCollided = false;
                    }
                }
            }
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            foreach (Door door in doorList)
            {
                door.Update(gameTime, game);
            }
        }

        private TileType GetTileFromId(int id, int x, int y)
        {
            Type tileType = Type.GetType("sprint0.TileClasses.TileType" + (id + 1).ToString());
            object tileTypeObject = Activator.CreateInstance(tileType, x, y);
            return (TileType)tileTypeObject;
        }
    }
}
