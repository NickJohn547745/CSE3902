using sprint0.Factories;

namespace sprint0.PlayerClasses; 

public class PlayerAbilityUpState : PlayerAbilityState {
    public PlayerAbilityUpState(Player player) {
        this.player = player;
        frameCount = 21;
        sprite = PlayerSpriteFactory.Instance.GetAbilityUpSprite();
        player.Damage = 0;
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