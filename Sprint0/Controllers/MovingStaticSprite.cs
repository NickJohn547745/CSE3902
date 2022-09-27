using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Controllers; 

public class MovingStaticSprite : ISprite {
    private Texture2D texture;
    private int frame = 0;
    private int direction = -1;

    public MovingStaticSprite(Texture2D tex) {
        this.texture = tex;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position) {
        if (frame == 90) {
            direction = -1;
        }

        if (frame == 0) {
            direction = 1;
        }

        Rectangle view = new Rectangle(380, 260-frame, 28, 26);
        
        spriteBatch.Draw(texture, view, new Rectangle(0, 16, 14, 13), Color.White);
        
        frame += direction;
    }
}