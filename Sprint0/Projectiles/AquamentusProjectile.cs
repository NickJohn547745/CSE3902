using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Sprites;

namespace sprint0.Interfaces; 

public class AquamentusProjectile : Projectile {

    private const int fireBallDelay = 1;
    private const int fireBallSpeed = 200;

    public AquamentusProjectile(Vector2 position, Vector2 velocity)
    {
        initPosition = position;
        this.position = position;
        sprite = ProjectileSpriteFactory.Instance.CreateAquamentusProjectileSprite();
        this.velocity = velocity;
        speed = fireBallSpeed;
        delay = fireBallDelay;
    }

    protected override void Behavior(Game1 game)
    {
       // no behavior 
    }

}