using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Managers;
using sprint0.Projectiles;

namespace sprint0.PlayerClasses;

public class PlayerWandRightState : PlayerSwordState {
    public PlayerWandRightState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWandSideSprite();
        
        CollisionManager.Collidables.Add(new WandProjectile(Vector2.Add(player.Position, new Vector2(64, 0)), new Vector2(1, 0)));
    }
    public override Rectangle GetHitBox()
    {
        return new Rectangle((int)player.Position.X, (int)player.Position.Y, sprite.GetWidth(animationFrame) - (sprite.GetWidth(animationFrame)-64), sprite.GetHeight(animationFrame));
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
            player.PlayerState = new PlayerFacingRightState(player);
        }
    }
}