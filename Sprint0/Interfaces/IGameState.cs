using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses.Abilities;
using Microsoft.Xna.Framework;
using System;
using sprint0.Classes;

namespace sprint0.Interfaces; 

public interface IGameState
{
    public void Update(GameTime gameTime);
    public void Draw(GameTime gameTime);
    public void Reset();
}