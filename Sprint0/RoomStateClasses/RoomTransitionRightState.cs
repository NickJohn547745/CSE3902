using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Configs;
using sprint0.DoorClasses;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.MenuItems.Inventory;
using System;

namespace sprint0.RoomStateClasses;

public class RoomTransitionRightState : ARoomTransitionState
{

    public RoomTransitionRightState(RoomStateManager state, bool isIncoming = false)
    {
        roomState = state;
        this.isIncoming = isIncoming;

        if (!isIncoming)
        {
            CollisionManager.Collidables.Clear();

            LevelConfig nextLevelConfig = roomState.rightRoomConfig;
            nextRoomStateManager = new RoomStateManager(roomState.game, nextLevelConfig);

            nextRoomState = new RoomTransitionRightState(nextRoomStateManager, true);
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
                roomOffset.X -= transitionStep;

                nextRoomState.roomOffset.X = 1280 + roomOffset.X;
            }
        } else
        {
            if (!isIncoming)
            {
                roomState = nextRoomStateManager;
                roomState.currentState = new RoomIdleState(nextRoomStateManager);
                roomState.game.gameState.RoomState = roomState;
                roomState.game.Player.Position = new Vector2(166, 406);

                DungeonMap.Instance.AddRoomToMap(Direction.Right);
            }
            else
            {
                isIncoming = !isIncoming;
            }
        }
    }

}