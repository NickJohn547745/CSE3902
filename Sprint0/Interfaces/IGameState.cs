using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses.Abilities;
using Microsoft.Xna.Framework;
using System;
using sprint0.Classes;
using sprint0.RoomClasses;

namespace sprint0.Interfaces; 

public interface IGameState
{
    public Room Room { get; set; }
    public void Update(GameTime gameTime);
    public void Draw(SpriteBatch spriteBatch);
    public void TogglePause();
    public void Reset();
}