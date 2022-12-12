using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Enemies;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;
using static sprint0.Interfaces.ICollidable;

namespace sprint0.PlayerClasses; 

public abstract class PlayerWandState : IPlayerState {
    protected Player player;
    protected int animationFrame = 0;
    protected int currentFrame = 0;
    protected const int FramesPerAnimationChange = 3;
    public ISprite sprite { get; set; }

    public abstract Rectangle GetHitBox();
    public virtual void Draw(SpriteBatch spriteBatch, Color color)
    {
        sprite.Draw(spriteBatch, player.Position, animationFrame, SpriteEffects.None, color);
    }

    public void Collide(ICollidable obj, Edge edge)
    {
  
    }

    public abstract void Update();

    public void PrimaryAttack() {
        // Already in attack state
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