using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Managers;
using System;
using sprint0.Utility;

namespace sprint0.Interfaces;

public abstract class PhysicsProjectile : ICollidable {

    public int Damage { get; set; }
    protected float start;
    protected Timer behaviorTimer;
    protected PhysicsManager Physics { get; set;}
    public ICollidable.ObjectType Type { get; set; }
    public ISprite Sprite { get; set; }
    public bool Collision { get; set; }

    public Type GetObjectType()
    {
        return this.GetType().BaseType;
    }

    public Direction GetMoveDirection()
    {
        return Physics.Direction;
    }

    public Rectangle GetHitBox()
    {
        return new Rectangle((int)Physics.CurrentPosition.X, (int)Physics.CurrentPosition.Y, Sprite.GetWidth(), Sprite.GetHeight());
    }

    public virtual void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        switch (obj.Type)
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
        Physics.Move(gameTime);

        if (behaviorTimer.UnconditionalUpdate())
        {
            Behavior();
        }

        if (Collision && CollisionManager.Collidables.Contains(this)) CollisionManager.Collidables.Remove(this);
    }
    
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, Physics.CurrentPosition, SpriteEffects.None, Color.White);
    }

    public void Reset()
    {
        CollisionManager.Collidables.Remove(this);
    }
}