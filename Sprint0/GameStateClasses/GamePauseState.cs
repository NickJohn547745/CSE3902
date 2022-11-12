using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace sprint0.GameStateClasses;


public class GamePauseState : AGameState
{
    private float previous;
    public GamePauseState(GameState state)
    {
        gameState = state;       
        gameState.game.Paused = true;
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

    public override void TogglePause()
    {
        gameState.game.Paused = false;

        Unmute();

        gameState.game.state = new GamePlayState(gameState);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        gameState.mainHUD.Draw(spriteBatch);

        gameState.Room.Draw(spriteBatch);

        gameState.collisionManager.Draw(spriteBatch);
    }
}