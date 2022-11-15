using Microsoft.Xna.Framework.Graphics;

namespace sprint0.GameStateClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using sprint0.Classes;
using sprint0.Interfaces;

public class GameWinState : AGameState
{
    private readonly string gameOver = "You WON!!!";
    private readonly string reset = "Press 'r' to reset";
    private const float gameScale = 5;
    private const float resetScale = 3;
    private const int gameOriginX = 55;
    private const int gameOriginY = 25;
    private const int resetOriginX = 80;

    private float previous;
    public GameWinState(GameStateManager state)
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
        spriteBatch.GraphicsDevice.Clear(Color.White);
        
        float X = gameState.game.GetWindowWidth() / 2;
        float Y = gameState.game.GetWindowHeight() / 2;
        Vector2 pos = new Vector2(X, Y);

        spriteBatch.DrawString(gameState.Font, gameOver, pos, Color.Green, 0f, new Vector2(gameOriginX, gameOriginY), gameScale, SpriteEffects.None, 0f);
        spriteBatch.DrawString(gameState.Font, reset, pos, Color.DarkGreen, 0f, new Vector2(resetOriginX, 0), resetScale, SpriteEffects.None, 0f);
    }

    public override void Reset()
    {
        Unmute();
        gameState.currentState = new GamePlayState(gameState);
    }
}