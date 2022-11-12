using sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.GameStateClasses;

public class GameOverState : AGameState
{
    
    public GameOverState(GameState state)
    {
        gameState = state;   
    }
    
    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        
    }

    public override void Reset()
    {
        gameState.currentState = new GamePlayState(gameState);
    }
}