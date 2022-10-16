using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;

namespace sprint0.PlayerClasses; 

public class PlayerFacingUpState : IPlayerState {
    private Player player;
    private int animationFrame = 0;
    private int currentFrame = 0;
    private const int FramesPerAnimationChange = 5;
    public ISprite sprite { get; set; }

    public PlayerFacingUpState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWalkingUpSprite();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, player.Position, animationFrame, SpriteEffects.None);
    }

    public void Collide(ICollidable obj, ICollidable.Edge edge)
    {

    }

    public void Update() {
        if (currentFrame > FramesPerAnimationChange) {
            currentFrame = 0;
            animationFrame++;
        }
    }

    public void SwordAttack() {
        player.PlayerState = new PlayerSwordUpState(player);
    }

    public void MoveUp() {
        currentFrame++;
        player.Position = Vector2.Add(player.Position, new Vector2(0, -IPlayerState.playerSpeed));
    }

    public void MoveDown() {
        player.PlayerState = new PlayerFacingDownState(player);
    }

    public void MoveLeft() {
        player.PlayerState = new PlayerFacingLeftState(player);
    }

    public void MoveRight() {
        player.PlayerState = new PlayerFacingRightState(player);
    }
    
    public void UseAbility(AbilityTypes abilityType) {
        player.AbilityManager.UseAbility(abilityType, Vector2.Add(player.Position, new Vector2(8*4, 0)), new Vector2(0, -1));
        player.PlayerState = new PlayerAbilityUpState(player);
    }
}