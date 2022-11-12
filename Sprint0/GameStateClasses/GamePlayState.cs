using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Interfaces;
using sprint0.PlayerClasses;
using Microsoft.Xna.Framework;

namespace sprint0.GameStateClasses;

public class GamePlayState : GameState
{

    public GamePlayState()
    {
        
    }

    private void PlayerDeath()
    {
        if (player.GetHealth() <= 0)
        {
            game.ResetLevel();
            player.Reset();
            game.gameState = new GameOverState();
        }
    }

    public override void PauseGame()
    {
        game.gameState = new GamePauseState();
    }

    public override void Update(GameTime gameTime)
    {
        collisionManager.Update(gameTime, game);

        mainHUD.Update(new PlayerInventory(), 3);

        PlayerDeath();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        mainHUD.Draw(spriteBatch);

        Room.Draw(spriteBatch);
        
        collisionManager.Draw(spriteBatch);
    }
}