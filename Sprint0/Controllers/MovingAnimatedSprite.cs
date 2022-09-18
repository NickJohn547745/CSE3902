using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Controllers;

public class MovingAnimatedSprite : ISprite {
    private Texture2D texture;
    private int delay = 0;
    private int animationFrame = 0;
    private int xPos = 400;

    private Rectangle[] spriteLocations =
        { new Rectangle(90, 53, 16, 30), new Rectangle(121, 52, 14, 31), new Rectangle(150, 52, 17, 32) };

    /*
     * (90, 53) 16w, 30h
     * (121, 52) 14w, 31h
     * (150, 52) 17w, 32h
     */
    public MovingAnimatedSprite(Texture2D tex) {
        texture = tex;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color) {
        if (xPos < -16) {
            xPos = 800;
        }

        if (animationFrame == 3) {
            animationFrame = 0;
        }

        Rectangle view = new Rectangle(xPos, 240 + (32 - spriteLocations[animationFrame].Height) * 2,
            spriteLocations[animationFrame].Width * 2,
            spriteLocations[animationFrame].Height * 2);

        spriteBatch.Begin();
        spriteBatch.Draw(texture, view, spriteLocations[animationFrame], color);
        spriteBatch.End();
        if (delay == 5) {
            animationFrame += 1;
            xPos -= 5;
            delay = -1;
        }
        delay++;
    }
}