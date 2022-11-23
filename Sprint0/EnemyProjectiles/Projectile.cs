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
        switch (obj.type)
        {
            case ICollidable.ObjectType.Door:
            case ICollidable.ObjectType.Wall:
            case ICollidable.ObjectType.Tile:
            case ICollidable.ObjectType.Player:
                Collision = true;   
                break;
        }
    }

    protected abstract void Behavior();

    public virtual void Update(GameTime gameTime)
    {
        Position += speed * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (gameTime.TotalGameTime.Seconds % delay == 0)
        {
            Behavior();
        }

        if (Collision && CollisionManager.Collidables.Contains(this)) CollisionManager.Collidables.Remove(this);
    }
    
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, Position, SpriteEffects.None, Color.White);
    }

    public void Reset()
    {
        // temp
    }
}