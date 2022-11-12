using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using Microsoft.Xna.Framework;
namespace sprint0.GameStateClasses;


public class GamePauseState : GameState
{
    
    public GamePauseState()
    {
        
    }
    
    public override void Update(GameTime gameTime)
    {
        
    }

    public override void PauseGame()
    {
        game.gameState = new GamePlayState();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        mainHUD.Draw(spriteBatch);

        Room.Draw(spriteBatch);
        
        collisionManager.Draw(spriteBatch);
    }
}