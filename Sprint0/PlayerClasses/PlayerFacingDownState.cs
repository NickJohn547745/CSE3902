using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using sprint0.Utils;

namespace sprint0.PlayerClasses; 

public class PlayerFacingDownState : IPlayerState {
    private Player player;
    private int animationFrame = 0;
    private int currentFrame = 0;
    private const int FramesPerAnimationChange = 5;

    public PlayerFacingDownState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetWalkingDownSprite(animationFrame);
        Rectangle pos = new Rectangle((int)player.Position.X, (int)player.Position.Y, 64, 64);
        
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
        player.playerState = new PlayerSwordDownState(player);
    }

    public void MoveUp() {
        player.playerState = new PlayerFacingUpState(player);
    }

    public void MoveDown() {
        currentFrame++;
        player.Position = Vector2.Add(player.Position, new Vector2(0, 1));
    }

    public void MoveLeft() {
        player.playerState = new PlayerFacingLeftState(player);
    }

    public void MoveRight() {
        player.playerState = new PlayerFacingRightState(player);
    }
    
    public void UseAbility(AbilityTypes abilityType) {
        player.AbilityManager.UseAbility(abilityType, Vector2.Add(player.Position, new Vector2(8*player.ScaleFactor, 16*player.ScaleFactor)), new Vector2(0, 1));
        player.playerState = new PlayerAbilityDownState(player);
    }
}