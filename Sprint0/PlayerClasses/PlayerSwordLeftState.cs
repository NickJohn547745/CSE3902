using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;


namespace sprint0.PlayerClasses;

public class PlayerSwordLeftState : PlayerSwordState {

    public PlayerSwordLeftState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetSwordSideSprite();
        player.Damage = 0;
        swordEdge = ICollidable.Edge.Left;
        backEdge = ICollidable.Edge.Right;
        sword = new PlayerSword(this.player, swordEdge);
        CollisionManager.Collidables.Add(sword);
    }

    public override Rectangle GetHitBox()
    {
        return new Rectangle((int) player.Position.X - (sprite.GetWidth(animationFrame) - 64), (int) player.Position.Y, sprite.GetWidth(), sprite.GetHeight());
    }

    public override void Draw(SpriteBatch spriteBatch, Color color)
    {
        sprite.Draw(spriteBatch, new Vector2(player.Position.X - (sprite.GetWidth(animationFrame) - 64), player.Position.Y), animationFrame, SpriteEffects.FlipHorizontally, color);
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
            CollisionManager.Collidables.Remove(sword);
            player.PlayerState = new PlayerFacingLeftState(player);
        }
    }
}