using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0.GameStateClasses;

public class GamePlayState : AGameState
{

    public GamePlayState(GameStateManager state)
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

    private void CheckWin()
    {
        if(true)
        {
            gameState.game.ResetLevel();
            gameState.player.Reset();
            gameState.currentState = new GameWinState(gameState);
        }
    }

    public override void TogglePause()
    {
        gameState.currentState = new GamePauseState(gameState);
    }

    public override void Update(GameTime gameTime)
    {
        gameState.collisionManager.Update(gameTime);

        gameState.mainHUD.Update(gameState.player.GetInventory(), gameState.player.GetHealth(), gameState.game.GetLevelIndex());

        PlayerDeath();

        // CheckWin();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        gameState.RoomState.Draw(spriteBatch);

        gameState.mainHUD.Draw(spriteBatch);

        gameState.collisionManager.Draw(spriteBatch);
    }
}