using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace sprint0.GameStateClasses;


public class GamePauseState : AGameState
{
    private readonly string pause = "Paused";
    private const float gameScale = 5;
    private const int gameOriginX = 39;
    private const int gameOriginY = 35;
    private Vector2 textPos;

    public GamePauseState(GameStateManager state)
    {
        gameState = state;       
        gameState.game.Paused = true;
        Mute();
        textPos = new Vector2(Game1.WindowWidth / 2, Game1.WindowHeight / 2);
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void TogglePause()
    {
        gameState.game.Paused = false;

        Unmute();

        gameState.currentState = new GamePlayState(gameState);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        gameState.mainHUD.Draw(spriteBatch);

        gameState.Room.Draw(spriteBatch);

        gameState.collisionManager.Draw(spriteBatch);

        spriteBatch.DrawString(gameState.Font, pause, textPos, Color.Red, 0f, new Vector2(gameOriginX, gameOriginY), gameScale, SpriteEffects.None, 0f);
    }
}