using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Enemies;
using sprint0.Interfaces;
using sprint0.Sprites;
using System;

namespace sprint0.Interfaces; 

public abstract class Projectile : ICollidable {

    public int Damage { get; set; }
    protected float start;
    protected int delay;
    protected Vector2 Position { get; set; }
    protected Vector2 initPosition;
    protected float speed;
    public ICollidable.ObjectType type { get; set; }
    public Vector2 Velocity { get; set; }
    public ISprite Sprite { get; set; }
    public bool Collision { get; set; }

    public Type GetObjectType()
    {
        return this.GetType().BaseType;
    }

    public Rectangle GetHitBox()
    {
        return new Rectangle((int)Position.X, (int)Position.Y, Sprite.GetWidth(), Sprite.GetHeight());
    }

    public virtual void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        Collision = obj.type != ICollidable.ObjectType.Projectile && obj.type != ICollidable.ObjectType.Enemy;
    }

    protected abstract void Behavior(Game1 game);

    public virtual void Update(GameTime gameTime, Game1 game)
    {
        Position += speed * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (gameTime.TotalGameTime.Seconds % delay == 0)
        {
            Behavior(game);
        }

        if (Collision && game.CollisionManager.collidables.Contains(this)) game.CollisionManager.collidables.Remove(this);
    }
    
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, Position, SpriteEffects.None, Color.White);
    }

    public void Reset(Game1 game)
    {
        // temp
    }
}