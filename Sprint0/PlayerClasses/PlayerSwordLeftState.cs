using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Enemies;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;


namespace sprint0.PlayerClasses; 

public class PlayerSwordLeftState : PlayerSwordState {

    public PlayerSwordLeftState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetSwordSideSprite();
        player.Damage = 0;
        swordEdge = ICollidable.Edge.Left;
        previous = new PlayerFacingLeftState(player);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        // new Rectangle((int)player.Position.X-(texturePos.Width - 16)*4, (int)player.Position.Y, texturePos.Width*4, texturePos.Height*4)
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, new Vector2(player.Position.X - (sprite.GetWidth() - 64), player.Position.Y), animationFrame, SpriteEffects.FlipHorizontally);
    }
}