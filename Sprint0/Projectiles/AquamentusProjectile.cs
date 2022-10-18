using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Enemies;

namespace sprint0.Interfaces; 

public class AquamentusProjectile : Projectile {

    private const int fireBallDelay = 1;
    private const int fireBallSpeed = 200;

    public AquamentusProjectile(Vector2 position, Vector2 velocity)
    {
        initPosition = position;
        Position = position;
        Sprite = ProjectileSpriteFactory.Instance.CreateAquamentusProjectileSprite();
        Velocity = velocity;
        speed = fireBallSpeed;
        delay = fireBallDelay;
        Damage = 1;
        Collision = false;
    }

    protected override void Behavior(Game1 game)
    {
       // no behavior 
    }

}