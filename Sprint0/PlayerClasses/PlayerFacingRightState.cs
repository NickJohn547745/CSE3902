using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class PlayerFacingRightState : IPlayerState {
    private IPlayer player;
    private int animationFrame = 0;
    private int currentFrame = 0;
    private const int FramesPerAnimationChange = 5;

    public PlayerFacingRightState(IPlayer player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetWalkingSideSprite(animationFrame);
        Rectangle pos = new Rectangle((int)player.Position.X, (int)player.Position.Y, 64, 64);
        
        spriteBatch.Draw(sprite, pos,texturePos, Color.White);
    }
    

    public void Update() {
        if (currentFrame > FramesPerAnimationChange) {
            currentFrame = 0;
            animationFrame++;
        }
    }

    public void SwordAttack() {
        player.PlayerState = new PlayerSwordRightState(player);
    }

    public void MoveUp() {
        player.PlayerState = new PlayerFacingUpState(player);
    }

    public void MoveDown() {
        player.PlayerState = new PlayerFacingDownState(player);
    }

    public void MoveLeft() {
        player.PlayerState = new PlayerFacingLeftState(player);
    }

    public void MoveRight() {
        currentFrame++;
        player.Position = Vector2.Add(player.Position, new Vector2(1, 0));
    }
    
    public void UseAbility(AbilityTypes abilityType) {
        player.AbilityManager.UseAbility(abilityType,Vector2.Add(player.Position, new Vector2(16*4, 8*4)), new Vector2(1, 0));
        player.PlayerState = new PlayerAbilityRightState(player);
    }
}