using sprint0.Factories;
using sprint0.Interfaces;


namespace sprint0.PlayerClasses; 

public class PlayerSwordDownState : PlayerSwordState {

    public PlayerSwordDownState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetSwordDownSprite();
        player.Damage = 0;
        swordEdge = ICollidable.Edge.Top;
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