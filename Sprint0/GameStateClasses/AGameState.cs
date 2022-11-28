using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using sprint0.RoomClasses;

namespace sprint0.GameStateClasses;

public abstract class AGameState
{
    
    protected GameStateManager gameState;
    protected float previous;

    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);

    protected void Mute()
    {
        previous = SoundEffect.MasterVolume;
        SoundEffect.MasterVolume = 0.0f;
    }

    protected void Unmute()
    {
        SoundEffect.MasterVolume = previous;
    }

    public virtual void TogglePause()
    {
        
    }
    
    public virtual void Reset()
    {
        
    }
}