using sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace sprint0.GameStateClasses;

public class GameOverState : AGameState
{
    private readonly string gameOver = "Game Over";
    private readonly string reset = "Press 'r' to reset";
    private const float gameScale = 5;
    private const float resetScale = 3;
    private const int gameOriginX = 55;
    private const int gameOriginY = 25;
    private const int resetOriginX = 80;
    private Vector2 pos;

    public GameOverState(GameStateManager state)
    {
        gameState = state;
        Mute();
        pos = new Vector2(Game1.WindowWidth / 2, Game1.WindowHeight / 2);
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(gameState.Font, gameOver, pos, Color.Red, 0f, new Vector2(gameOriginX, gameOriginY), gameScale, SpriteEffects.None, 0f);
        spriteBatch.DrawString(gameState.Font, reset, pos, Color.DarkRed, 0f, new Vector2(resetOriginX, 0), resetScale, SpriteEffects.None, 0f);
    }

    public override void Reset()
    {
        Unmute();
        gameState.currentState = new GamePlayState(gameState);
    }
}