using sprint0.Factories;

namespace sprint0.PlayerClasses; 

public class PlayerAbilityDownState : PlayerAbilityState {

    public PlayerAbilityDownState(Player player) {
        this.player = player;
        frameCount = 21;
        sprite = PlayerSpriteFactory.Instance.GetAbilityDownSprite();
        player.Damage = 0;
    }

    public override void Update()
    {
        frameCount--;
        if (frameCount == 0)
        {
            player.PlayerState = new PlayerFacingDownState(player);
        }
    }
}