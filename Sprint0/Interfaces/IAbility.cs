using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Interfaces; 

public interface IAbility {
    public void Update();

    public void Draw(SpriteBatch spriteBatch);
}