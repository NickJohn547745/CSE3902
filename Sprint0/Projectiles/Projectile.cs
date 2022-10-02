using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.Sprites;

namespace sprint0.Interfaces; 

public abstract class Projectile : IProjectile {

    public int damage { get; set; }
    protected float start;
    protected int delay;
    protected Vector2 position { get; set; }
    protected Vector2 initPosition;
    protected float speed;
    public Vector2 velocity { get; set; }
    public Sprite sprite { get; set; }

    public Rectangle GetPosition()
    {
        throw new System.NotImplementedException();
    }

    protected abstract void Behavior(Game1 game);

    public virtual void Update(GameTime gameTime, Game1 game)
    {
        this.position += this.speed * this.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (gameTime.TotalGameTime.Seconds % this.delay == 0)
        {
            Behavior(game);
        }
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        sprite.Draw(spriteBatch, position);
    }
}