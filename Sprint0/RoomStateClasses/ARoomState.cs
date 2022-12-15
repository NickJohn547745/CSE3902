using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using sprint0.RoomClasses;

namespace sprint0.RoomStateClasses;

public abstract class ARoomState
{
    
    protected RoomStateManager roomState;
    protected float previous;

    internal Point roomOffset = new Point(0, 0);

    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);
    public abstract void Draw(SpriteBatch spriteBatch, Point offset);

    public virtual void Reset()
    {
        
    }
}