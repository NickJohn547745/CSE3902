using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class PlayerFacingDownState : PlayerFacingState {
    public PlayerFacingDownState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWalkingDownSprite();
        player.Damage = 0;
        shield = ICollidable.Edge.Bottom;
    }

    public override void MoveDown() {
        currentFrame++;
        
        if (player.CanMove)
        {
            //player.PreviousPosition = player.Position;
            player.Position = Vector2.Add(player.Position, new Vector2(0, IPlayerState.playerSpeed));
        }
        else
        {
            player.CanMove = true;
        }    
    }

    public override void SwordAttack()
    {
        player.PlayerState = new PlayerSwordDownState(player);
    }

    public override void UseAbility(AbilityTypes abilityType)
    {
        player.AbilityManager.UseAbility(abilityType, Vector2.Add(player.Position, new Vector2(sprite.GetWidth() / 2, sprite.GetHeight())), new Vector2(0, 1));
        player.PlayerState = new PlayerAbilityDownState(player);
    }
}