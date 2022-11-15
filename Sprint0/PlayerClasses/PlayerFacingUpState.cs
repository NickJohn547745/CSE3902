using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class PlayerFacingUpState : PlayerFacingState {

    public PlayerFacingUpState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWalkingUpSprite();
        player.Damage = 0;
        shield = ICollidable.Edge.Top;
    }

    public override void MoveUp() {
        currentFrame++;
        if (player.CanMove)
        {
            player.PreviousPosition = player.Position;
            player.Position = Vector2.Add(player.Position, new Vector2(0, -IPlayerState.playerSpeed));
        }
    }

    public override void SwordAttack()
    {
        player.PlayerState = new PlayerSwordUpState(player);
    }

    public override void UseAbility(AbilityTypes abilityType)
    {
        player.AbilityManager.UseAbility(abilityType, Vector2.Add(player.Position, new Vector2(sprite.GetWidth() / 2, 0)), new Vector2(0, -1));
        player.PlayerState = new PlayerAbilityUpState(player);
    }
}