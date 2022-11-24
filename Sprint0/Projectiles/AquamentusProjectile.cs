using Microsoft.Xna.Framework;
using sprint0.Factories;

namespace sprint0.Interfaces; 

public class AquamentusProjectile : PhysicsProjectile {

    private const int FireBallDelay = 1;
    private const int FireBallSpeed = 200;

    public AquamentusProjectile(Vector2 position, Vector2 velocity)
    {
        initPosition = position;
        Position = position;
        Sprite = ProjectileSpriteFactory.Instance.CreateAquamentusProjectileSprite();
        Velocity = velocity;
        speed = FireBallSpeed;
        delay = FireBallDelay;
        Damage = 1;
        Collision = false;
        type = ICollidable.ObjectType.Projectile;
    }

    protected override void Behavior()
    {
       // no behavior 
    }

}