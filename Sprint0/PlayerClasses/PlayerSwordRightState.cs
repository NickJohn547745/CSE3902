using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses; 

public class PlayerSwordRightState : IPlayerState {
    private Player player;
    private int animationFrame = 0;
    private int currentFrame = 0;
    private const int FramesPerAnimationChange = 3;

    public PlayerSwordRightState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        if (currentFrame > FramesPerAnimationChange) {
            currentFrame = 0;
            animationFrame++;
        }

        currentFrame++;

        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetSwordSideSprite(animationFrame);
        Rectangle pos = new Rectangle(player.xPos, player.yPos, texturePos.Width*4, texturePos.Height*4);
        
        spriteBatch.Draw(sprite, pos,texturePos, Color.White);

        if (animationFrame == 4) {
            player.playerState = new PlayerFacingRightState(player);
        }
    }

    public void Update() {
        throw new System.NotImplementedException();
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
}