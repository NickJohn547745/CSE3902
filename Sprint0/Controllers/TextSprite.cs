using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Controllers; 

public class TextSprite : ISprite {
    private SpriteFont font;
    private Vector2 position;

    public TextSprite(SpriteFont font) {
        this.font = font;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color) {
        
        spriteBatch.Begin();
        spriteBatch.DrawString(font, "Credits\nProgram Made By: Nathan Rogers\nSprites From: www.mariomayhem.com", position, color);
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