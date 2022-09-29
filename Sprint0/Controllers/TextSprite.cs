using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Controllers; 

public class TextSprite : ISprite {
    private SpriteFont font;

    public TextSprite(SpriteFont font) {
        this.font = font;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position) {
        spriteBatch.DrawString(font, "Credits\nProgram Made By: Nathan Rogers\nSprites From: www.mariomayhem.com", position, Color.White);
    }
}