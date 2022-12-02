using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;

namespace sprint0.PlayerClasses;

public class PlayerSwordRightState : PlayerSwordState {
    public PlayerSwordRightState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetSwordSideSprite();
        player.Damage = 0;
        swordEdge = ICollidable.Edge.Right;
        sword = new PlayerSword(this.player, swordEdge);
        CollisionManager.Collidables.Add(sword);
    }
    public override Rectangle GetHitBox()
    {
        int swordWidth = sword.GetHitBox().Width;
        return new Rectangle((int)player.Position.X, (int)player.Position.Y, sprite.GetWidth(animationFrame) - swordWidth, sprite.GetHeight(animationFrame));
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
            player.PlayerState = new PlayerFacingRightState(player);
        }
    }
}