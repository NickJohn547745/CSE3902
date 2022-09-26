using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Controllers; 

public class MovingStaticSprite : ISprite {
    private Texture2D texture;
    private Vector2 position;
    private int frame = 0;
    private int direction = -1;

    public MovingStaticSprite(Texture2D tex) {
        this.texture = tex;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color) {
        if (frame == 90) {
            direction = -1;
        }

        if (frame == 0) {
            direction = 1;
        }

        Rectangle view = new Rectangle(380, 260-frame, 28, 26);
        
        spriteBatch.Begin();
        spriteBatch.Draw(texture, view, new Rectangle(0, 0, 24, 32), color);
        spriteBatch.End();
        
        frame += direction;
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