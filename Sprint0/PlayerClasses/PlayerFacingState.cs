using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Enemies;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;

namespace sprint0.PlayerClasses; 

public abstract class PlayerFacingState : IPlayerState {
    protected const int FramesPerAnimationChange = 5;
    protected Player player;
    protected int animationFrame;
    protected int currentFrame;
    protected ICollidable.Edge shield;
    public ISprite sprite { get; set; }

    public virtual Rectangle GetHitBox()
    {
        return new Rectangle((int)player.Position.X, (int)player.Position.Y, sprite.GetWidth(), sprite.GetHeight());
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, player.Position, animationFrame, SpriteEffects.None);
    }

    public void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        Type type = obj.GetObjectType();
        if (edge != shield && (type == typeof(Enemy) || type == typeof(Projectile))) player.TakeDamage(obj.Damage);
    }

    public void Update() {
        if (currentFrame > FramesPerAnimationChange) {
            currentFrame = 0;
            animationFrame++;
        }
    }

    public virtual void MoveUp() {
        player.PlayerState = new PlayerFacingUpState(player);
    }

    public virtual void MoveDown() {
        player.PlayerState = new PlayerFacingDownState(player);
    }

    public virtual void MoveLeft() {
        player.PlayerState = new PlayerFacingLeftState(player);
    }

    public virtual void MoveRight() {
        player.PlayerState = new PlayerFacingRightState(player);
    }

    public abstract void SwordAttack();

    public abstract void UseAbility(AbilityTypes abilityType);
}