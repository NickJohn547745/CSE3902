using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class DamagedPlayer : IPlayer {
    private Game1 game;
    private IPlayer decoratedPlayer;
    private int timer = 60;

    public DamagedPlayer(IPlayer decoratedPlayer, Game1 game) {
        this.decoratedPlayer = decoratedPlayer;
        this.game = game;
    }
    void RemoveDecorator() {
        game.Player = decoratedPlayer;
    }

    public int xPos { get; set; }
    public int yPos { get; set; }

    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetDamagedSprite();
        Rectangle pos = new Rectangle(decoratedPlayer.xPos, decoratedPlayer.yPos, texturePos.Width*4, texturePos.Height*4);
        
        spriteBatch.Draw(sprite, pos,texturePos, Color.White);
    }

    public void Update() {
        timer--;
        if (timer == 0) {
            RemoveDecorator();
        }
        decoratedPlayer.Update();
    }

    public void TakeDamage() {
        // Do nothing since player just took damage
    }

    public void MoveUp() {
        decoratedPlayer.MoveUp();
    }

    public void MoveDown() {
        decoratedPlayer.MoveDown();
    }

    public void MoveLeft() {
        decoratedPlayer.MoveLeft();
    }

    public void MoveRight() {
        decoratedPlayer.MoveRight();
    }
    
    public void SwordAttack() {
        decoratedPlayer.SwordAttack();
    }

    public void UseAbility(AbilityTypes abilityType) {
        
    }
    
}