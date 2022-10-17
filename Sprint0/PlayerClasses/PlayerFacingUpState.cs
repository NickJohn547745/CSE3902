using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Enemies;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;

namespace sprint0.PlayerClasses; 

public class PlayerFacingUpState : PlayerFacingState {

    public PlayerFacingUpState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWalkingUpSprite();
        player.Damage = 0;
        ability = new PlayerAbilityUpState(player);
        sword = new PlayerSwordUpState(player);
    }

    public override void MoveUp() {
        currentFrame++;
        player.Position = Vector2.Add(player.Position, new Vector2(0, -IPlayerState.playerSpeed));
    }
}