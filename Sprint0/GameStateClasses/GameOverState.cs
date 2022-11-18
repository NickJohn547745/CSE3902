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

    private float previous;

    public GameOverState(GameStateManager state)
    {
        gameState = state;
        Mute();
    }

    private void Mute()
    {
        previous = SoundEffect.MasterVolume;
        SoundEffect.MasterVolume = 0.0f;
    }

    private void Unmute()
    {
        SoundEffect.MasterVolume = previous;
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        float X = Game1.WindowWidth / 2;
        float Y = Game1.WindowHeight / 2;
        Vector2 pos = new Vector2(X, Y);

        spriteBatch.DrawString(gameState.Font, gameOver, pos, Color.Red, 0f, new Vector2(gameOriginX, gameOriginY), gameScale, SpriteEffects.None, 0f);
        spriteBatch.DrawString(gameState.Font, reset, pos, Color.DarkRed, 0f, new Vector2(resetOriginX, 0), resetScale, SpriteEffects.None, 0f);
    }

    public override void Reset()
    {
        Unmute();
        gameState.currentState = new GamePlayState(gameState);
    }
}