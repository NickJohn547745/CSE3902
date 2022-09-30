using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class PlayerAbilityLeftState : IPlayerState {
    private Player player;
    private int frameCount;
    
    public PlayerAbilityLeftState(Player player) {
        this.player = player;
        frameCount = 21;
    }
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetAbilitySideSprite();
        Rectangle pos = new Rectangle((int)player.Position.X, (int)player.Position.Y, 64, 64);
        
        spriteBatch.Draw(sprite, pos,texturePos, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
    }

    public void Update() {
        frameCount--;
        if (frameCount == 0) {
            player.playerState = new PlayerFacingLeftState(player);
        }
    }

    public void TakeDamage() {
        throw new System.NotImplementedException();
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