using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Configs;
using sprint0.DoorClasses;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.MenuItems.Inventory;
using sprint0.RoomClasses;
using sprint0.TileClasses;
using System.Diagnostics;

namespace sprint0.RoomStateClasses;

public abstract class ARoomTransitionState : ARoomState
{
    internal int transitionStep = 5;

    internal RoomStateManager nextRoomStateManager;
    internal ARoomState nextRoomState;

    internal bool isIncoming = false;

    public override void Draw(SpriteBatch spriteBatch)
    {
        Draw(spriteBatch, new Point());
    }

    public override void Draw(SpriteBatch spriteBatch, Point offset)
    {
        Point newRoomOffset = roomOffset;
        newRoomOffset.X -= 1280;
        if (!isIncoming)
        {
            nextRoomStateManager.Draw(spriteBatch, newRoomOffset);
        }

        Rectangle screenBounds = new Rectangle(0, 0, 1280, 880);
        screenBounds.Location += roomOffset;

        spriteBatch.Draw(TextureStorage.GetWallsSpritesheet(), screenBounds, Color.White);

        foreach (TileType tile in roomState.tileList)
        {
            tile.Draw(spriteBatch, roomOffset);
        }

        foreach (Door door in roomState.doorList)
        {
            door.Draw(spriteBatch, roomOffset);
        }
    }

    public override void Reset()
    {
        ReturnToIdle();
    }

    public void ReturnToIdle()
    {
        nextRoomState.roomOffset = new Point();
        roomState.currentState = nextRoomState;

        roomState.game.gameState.RoomState = nextRoomStateManager;

    }
}