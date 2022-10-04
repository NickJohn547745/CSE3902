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

    private Vector2 initPosition;
    public Vector2 Position { get; set; }
    public int Health { get; set; }
    public IPlayerState PlayerState { get; set; }
    public PlayerAbilityManager AbilityManager { get; }

    public DamagedPlayer(IPlayer decoratedPlayer, Game1 game) {
        this.decoratedPlayer = decoratedPlayer;
        this.game = game;
        PlayerState = decoratedPlayer.PlayerState;
        Position = decoratedPlayer.Position;
        initPosition = Position;
        AbilityManager = this.decoratedPlayer.AbilityManager;
    }
    void RemoveDecorator() {
        game.Player = decoratedPlayer;
    }

    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetDamagedSprite();
        Rectangle pos = new Rectangle((int)decoratedPlayer.Position.X, (int)decoratedPlayer.Position.Y, texturePos.Width*4, texturePos.Height*4);
        
        spriteBatch.Draw(sprite, pos,texturePos, Color.White);
    }

    public void Update() {
        timer--;
        if (timer == 0) {
            RemoveDecorator();
        }
        decoratedPlayer.Update();
    }

    public void Reset()
    {
        RemoveDecorator();
        decoratedPlayer.Reset();
    }

    public void TakeDamage(Game1 player) {
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
        decoratedPlayer.UseAbility(abilityType);
    }
    
}