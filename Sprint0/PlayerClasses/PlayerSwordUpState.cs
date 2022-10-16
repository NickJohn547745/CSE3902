using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using sprint0.Sprites;
using System;

namespace sprint0.PlayerClasses; 

public class PlayerSwordUpState : IPlayerState {
    private Player player;
    private int animationFrame = 0;
    private int currentFrame = 0;
    private const int FramesPerAnimationChange = 3;
    public ISprite sprite { get; set; }

    public PlayerSwordUpState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetSwordUpSprite();
            //new Rectangle((int)player.Position.X, (int)player.Position.Y - (texturePos.Height - 16) * 4, texturePos.Width * 4, sprite.Height * 4);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, player.Position, animationFrame, SpriteEffects.None);
    }

    public void Collide(Type type, ICollidable.Edge edge)
    {

    }

    public void Update() {
        if (currentFrame > FramesPerAnimationChange) {
            currentFrame = 0;
            animationFrame++;
        }

        currentFrame++;
        
        if (animationFrame == 4) {
            player.PlayerState = new PlayerFacingUpState(player);
        }
    }

    public void SwordAttack() {
        // Already in sword attack state
    }

    public void MoveUp() {
        // Can't move during sword animation
    }

    public void MoveDown() {
        // Can't move during sword animation
    }

    public void MoveLeft() {
        // Can't move during sword animation
    }

    public void MoveRight() {
        // Can't move during sword animation
    }
    
    public void UseAbility(AbilityTypes abilityType) {
        
    }
    
}