using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Interfaces; 

public interface IAbility {
    Vector2 Position { get; set; }
    void Update();

    void Draw(SpriteBatch spriteBatch);
}