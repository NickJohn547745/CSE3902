using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.Sprites;
using System;

namespace sprint0.Interfaces; 

public abstract class Projectile : ICollidable {

    public int Damage { get; set; }
    protected float start;
    protected int delay;
    protected Vector2 position { get; set; }
    protected Vector2 initPosition;
    protected float speed;
    public Vector2 velocity { get; set; }
    public ISprite sprite { get; set; }

    public Type GetObjectType()
    {
        return this.GetType().BaseType;
    }

    public Rectangle GetHitBox()
    {
        return new Rectangle((int)position.X, (int)position.Y, sprite.GetWidth(), sprite.GetHeight());
    }

    public void Collide(ICollidable obj, ICollidable.Edge edge)
    {

    }

    protected abstract void Behavior(Game1 game);

    public virtual void Update(GameTime gameTime, Game1 game)
    {
        position += speed * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (gameTime.TotalGameTime.Seconds % delay == 0)
        {
            Behavior(game);
        }
    }
    
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        sprite.Draw(spriteBatch, position, SpriteEffects.None);
    }

    public void Reset()
    {
        // temp
    }
}