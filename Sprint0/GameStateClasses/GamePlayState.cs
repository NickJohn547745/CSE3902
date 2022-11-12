using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Interfaces;
using sprint0.PlayerClasses;
using Microsoft.Xna.Framework;

namespace sprint0.GameStateClasses;

public class GamePlayState : AGameState
{

    public GamePlayState(GameState state)
    {
        gameState = state;
    }

    private void PlayerDeath()
    {
        if (gameState.player.GetHealth() <= 0)
        {
            gameState.game.ResetLevel();
            gameState.player.Reset();
            gameState.currentState = new GameOverState(gameState);
        }
    }

    public override void TogglePause()
    {
        gameState.currentState = new GamePauseState(gameState);
    }

    public override void Update(GameTime gameTime)
    {
        gameState.collisionManager.Update(gameTime, gameState.game);

        gameState.mainHUD.Update(new PlayerInventory(), 3);

        PlayerDeath();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        gameState.mainHUD.Draw(spriteBatch);

        gameState.Room.Draw(spriteBatch);
        
        gameState.collisionManager.Draw(spriteBatch);
    }
}