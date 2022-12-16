using sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses;
using sprint0.HudClasses;
using sprint0.Managers;
using sprint0.RoomStateClasses;
using sprint0.Configs;
using sprint0.GameStateClasses;
using sprint0.DoorClasses;
using sprint0.TileClasses;
using System.Collections.Generic;
using sprint0.Factories;
using System;
using System.Diagnostics;
using sprint0.ProceduralGeneration;

namespace sprint0.RoomStateClasses;

public class RoomStateManager : IRoomState
{
    public Game1 game { get; set; }
    public LevelConfig levelConfig { get; set; }
    public ARoomState currentState { get; set; }

    public List<TileType> tileList = new List<TileType>();
    public List<Door> doorList = new List<Door>();

    public LevelConfig upRoomConfig = new LevelConfig();
    public LevelConfig rightRoomConfig = new LevelConfig();
    public LevelConfig downRoomConfig = new LevelConfig();
    public LevelConfig leftRoomConfig = new LevelConfig();
    public Rectangle ScreenBounds { get; }

    public RoomStateManager(Game1 game, LevelConfig levelConfig)
    {
        this.game = game;
        this.levelConfig = levelConfig;

        ScreenBounds = new Rectangle(0, 0, game.GameConfig.ResolutionWidth, game.GameConfig.ResolutionHeight);

        InitializeTiles();
        InitializeDoors();
        InitializeAdjacentLevels();
    }

    public void Initialize()
    {
        currentState = new RoomIdleState(this);
    }

    private void InitializeTiles()
    {
        int rows = levelConfig.TileIds.Count;

        for (int y = 0; y < rows; y++)
        {
            int columns = levelConfig.TileIds[y].Count;
            for (int x = 0; x < columns; x++)
            {
                int currentTileId = levelConfig.TileIds[y][x];

                TileType tile = GetTileFromId(currentTileId, 160 + x * 80, 160 + y * 80);
                tileList.Add(tile);
            }
        }
    }

    private void InitializeDoors()
    {
        for (int i = 0; i < 4; i++)
        {
            int currentDoorId = levelConfig.DoorIds[i];

            Door door = DoorObjectFactory.Instance.CreateDoorById((Direction)i, currentDoorId);

            doorList.Add(door);
            CollisionManager.Collidables.Add(door);
        }
    }

    private void InitializeAdjacentLevels()
    {
        for (int i = 0; i < 4; i++)
        {
            int currentDestination = levelConfig.Destinations[i];

            if (currentDestination != -1)
            {
                LevelConfig destinationLevelConfig;
                if (currentDestination >= 0)
                    destinationLevelConfig = game.LevelList[currentDestination];
                else
                    destinationLevelConfig = game.LevelList[RoomLayoutGenerator.Instance.StartRoomId + game.DefaultRoomOffset];

                switch ((Direction)i)
                {
                    case Direction.Up:
                        upRoomConfig = destinationLevelConfig;
                        break;
                    case Direction.Right:
                        rightRoomConfig = destinationLevelConfig;
                        break;
                    case Direction.Down:
                        downRoomConfig = destinationLevelConfig;
                        break;
                    case Direction.Left:
                        leftRoomConfig = destinationLevelConfig;
                        break;
                }
            }
        }
    }

    public void Update(GameTime gameTime)
    {
        currentState.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Draw(spriteBatch, new Point());
    }

    public void Draw(SpriteBatch spriteBatch, Point offset)
    {
        currentState.Draw(spriteBatch, offset);
    }

    public void Reset()
    {
        currentState.Reset();
    }

    public void TransitionState(RoomStates newState)
    {
        switch (newState)
        {
            case RoomStates.Idle:
                currentState = new RoomIdleState(this);
                break;
            case RoomStates.TransitioningUp:
                currentState = new RoomTransitionUpState(this);
                break;
            case RoomStates.TransitioningRight:
                currentState = new RoomTransitionRightState(this);
                break;
            case RoomStates.TransitioningDown:
                currentState = new RoomTransitionDownState(this);
                break;
            case RoomStates.TransitioningLeft:
                currentState = new RoomTransitionLeftState(this);
                break;
            default:
                break;
        }
    }
    private TileType GetTileFromId(int id, int x, int y)
    {
        Type tileType = Type.GetType("sprint0.TileClasses.TileType" + (id + 1).ToString());
        object tileTypeObject = Activator.CreateInstance(tileType, x, y);
        return (TileType)tileTypeObject;
    }
}