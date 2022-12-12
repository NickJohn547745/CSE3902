using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses; 

public class PlayerAbilityLeftState : PlayerAbilityState {

    public PlayerAbilityLeftState(Player player) {
        this.player = player;
        frameCount = 21;
        sprite = PlayerSpriteFactory.Instance.GetAbilitySideSprite();
        player.Damage = 0;
        facing = ICollidable.Edge.Left;
    }

    public override void Draw(SpriteBatch spriteBatch, Color color)
    {
        sprite.Draw(spriteBatch, player.Position, SpriteEffects.FlipHorizontally, color);
    }

    public override void Update()
    {
        frameCount--;
        if (frameCount == 0)
        {
            player.PlayerState = new PlayerFacingLeftState(player);
        }
    }
}