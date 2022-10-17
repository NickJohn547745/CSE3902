using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Commands;
using sprint0.Enemies;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;

namespace sprint0.PlayerClasses; 

public class PlayerSwordDownState : PlayerSwordState {

    public PlayerSwordDownState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetSwordDownSprite();
        player.Damage = 0;
        swordEdge = ICollidable.Edge.Bottom;
    }

    public override void Update()
    {
        if (currentFrame > FramesPerAnimationChange)
        {
            currentFrame = 0;
            animationFrame++;
        }

        currentFrame++;

        if (animationFrame == 4)
        {
            player.PlayerState = new PlayerFacingDownState(player);
        }
    }
}