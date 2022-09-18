using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Controllers; 

public class StationaryStaticSprite : ISprite {
    Texture2D texture;
    
    public StationaryStaticSprite(Texture2D tex) {
        this.texture = tex;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color) {
        Rectangle sourceRectangle = new Rectangle(211,0, 13, 16);
        
        spriteBatch.Begin();
        spriteBatch.Draw(texture, new Rectangle(380, 260, 26, 32), sourceRectangle, color);
        spriteBatch.End();
    }

}