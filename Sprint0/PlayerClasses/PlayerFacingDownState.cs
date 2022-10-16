using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;

namespace sprint0.PlayerClasses; 

public class PlayerFacingDownState : IPlayerState {
    private const int FramesPerAnimationChange = 5;
    private Player player;
    private int animationFrame = 0;
    private int currentFrame = 0;
    public ISprite sprite { get; set; }

    public PlayerFacingDownState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWalkingDownSprite();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, player.Position, animationFrame, SpriteEffects.None);
    }

    public void Collide(Type type, ICollidable.Edge edge)
    {
        if (type == typeof(Projectile))
        {
            switch (edge)
            {
                case ICollidable.Edge.Top:
                    player.Position += new Vector2(0, -200);
                    break;
                case ICollidable.Edge.Right:
                    player.Position += new Vector2(-200, 0);
                    break;
                case ICollidable.Edge.Left:
                    player.Position += new Vector2(200, 0);
                    break;
                case ICollidable.Edge.Bottom:
                    player.Position += new Vector2(0, 200);
                    break;
                default:
                    break;
            }
        }
        else if (type == typeof(ITile))
        {


        }
    }

    public void Update() {
        if (currentFrame > FramesPerAnimationChange) {
            currentFrame = 0;
            animationFrame++;
        }
    }

    public void SwordAttack() {
        player.PlayerState = new PlayerSwordDownState(player);
    }

    public void MoveUp() {
        player.PlayerState = new PlayerFacingUpState(player);
    }

    public void MoveDown() {
        currentFrame++;
        player.Position = Vector2.Add(player.Position, new Vector2(0, IPlayerState.playerSpeed));
    }

    public void MoveLeft() {
        player.PlayerState = new PlayerFacingLeftState(player);
    }

    public void MoveRight() {
        player.PlayerState = new PlayerFacingRightState(player);
    }
    
    public void UseAbility(AbilityTypes abilityType) {
        player.AbilityManager.UseAbility(abilityType, Vector2.Add(player.Position, new Vector2(8*4, 16*5)), new Vector2(0, 1));
        player.PlayerState = new PlayerAbilityDownState(player);
    }
}