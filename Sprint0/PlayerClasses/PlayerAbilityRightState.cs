using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Enemies;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using sprint0.Sprites;
using System;

namespace sprint0.PlayerClasses; 

public class PlayerAbilityRightState : PlayerAbilityState{

    public PlayerAbilityRightState(Player player) {
        this.player = player;
        frameCount = 21;
        sprite = PlayerSpriteFactory.Instance.GetAbilitySideSprite();
        player.Damage = 0;
    }
    public override void Update()
    {
        frameCount--;
        if (frameCount == 0)
        {
            player.PlayerState = new PlayerFacingRightState(player);
        }
    }
}