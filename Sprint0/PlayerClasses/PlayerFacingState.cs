using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

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

    public virtual void Draw(SpriteBatch spriteBatch, Color color)
    {
       
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, player.Position, animationFrame, SpriteEffects.None, color);
    }

    private void Knockback()
    {
        switch (shield)
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
        switch (obj.type)
        {
            case ICollidable.ObjectType.Enemy:
            case ICollidable.ObjectType.Trap:
            case ICollidable.ObjectType.Projectile:
                if (edge != shield)
                {
                    player.TakeDamage(obj.Damage);
                    Knockback();
                }
                break;
            case ICollidable.ObjectType.ItemOneHand:
                player.PlayerState = new PlayerItemPickupState(player, 2);
                break;
            case ICollidable.ObjectType.ItemTwoHands:
                player.PlayerState = new PlayerItemPickupState(player, 1);
                break;

        }
    }

    public void Update() {
        if (currentFrame > FramesPerAnimationChange) {
            currentFrame = 0;
            animationFrame++;
        }

        if (!player.CanMove) player.Position = player.PreviousPosition;
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