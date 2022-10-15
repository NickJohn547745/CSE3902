using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0; 

public interface ISprite {

    public int GetWidth();
    public int GetHeight(); 
    public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects);
    public void Draw(SpriteBatch spriteBatch, Vector2 position, int currentFrame, SpriteEffects spriteEffect);
}