using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;
using Microsoft.Xna.Framework;

namespace sprint0.PlayerClasses;

public class PlayerWandDownState : PlayerWandState {

    public PlayerWandDownState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWandDownSprite();
        player.Damage = 0;
        
        CollisionManager.Collidables.Add(new WandProjectile(Vector2.Add(player.Position, new Vector2(0, sprite.GetHeight())), new Vector2(0, 1)));
    }

    public override Rectangle GetHitBox()
    {
        return new Rectangle((int)player.Position.X, (int)player.Position.Y, sprite.GetWidth(animationFrame), sprite.GetHeight(animationFrame));
    }

    public override void Update()
    {
        if (currentFrame > FramesPerAnimationChange)
        {
            currentFrame = 0;
            animationFrame++;
        }

        currentFrame++;

        if (animationFrame == 4)
        {
            player.PlayerState = new PlayerFacingDownState(player);
        }
    }
}