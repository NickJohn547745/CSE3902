using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses; 

public class PlayerSwordUpState : PlayerSwordState {
    public PlayerSwordUpState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetSwordUpSprite();
        player.Damage = 0;
        swordEdge = ICollidable.Edge.Top;
        backEdge = ICollidable.Edge.Bottom;
        sword = new PlayerSword(this.player, swordEdge);
        this.player.Game.CollisionManager.collidables.Add(sword);
    }
    public override Rectangle GetHitBox()
    {
        return new Rectangle((int) player.Position.X, (int) player.Position.Y - (sprite.GetHeight(animationFrame) - 64), sprite.GetWidth(), sprite.GetHeight());
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
            sword.currentFrame = animationFrame;
        }

        currentFrame++;

        if (animationFrame == 4)
        {
            player.Game.CollisionManager.collidables.Remove(sword);
            player.PlayerState = new PlayerFacingUpState(player);        
        }
    }
}