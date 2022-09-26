using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace sprint0.Controllers;

public class MovingAnimatedSprite : ISprite {
    private Texture2D texture;
    private Vector2 position = new Vector2(0, 0);
    private int frame = 0;

    private Rectangle[] spriteLocations =
        {   new Rectangle(0, 0, 15, 16),
            new Rectangle(0, 16, 15, 16)
        };

    public MovingAnimatedSprite(Texture2D tex)
    {
        texture = tex;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
    {
        Rectangle view = new Rectangle((int)this.position.X, (int)this.position.Y, 24, 32);

        if (frame / 30 > 1)
            frame = 0;

        spriteBatch.Begin();
        spriteBatch.Draw(texture, view, spriteLocations[frame / 30], color);
        spriteBatch.End();

        frame++;
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