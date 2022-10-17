using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Enemies;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;

namespace sprint0.PlayerClasses; 

public class PlayerFacingRightState : PlayerFacingState {

    public PlayerFacingRightState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWalkingSideSprite();
        player.Damage = 0;
    }
   
    public override void MoveRight() {
        currentFrame++;
        player.Position = Vector2.Add(player.Position, new Vector2(IPlayerState.playerSpeed, 0));
    }
    public override void SwordAttack()
    {
        player.PlayerState = new PlayerSwordRightState(player);
    }

    public override void UseAbility(AbilityTypes abilityType)
    {
        player.AbilityManager.UseAbility(abilityType, Vector2.Add(player.Position, new Vector2(16 * 4, 8 * 4)), new Vector2(1, 0));
        player.PlayerState = new PlayerAbilityRightState(player);
    }
}