using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class PlayerFacingRightState : PlayerFacingState {

    public PlayerFacingRightState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWalkingSideSprite();
        player.Damage = 0;
        shield = ICollidable.Edge.Right;
        player.Velocity = Vector2.Zero;
    }
   
    public override void MoveRight() {
        currentFrame++;
        
        if (player.CanMove)
        {
            Vector2 move = new Vector2(IPlayerState.playerSpeed, 0);
            if (!player.Damaged()) player.Velocity = move;

            player.Position += move;
        } else
        {
            player.CanMove = true;
        }

    }
    public override void SwordAttack()
    {
        player.PlayerState = new PlayerSwordRightState(player);
    }

    public override void UseAbility(AbilityTypes abilityType)
    {
        player.AbilityManager.UseAbility(abilityType, Vector2.Add(player.Position, new Vector2(sprite.GetWidth(), sprite.GetHeight()/2)), new Vector2(1, 0));
        player.PlayerState = new PlayerAbilityRightState(player);
    }
}