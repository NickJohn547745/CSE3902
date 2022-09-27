using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0; 

public interface ISprite {
    public void Draw(SpriteBatch spriteBatch, Vector2 position);
}