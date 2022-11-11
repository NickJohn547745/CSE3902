using sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace sprint0.GameStateClasses;

public abstract class GameState : IGameState
{
    private Game1 Game;
    
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(GameTime gameTime);

    
    public void Reset()
    {
        
    }
}