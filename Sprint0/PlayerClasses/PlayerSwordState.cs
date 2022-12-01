using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Enemies;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;
using static sprint0.Interfaces.ICollidable;

namespace sprint0.PlayerClasses; 

public abstract class PlayerSwordState : IPlayerState {
    private const int playerWH = 15;
    private readonly int[] swordLen = { 0, 11, 7, 3 };
    protected Player player;
    protected int animationFrame = 0;
    protected int currentFrame = 0;
    protected const int FramesPerAnimationChange = 3;
    protected Edge swordEdge;
    protected Edge backEdge;
    protected PlayerSword sword;
    public ISprite sprite { get; set; }

    public virtual Rectangle GetHitBox()
    {
        return new Rectangle((int) player.Position.X, (int) player.Position.Y, sprite.GetWidth(animationFrame), sprite.GetHeight(animationFrame));
    }

    public virtual void Draw(SpriteBatch spriteBatch, Color color)
    {
        sprite.Draw(spriteBatch, player.Position, animationFrame, SpriteEffects.None, color);
    }

    private void Knockback()
    {
        switch (swordEdge)
        {
            case Edge.Top:
                player.InitVelocity = new Vector2(0, 300);
                break;
            case Edge.Right:
                player.InitVelocity = new Vector2(-300, 0);
                break;
            case Edge.Left:
                player.InitVelocity = new Vector2(300, 0);
                break;
            case Edge.Bottom:
                player.InitVelocity = new Vector2(0, -300);
                break;
        }

        player.Velocity = player.InitVelocity;
    }
    
    public void Collide(ICollidable obj, Edge edge)
    {
        //if (obj.Type == ObjectType.Enemy || obj.Type == ObjectType.Projectile)
        //{
        //    if (edge == backEdge)
        //    {
        //        player.TakeDamage(obj.Damage);
        //        Knockback();
        //    }
        //}
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