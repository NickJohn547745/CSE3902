using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.PlayerClasses;

public class PlayerWandUpState : PlayerWandState {

    public PlayerWandUpState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWandUpSprite();
        player.Damage = 0;
        
        CollisionManager.Collidables.Add(new WandProjectile(Vector2.Add(player.Position, new Vector2(0, -64)), new Vector2(0, -1)));
    }

    public override Rectangle GetHitBox()
    {
        return new Rectangle((int)player.Position.X, (int)player.Position.Y, sprite.GetWidth(animationFrame), sprite.GetHeight() - (sprite.GetHeight(animationFrame) - 64));
    }
    
    public override void Draw(SpriteBatch spriteBatch, Color color)
    {
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, new Vector2(player.Position.X, player.Position.Y - (sprite.GetHeight(animationFrame) - 64)), animationFrame, SpriteEffects.None, color);
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
            player.PlayerState = new PlayerFacingUpState(player);
        }
    }
}