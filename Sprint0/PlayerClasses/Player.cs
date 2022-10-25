using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using sprint0.RoomClasses;

using System;

namespace sprint0.PlayerClasses; 

public class Player : IPlayer {

    private Vector2 initPosition;

    public PlayerInventory PlayerInventory;
    public ICollidable.objectType type { get; set; }
    public Vector2 Position { get; set; }
    public int Health { get; set; }
    public int ScaleFactor { get; set; }
    public Game1 Game { get; set; }
    public bool IsMultiSprite { get; set; }
    public IPlayerState PlayerState { get; set; }
    public PlayerAbilityManager AbilityManager { get; protected set; }
    public int Damage { get; set; }

    public Player(Game1 game) {
        Game = game;
        PlayerState = new PlayerFacingUpState(this);
        AbilityManager = new PlayerAbilityManager(this);
        PlayerInventory = new PlayerInventory();
        Health = 6;
        ScaleFactor = 4;
        Position = new Vector2(200, 200);
        initPosition = Position;
        Damage = 0;
        type = ICollidable.objectType.Player;
    }
    
    public Rectangle GetHitBox()
    {
        return PlayerState.GetHitBox();
    }

    public void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        switch (edge)
            {
                case ICollidable.Edge.Top:
                    Position += new Vector2(0, -IPlayerState.playerSpeed);
                    break;
                case ICollidable.Edge.Right:
                    Position += new Vector2(-IPlayerState.playerSpeed, 0);
                    break;
                case ICollidable.Edge.Left:
                    Position += new Vector2(IPlayerState.playerSpeed, 0);
                    break;
                case ICollidable.Edge.Bottom:
                    Position += new Vector2(0, IPlayerState.playerSpeed);
                    break;
                default:
                    break;
            }
            PlayerState.Collide(obj, edge);
    }

    public void Draw(SpriteBatch spriteBatch) { 
        PlayerState.Draw(spriteBatch, Color.White);
    }

    public void Update(GameTime gameTime, Game1 game) {
        PlayerState.Update();
        AbilityManager.Update(gameTime, game);
    }

    public void Reset(Game1 game)
    {
        Position = initPosition;
        PlayerState = new PlayerFacingUpState(this);
    }

    public void TakeDamage(int damage) {
        Health -= damage;
        Game.Player = new DamagedPlayer(this, Game);
        Game.CollidablesToAdd.Add(Game.Player);
        Game.CollidablesToDelete.Add(this);
    }

    public void MoveUp() {
            PlayerState.MoveUp();
    }

    public void MoveDown() {
            PlayerState.MoveDown();
    }

    public void MoveLeft() {
            PlayerState.MoveLeft();
    }

    public void MoveRight() {
            PlayerState.MoveRight();
    }

    public void SwordAttack() {
        PlayerState.SwordAttack();
    }

    public virtual void UseAbility(AbilityTypes abilityType) {
        if (PlayerInventory.AbilityCounts[abilityType] > 0) {
            if (abilityType == AbilityTypes.Bomb) {
                PlayerInventory.AbilityCounts[AbilityTypes.Bomb] -= 1;
            }

            PlayerState.UseAbility(abilityType);
        }
    }

}