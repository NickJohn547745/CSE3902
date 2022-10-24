using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class DamagedPlayer : Player {

    private Player decoratedPlayer;
    private int timer = 60;

    private Vector2 initPosition;
    public ISprite sprite { get; set; }

    public DamagedPlayer(Player decoratedPlayer, Game1 game) : base(game) {
        this.decoratedPlayer = decoratedPlayer;
        Game = game;
        PlayerState = decoratedPlayer.PlayerState;
        Position = decoratedPlayer.Position;
        initPosition = Position;
        AbilityManager = this.decoratedPlayer.AbilityManager;
        sprite = PlayerSpriteFactory.Instance.GetDamagedSprite();
    }

    void RemoveDecorator() {
        Game.Player = decoratedPlayer;
    }

    public override void Draw(SpriteBatch spriteBatch) {
        sprite.Draw(spriteBatch, new Vector2(decoratedPlayer.Position.X, decoratedPlayer.Position.Y), SpriteEffects.None);
    }

    public override void Update(GameTime gameTime, Game1 game) {
        timer--;
        if (timer == 0) {
            RemoveDecorator();
        }
        decoratedPlayer.Update(gameTime, game);
    }

    public override void Reset(Game1 game)
    {
        RemoveDecorator();
        decoratedPlayer.Reset(game);
    }

    public override void TakeDamage(int damage) {
        // Do nothing since player just took damage
    }

    public override void MoveUp() {
        decoratedPlayer.MoveUp();
    }

    public override void MoveDown() {
        decoratedPlayer.MoveDown();
    }

    public override void MoveLeft() {
        decoratedPlayer.MoveLeft();
    }

    public override void MoveRight() {
        decoratedPlayer.MoveRight();
    }
    
    public override void SwordAttack() {
        decoratedPlayer.SwordAttack();
    }

    public override void UseAbility(AbilityTypes abilityType) {
        decoratedPlayer.UseAbility(abilityType);
    }
    
}