using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;

namespace sprint0.PlayerClasses;

public class PlayerSwordDownState : PlayerSwordState {

    public PlayerSwordDownState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetSwordDownSprite();
        player.Damage = 0;
        swordEdge = ICollidable.Edge.Bottom;
        backEdge = ICollidable.Edge.Top;
        sword = new PlayerSword(this.player, swordEdge);
        CollisionManager.Collidables.Add(sword);
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
            player.PlayerState = new PlayerFacingDownState(player);
        }
    }
}