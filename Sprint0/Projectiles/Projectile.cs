using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.Sprites;

namespace sprint0.Interfaces; 

public abstract class Projectile : ICollidable {

    public int damage { get; set; }
    protected float start;
    protected int delay;
    protected Vector2 position { get; set; }
    protected Vector2 initPosition;
    protected float speed;
    public Vector2 velocity { get; set; }
    public Sprite sprite { get; set; }

    protected abstract void Behavior(Game1 game);

    public virtual void Update(GameTime gameTime, Game1 game)
    {
        position += speed * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (gameTime.TotalGameTime.Seconds % delay == 0)
        {
            Behavior(game);
        }
    }



    public Rectangle GetHitBox()
    {
        return new Rectangle((int)position.X, (int)position.Y, sprite.GetWidth(), sprite.GetHeight());
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        sprite.Draw(spriteBatch, position);
    }

    public void Reset()
    {
        // temp
    }
}