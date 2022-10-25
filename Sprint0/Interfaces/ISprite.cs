using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0; 

public interface ISprite {

    public int GetWidth(int animationFrame = -1);
    public int GetHeight(int animationFrame = -1); 
    public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects, Color color);
    public void Draw(SpriteBatch spriteBatch, Vector2 position, int currentFrame, SpriteEffects spriteEffect, Color color);
}