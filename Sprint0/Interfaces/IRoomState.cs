using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses.Abilities;
using Microsoft.Xna.Framework;
using System;
using sprint0.Classes;
using sprint0.GameStateClasses;
using sprint0.RoomStateClasses;
using sprint0.Configs;

namespace sprint0.Interfaces;

public interface IRoomState
{
    public LevelConfig levelConfig { get; set; }

    public void Update(GameTime gameTime);
    public void Draw(SpriteBatch spriteBatch);

    public void Initialize();
    public void Reset();
    public void TransitionState(RoomStates newState);
}