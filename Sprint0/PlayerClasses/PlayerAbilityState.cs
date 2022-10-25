using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Enemies;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;

namespace sprint0.PlayerClasses; 

public abstract class PlayerAbilityState : IPlayerState {
    protected Player player;
    protected int frameCount;
    protected ICollidable.Edge facing;
    public ISprite sprite { get; set; }

    public virtual Rectangle GetHitBox()
    {
        return new Rectangle((int)player.Position.X, (int)player.Position.Y, sprite.GetWidth(), sprite.GetHeight());
    }

    public virtual void Draw(SpriteBatch spriteBatch, Color color)
    {
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, player.Position, SpriteEffects.None, color);
    }

    private void Knockback()
    {
        switch (facing)
        {
            case ICollidable.Edge.Top:
                player.InitVelocity = new Vector2(0, 300);
                break;
            case ICollidable.Edge.Right:
                player.InitVelocity = new Vector2(-300, 0);
                break;
            case ICollidable.Edge.Left:
                player.InitVelocity = new Vector2(300, 0);
                break;
            case ICollidable.Edge.Bottom:
                player.InitVelocity = new Vector2(0, -300);
                break;
        }

        player.Velocity = player.InitVelocity;
    }
    
    public void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        if (obj.type == ICollidable.objectType.Enemy || obj.type == ICollidable.objectType.Projectile)
        {
            player.TakeDamage(obj.Damage);
            Knockback();
        }
    }

    public abstract void Update();

    public void MoveUp() {
        // Can't move while using ability
    }

    public void MoveDown() {
        // Can't move while using ability
    }

    public void MoveLeft() {
        // Can't move while using ability
    }

    public void MoveRight() {
        // Can't move while using ability
    }

    public void SwordAttack() {
        // Can't attack while using ability
    }

    public void UseAbility(AbilityTypes abilityType) {
        // Can't use ability while already using ability
    }
}