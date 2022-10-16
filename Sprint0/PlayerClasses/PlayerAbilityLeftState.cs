using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using sprint0.Sprites;
using System;

namespace sprint0.PlayerClasses; 

public class PlayerAbilityLeftState : IPlayerState {
    private Player player;
    private int frameCount;
    public ISprite sprite { get; set; }

    public PlayerAbilityLeftState(Player player) {
        this.player = player;
        frameCount = 21;
        sprite = PlayerSpriteFactory.Instance.GetAbilitySideSprite();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, player.Position, SpriteEffects.FlipHorizontally);
    }

    public void Collide(Type type, ICollidable.Edge edge)
    {

    }

    public void Update() {
        frameCount--;
        if (frameCount == 0) {
            player.PlayerState = new PlayerFacingLeftState(player);
        }
    }

    public void MoveUp() {
        // Can't move while using ability
    }

    public void MoveDown() {
        // Can't move while using ability
    }

    public void MoveLeft() {
        // Can't move while using ability
    }

    public void MoveRight() {
        // Can't move while using ability
    }

    public void SwordAttack() {
        // Can't attack while using ability
    }

    public void UseAbility(AbilityTypes abilityType) {
        // Can't use ability while already using ability
    }
    
}