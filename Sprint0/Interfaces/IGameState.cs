using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses.Abilities;
using Microsoft.Xna.Framework;
using System;
using sprint0.Classes;
using sprint0.GameStateClasses;
using sprint0.RoomStateClasses;

namespace sprint0.Interfaces;

public interface IGameState
{
    public AGameState currentState { get; set; }
    public IRoomState RoomState { get; set; }
    public void Update(GameTime gameTime);
    public void Draw(SpriteBatch spriteBatch);
    public void TogglePause();
    public void Reset();
    public void TransitionState(GameStates newState);
}