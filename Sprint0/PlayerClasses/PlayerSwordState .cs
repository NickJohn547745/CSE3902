using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Commands;
using sprint0.Enemies;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;

namespace sprint0.PlayerClasses; 

public abstract class PlayerSwordState : IPlayerState {
    protected Player player;
    protected int animationFrame = 0;
    protected int currentFrame = 0;
    protected const int FramesPerAnimationChange = 3;
    protected ICollidable.Edge swordEdge;
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
        if (type == typeof(Enemy))
        {
            if (edge == swordEdge)
            {
                player.Damage = 1;
            } else
            {
                player.TakeDamage(obj.Damage);
            }
        }
    }

    public abstract void Update();

    public void SwordAttack() {
        // Already in sword attack state
    }

    public void MoveUp() {
        // Can't move during sword animation
    }

    public void MoveDown() {
        // Can't move during sword animation
    }

    public void MoveLeft() {
        // Can't move during sword animation
    }

    public void MoveRight() {
        // Can't move during sword animation
    }
    
    public void UseAbility(AbilityTypes abilityType) {
        
    }
    
}