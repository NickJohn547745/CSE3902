using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Controllers; 

public class StationaryStaticSprite : ISprite {
    Texture2D texture;
    
    private Vector2 position;
    public StationaryStaticSprite(Texture2D tex) {
        this.texture = tex;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color) {
        Rectangle sourceRectangle = new Rectangle(0, 0, 24, 32);
        
        spriteBatch.Begin();
        spriteBatch.Draw(texture, new Rectangle(380, 260, 26, 32), sourceRectangle, color);
        spriteBatch.End();
    }

    public void MoveRight()
    {
        position.X++;
    }

    public void MoveLeft()
    {
        position.X--;
    }

    public void MoveUp()
    {
        position.Y--;
    }

    public void MoveDown()
    {
        position.Y++;
    }
}