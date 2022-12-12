using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.Classes;
using sprint0.Configs;
using sprint0.DoorClasses;
using sprint0.TileClasses;
using sprint0.Factories;
using sprint0.Managers;
using System;
using sprint0.MenuItems.Inventory;
using sprint0.RoomClasses;
using sprint0.Interfaces;
using System.Diagnostics;

namespace sprint0.RoomStateClasses;

public class RoomIdleState : ARoomState
{

    public RoomIdleState(RoomStateManager state)
    {
        roomState = state;

        roomState.game.CollisionManager.Reset();

        CollisionManager.Collidables.Add(new TopLeftWall());
        CollisionManager.Collidables.Add(new TopRightWall());
        CollisionManager.Collidables.Add(new RightTopWall());
        CollisionManager.Collidables.Add(new RightBottomWall());
        CollisionManager.Collidables.Add(new BottomRightWall());
        CollisionManager.Collidables.Add(new BottomLeftWall());
        CollisionManager.Collidables.Add(new LeftBottomWall());
        CollisionManager.Collidables.Add(new LeftTopWall());

        DungeonMap.Instance.Map[DungeonMap.Instance.CurrentRoom[0], DungeonMap.Instance.CurrentRoom[1]] = 16;

        foreach (Door door in roomState.doorList)
        {
            CollisionManager.Collidables.Add(door);
        }

        foreach (TileType tile in roomState.tileList)
        {
            if (tile.IsCollidable)
                CollisionManager.Collidables.Add(tile);
        }

        foreach (Tuple<int, Point, int> enemy in roomState.levelConfig.Enemies)
        {
            CollisionManager.Collidables.Add(
                EnemyObjectFactory.Instance.CreateEnemyById(enemy.Item1, enemy.Item2.X, enemy.Item2.Y, enemy.Item3));
        }

        foreach (Tuple<int, Point> item in roomState.levelConfig.Items)
        {
            CollisionManager.Collidables.Add(
                ItemObjectFactory.Instance.CreateItemById(item.Item1, item.Item2.X, item.Item2.Y, roomState.game.Player));
        }
    }

    public override void Update(GameTime gameTime)
    {
        foreach (Door door in roomState.doorList)
        {
            if (door.HasCollided)
            {
                Debug.WriteLine("DOOR COLLISION");
                switch (door.TransitionDirection)
                {
                    case Direction.Up:
                        TransitionUp();
                        break;
                    case Direction.Right:
                        TransitionRight();
                        break;
                    case Direction.Down:
                        TransitionDown();
                        break;
                    case Direction.Left:
                        TransitionLeft();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        Draw(spriteBatch, new Point());
    }

    public override void Draw(SpriteBatch spriteBatch, Point offset)
    {
        Rectangle bounds = new Rectangle(0, 0, 1280, 880);
        spriteBatch.Draw(TextureStorage.GetWallsSpritesheet(), bounds, Color.White);

        foreach (TileType tile in roomState.tileList)
        {
            tile.Draw(spriteBatch);
        }

        foreach (Door door in roomState.doorList)
        {
            door.Draw(spriteBatch);
        }
    }

    public void TransitionUp()
    {
        roomState.currentState = new RoomTransitionUpState(roomState);
    }
    public void TransitionRight()
    {
        roomState.currentState = new RoomTransitionRightState(roomState);
    }
    public void TransitionDown()
    {
        roomState.currentState = new RoomTransitionDownState(roomState);
    }
    public void TransitionLeft()
    {
        roomState.currentState = new RoomTransitionLeftState(roomState);
    }
}