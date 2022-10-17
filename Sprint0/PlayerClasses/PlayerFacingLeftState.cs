using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Enemies;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;

namespace sprint0.PlayerClasses; 

public class PlayerFacingLeftState : PlayerFacingState {

    public PlayerFacingLeftState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWalkingSideSprite();
        player.Damage = 0;
        ability = new PlayerAbilityLeftState(player);
        sword = new PlayerSwordLeftState(player);
    }    

    public override void MoveLeft() {
        currentFrame++;
        player.Position = Vector2.Add(player.Position, new Vector2(-IPlayerState.playerSpeed, 0));
    }
}