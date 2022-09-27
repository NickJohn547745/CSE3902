using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses; 

public class PlayerFacingLeftState : IPlayerState {
    private Player player;
    private int animationFrame = 0;
    private int currentFrame = 0;
    private const int FramesPerAnimationChange = 5;

    public PlayerFacingLeftState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        if (currentFrame > FramesPerAnimationChange) {
            currentFrame = 0;
            animationFrame++;
        }
        

        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetWalkingSideSprite(animationFrame);
        Rectangle pos = new Rectangle(player.xPos, player.yPos, 64, 64);
        
        spriteBatch.Draw(sprite, pos,texturePos, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
    }
    

    public void Update() {
        throw new System.NotImplementedException();
    }

    public void TakeDamage() {
        throw new System.NotImplementedException();
    }
    
    public void SwordAttack() {
        player.playerState = new PlayerSwordLeftState(player);
    }

    public void MoveUp() {
        player.playerState = new PlayerFacingUpState(player);
    }

    public void MoveDown() {
        player.playerState = new PlayerFacingDownState(player);
    }

    public void MoveLeft() {
        currentFrame++;
        player.xPos = player.xPos - 1;
    }

    public void MoveRight() {
        player.playerState = new PlayerFacingRightState(player);
    }
}