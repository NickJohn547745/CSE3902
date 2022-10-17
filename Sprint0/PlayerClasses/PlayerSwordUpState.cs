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

public class PlayerSwordUpState : PlayerSwordState {
    public PlayerSwordUpState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetSwordUpSprite();
        player.Damage = 0;
        swordEdge = ICollidable.Edge.Top;
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, new Vector2(player.Position.X, player.Position.Y - (sprite.GetHeight() - 64)), animationFrame, SpriteEffects.None);
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
            player.PlayerState = new PlayerFacingUpState(player);
        }
    }
}