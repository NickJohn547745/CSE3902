using sprint0.Factories;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses; 

public class PlayerAbilityRightState : PlayerAbilityState{

    public PlayerAbilityRightState(Player player) {
        this.player = player;
        frameCount = 21;
        sprite = PlayerSpriteFactory.Instance.GetAbilitySideSprite();
        player.Damage = 0;
        facing = ICollidable.Edge.Right;
    }
    public override void Update()
    {
        frameCount--;
        if (frameCount == 0)
        {
            player.PlayerState = new PlayerFacingRightState(player);
        }
    }
}