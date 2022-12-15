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

public class RoomTransitionLeftState : ARoomTransitionState
{

    public RoomTransitionLeftState(RoomStateManager state, bool isIncoming = false)
    {
        roomState = state;
        this.isIncoming = isIncoming;

        if (!isIncoming)
        {
            CollisionManager.Collidables.Clear();

            LevelConfig nextLevelConfig = roomState.leftRoomConfig;
            nextRoomStateManager = new RoomStateManager(roomState.game, nextLevelConfig);

            nextRoomState = new RoomTransitionLeftState(nextRoomStateManager, true);
            nextRoomStateManager.currentState = nextRoomState;
        }
    }

    public override void Update(GameTime gameTime)
    {
        int roomWidth = roomState.ScreenBounds.Width;

        if (Math.Abs(roomOffset.X) <= roomWidth)
        {
            if (!isIncoming)
            {
                roomOffset.X += transitionStep;

                nextRoomState.roomOffset.X = -1280 + roomOffset.X;

                roomState.game.Player.Position = new Vector2(1100 - roomState.game.Player.GetHitBox().Width, 880 / 2);
            }
        }
        else
        {
            if (!isIncoming)
            {
                roomState = nextRoomStateManager;
                roomState.currentState = new RoomIdleState(nextRoomStateManager);
                roomState.game.gameState.RoomState = roomState;

                DungeonMap.Instance.AddRoomToMap(Direction.Left);
            }
            else
            {
                isIncoming = !isIncoming;
            }
        }
    }

}