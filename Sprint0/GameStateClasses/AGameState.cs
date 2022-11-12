using sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.PlayerClasses;
using sprint0.RoomClasses;

namespace sprint0.GameStateClasses;

public abstract class AGameState : IGameState
{
    
    protected GameState gameState;

    public Room Room { get; set; }

    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);

    public virtual void TogglePause()
    {
        
    }
    
    public void Reset()
    {
        
    }
}