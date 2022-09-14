using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public interface ISprite
{
    SpriteBatch SpriteBatch { get; set; }
    Queue<Vector2> LocationQueue { get; set; }
    Texture2D Texture { get; set; }
    bool RequiresTexture { get; set; }
    SpriteFont Font { get; set; }
    string Contents { get; set; }
    int Rows { get; set; }
    int Columns { get; set; }

    void Update();
    void Draw();

}