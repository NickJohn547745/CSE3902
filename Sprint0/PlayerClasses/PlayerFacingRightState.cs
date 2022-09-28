using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class PlayerFacingRightState : IPlayerState {
    private Player player;
    private int animationFrame = 0;
    private int currentFrame = 0;
    private const int FramesPerAnimationChange = 5;

    public PlayerFacingRightState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetWalkingSideSprite(animationFrame);
        Rectangle pos = new Rectangle(player.xPos, player.yPos, 64, 64);
        
        spriteBatch.Draw(sprite, pos,texturePos, Color.White);
    }
    

    public void Update() {
        if (currentFrame > FramesPerAnimationChange) {
            currentFrame = 0;
            animationFrame++;
        }
    }

    public void TakeDamage() {
        throw new System.NotImplementedException();
    }
    
    public void SwordAttack() {
        player.playerState = new PlayerSwordRightState(player);
    }

    public void MoveUp() {
        player.playerState = new PlayerFacingUpState(player);
    }

    public void MoveDown() {
        player.playerState = new PlayerFacingDownState(player);
    }

    public void MoveLeft() {
        player.playerState = new PlayerFacingLeftState(player);
    }

    public void MoveRight() {
        currentFrame++;
        player.xPos = player.xPos + 1;
    }
    
    public void UseAbility(AbilityTypes abilityType) {
        if(abilityType == AbilityTypes.Bomb){
            player.AbilityManager.UseBomb(player.xPos + 16*player.ScaleFactor, player.yPos);
        }
        player.playerState = new PlayerAbilityRightState(player);
    }
}