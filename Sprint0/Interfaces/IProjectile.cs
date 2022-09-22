using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Interfaces; 

public interface IProjectile {
    public Rectangle GetPosition();

    public void Update(GameTime gameTime);

    public void Draw(SpriteBatch spriteBatch);
}