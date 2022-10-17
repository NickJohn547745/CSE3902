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
        ability = new PlayerAbilityRightState(player);
        sword = new PlayerSwordRightState(player);
    }
   
    public override void MoveRight() {
        currentFrame++;
        player.Position = Vector2.Add(player.Position, new Vector2(IPlayerState.playerSpeed, 0));
    }
}