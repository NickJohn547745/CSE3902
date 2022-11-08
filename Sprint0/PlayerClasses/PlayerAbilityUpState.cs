using sprint0.Factories;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses; 

public class PlayerAbilityUpState : PlayerAbilityState {
    public PlayerAbilityUpState(Player player) {
        this.player = player;
        frameCount = 21;
        sprite = PlayerSpriteFactory.Instance.GetAbilityUpSprite();
        player.Damage = 0;
        facing = ICollidable.Edge.Top;
    }

    public override void Update()
    {
        frameCount--;
        if (frameCount == 0)
        {
            player.PlayerState = new PlayerFacingUpState(player);
        }
    }
}