using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Enemies;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;

namespace sprint0.PlayerClasses; 

public class PlayerFacingDownState : PlayerFacingState {
    public PlayerFacingDownState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWalkingDownSprite();
        player.Damage = 0;
        ability = new PlayerAbilityDownState(player);
        sword = new PlayerSwordDownState(player);
    }

    public override void MoveDown() {
        currentFrame++;
        player.Position = Vector2.Add(player.Position, new Vector2(0, IPlayerState.playerSpeed));
    }
}