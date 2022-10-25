using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using System;

namespace sprint0.PlayerClasses.Abilities;

public abstract class Ability : ICollidable
{
    protected Player player;
    public int Damage { get; set; }
    public Vector2 Velocity { get; set; }
    public ICollidable.objectType type { get; set; }
    public ISprite sprite { get; set; }
    public Vector2 Position { get; set; }
    protected int animationFrame;

    public virtual void Collide(ICollidable obj, ICollidable.Edge edge)
    {

    }

    public Rectangle GetHitBox()
    {
        return new Rectangle((int)Position.X, (int)Position.Y, sprite.GetWidth(), sprite.GetHeight());
    }

    public abstract void Update(GameTime gameTime, Game1 game);
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        sprite.Draw(spriteBatch, Position, animationFrame, SpriteEffects.None);
    }

    public void Reset(Game1 game)
    {
     
    }
}