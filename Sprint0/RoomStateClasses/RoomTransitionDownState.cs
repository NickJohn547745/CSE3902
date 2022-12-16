using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Configs;
using sprint0.DoorClasses;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.MenuItems.Inventory;
using System;
using System.Diagnostics;

namespace sprint0.RoomStateClasses;

public class RoomTransitionDownState : ARoomTransitionState
{

    public RoomTransitionDownState(RoomStateManager state, bool isIncoming = false)
    {
        roomState = state;
        this.isIncoming = isIncoming;

        if (!isIncoming)
        {
            CollisionManager.Collidables.Clear();

            LevelConfig nextLevelConfig = roomState.downRoomConfig;
            nextRoomStateManager = new RoomStateManager(roomState.game, nextLevelConfig);

            nextRoomState = new RoomTransitionDownState(nextRoomStateManager, true);
            nextRoomStateManager.currentState = nextRoomState;
        }
    }

    public override void Update(GameTime gameTime)
    {
        int roomHeight = roomState.ScreenBounds.Height;
        if (Math.Abs(roomOffset.Y) <= 880)
        {
            if (!isIncoming)
            {
                roomOffset.Y -= transitionStep;

                nextRoomState.roomOffset.Y = 880 + roomOffset.Y;
            }
           }
        else
        {
            if (!isIncoming)
            {
                roomState = nextRoomStateManager;
                roomState.currentState = new RoomIdleState(nextRoomStateManager);
                roomState.game.gameState.RoomState = roomState;
                roomState.game.Player.Position = new Vector2(607, 167);

                DungeonMap.Instance.AddRoomToMap(Direction.Down);
                CollisionManager.Collidables.Add(roomState.game.Player);
            }
            else
            {
                isIncoming = !isIncoming;
            }
        }
    }

}