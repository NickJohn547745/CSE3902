using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.Utility;

namespace sprint0.Projectiles; 

public class WandProjectile : PhysicsProjectile {

    private const int FireBallDelay = 1;
    private const int FireBallSpeed = 200;

    private SpriteEffects Effect { get; set; }

    public WandProjectile(Vector2 position, Vector2 velocity)
    {
        Effect = SpriteEffects.None;
        if (velocity.X == 0)
        {
            Sprite = PlayerSpriteFactory.Instance.GetWandProjectileVerticalSprite();
            if (velocity.Y > 0)
            {
                Effect = SpriteEffects.FlipVertically;
            }
        }
        else
        {
            Sprite = PlayerSpriteFactory.Instance.GetWandProjectileHorizontalSprite();
            if (velocity.X < 0)
            {
                Effect = SpriteEffects.FlipHorizontally;
            }
        }
        Physics = new PhysicsManager(position, Vector2.Multiply(velocity, new Vector2(2)), FireBallSpeed);
        behaviorTimer = new Timer(FireBallDelay);
        Damage = 1;
        Collision = false;
        Type = ICollidable.ObjectType.Ability;
    }

    protected override void Behavior()
    {
        // no behavior 
    }
    
    public override void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        switch (obj.Type)
        {
            case ICollidable.ObjectType.Door:
            case ICollidable.ObjectType.Wall:
            case ICollidable.ObjectType.Enemy:
                Collision = true;   
                break;
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, Physics.CurrentPosition, Effect, Color.White);
    }
}