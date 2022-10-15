using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using System;

namespace sprint0.PlayerClasses; 

public class PlayerFacingRightState : IPlayerState {
    private const int FramesPerAnimationChange = 5;
    private Player player;
    private int animationFrame = 0;
    private int currentFrame = 0;
    public ISprite sprite { get; set; }

    public PlayerFacingRightState(Player player) {
        this.player = player;
        animationFrame = 0;
        currentFrame = 0;
        sprite = PlayerSpriteFactory.Instance.GetWalkingSideSprite();
    }
   
    public void Update() {
        if (currentFrame > FramesPerAnimationChange) {
           currentFrame = 0;
           animationFrame++;
        }
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
        player.Position = Vector2.Add(player.Position, new Vector2(IPlayerState.playerSpeed, 0));
    }
    
    public void UseAbility(AbilityTypes abilityType) {
        player.AbilityManager.UseAbility(abilityType,Vector2.Add(player.Position, new Vector2(16*4, 8*4)), new Vector2(1, 0));
        player.PlayerState = new PlayerAbilityRightState(player);
    }
}