using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class PlayerSwordLeftState : IPlayerState {
    private Player player;
    private int animationFrame = 0;
    private int currentFrame = 0;
    private const int FramesPerAnimationChange = 3;

    public PlayerSwordLeftState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetSwordSideSprite(animationFrame);
        Rectangle pos = new Rectangle(player.xPos-(texturePos.Width - 16)*4, player.yPos, texturePos.Width*4, texturePos.Height*4);
        
        spriteBatch.Draw(sprite, pos,texturePos, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
    }

    public void Update() {
        if (currentFrame > FramesPerAnimationChange) {
            currentFrame = 0;
            animationFrame++;
        }

        currentFrame++;
        
        if (animationFrame == 4) {
            player.playerState = new PlayerFacingLeftState(player);
        }
    }

    public void TakeDamage() {
        throw new System.NotImplementedException();
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