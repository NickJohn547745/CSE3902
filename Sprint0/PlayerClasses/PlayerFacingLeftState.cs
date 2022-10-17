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
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, player.Position, animationFrame, SpriteEffects.FlipHorizontally);
    }

    public override void MoveLeft() {
        currentFrame++;
        player.Position = Vector2.Add(player.Position, new Vector2(-IPlayerState.playerSpeed, 0));
    }
    public override void SwordAttack()
    {
        player.PlayerState = new PlayerSwordLeftState(player);
    }

    public override void UseAbility(AbilityTypes abilityType)
    {
        player.AbilityManager.UseAbility(abilityType, Vector2.Add(player.Position, new Vector2(-8 * 4, 8 * 4)), new Vector2(-1, 0));
        player.PlayerState = new PlayerAbilityLeftState(player);
    }
}