using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Managers;
using sprint0.Utility;

namespace sprint0.Interfaces; 

public class AquamentusProjectile : PhysicsProjectile {

    private const int FireBallDelay = 1;
    private const int FireBallSpeed = 200;

    public AquamentusProjectile(Vector2 position, Vector2 velocity)
    {
        Sprite = ProjectileSpriteFactory.Instance.CreateAquamentusProjectileSprite();
        Physics = new PhysicsManager(position, velocity, FireBallSpeed);
        behaviorTimer = new Timer(FireBallDelay);
        Damage = 1;
        Collision = false;
        type = ICollidable.ObjectType.Projectile;
    }

    protected override void Behavior()
    {
       // no behavior 
    }

}