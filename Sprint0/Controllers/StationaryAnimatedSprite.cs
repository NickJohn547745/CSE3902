using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Controllers; 

public class StationaryAnimatedSprite : ISprite {
    private Texture2D texture;
    private int frame = 0;
    private int direction = 1;

    private Rectangle[] spriteLocations = {new Rectangle(209, 122, 16, 31), new Rectangle(389, 128, 16, 21), new Rectangle(362, 122, 16, 32) };
    /* Frame 1
     * Top Left: (209, 122)
     * Bottom Right: (225, 153)
     * Frame 2
     * Top Left: (389, 127)
     * Bottom Right: (404, 148)
     * Frame 3:
     * Top Left: (362, 122)
     * Bottom Right: (377, 153)
     */
    public StationaryAnimatedSprite(Texture2D tex) {
        this.texture = tex;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color) {
        if (frame == 75) {
            direction = -1;
        }

        if (frame == 0) {
            direction = 1;
        }

        Rectangle view = new Rectangle(380, 280 + (32 - spriteLocations[frame / 30].Height)*2, spriteLocations[frame / 30].Width * 2,
            spriteLocations[frame / 30].Height * 2);
        
        spriteBatch.Begin();
        spriteBatch.Draw(texture, view, spriteLocations[frame/30], color);
        spriteBatch.End();
        frame += direction;
    }
}