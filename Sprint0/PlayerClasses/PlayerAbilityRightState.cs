using sprint0.Factories;

namespace sprint0.PlayerClasses; 

public class PlayerAbilityRightState : PlayerAbilityState{

    public PlayerAbilityRightState(Player player) {
        this.player = player;
        frameCount = 21;
        sprite = PlayerSpriteFactory.Instance.GetAbilitySideSprite();
        player.Damage = 0;
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