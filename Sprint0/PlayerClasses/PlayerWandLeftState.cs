using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.Projectiles;

namespace sprint0.PlayerClasses;

public class PlayerWandLeftState : PlayerSwordState {

    public PlayerWandLeftState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWandSideSprite();
        
        CollisionManager.Collidables.Add(new WandProjectile(Vector2.Add(player.Position, new Vector2(-64, 0)), new Vector2(-1, 0)));
    }

    public override Rectangle GetHitBox()
    {
        return new Rectangle((int) player.Position.X, (int) player.Position.Y, sprite.GetWidth() - (sprite.GetWidth()-64), sprite.GetHeight());
    }

    public override void Draw(SpriteBatch spriteBatch, Color color)
    {
        sprite.Draw(spriteBatch, new Vector2(player.Position.X - (sprite.GetWidth(animationFrame)-64), player.Position.Y), animationFrame, SpriteEffects.FlipHorizontally, color);
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
            player.PlayerState = new PlayerFacingLeftState(player);
        }
    }
}