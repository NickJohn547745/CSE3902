using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;

namespace sprint0.PlayerClasses.Abilities;

public class WoodenArrow : Ability {
    private int frameCounter;

    private int spriteVersion;

    public WoodenArrow(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        Position = position;
        Velocity = Vector2.Multiply(velocity, new Vector2(5));
        if (Velocity.X == 0) {
            spriteVersion = 0;
            sprite = PlayerSpriteFactory.Instance.GetWoodenArrowVerticalSprite();
        }
        else {
            spriteVersion = 1;
            sprite = PlayerSpriteFactory.Instance.GetWoodenArrowHorizontalSprite();
        }
        
    }

    public override void Draw(SpriteBatch spriteBatch) {
        SpriteEffects effects = SpriteEffects.None;
        if (spriteVersion == 0 && Velocity.Y > 0) {
            effects = SpriteEffects.FlipVertically;
        }
        else if (spriteVersion == 1 && Velocity.X < 0) {
            effects = SpriteEffects.FlipHorizontally;
        }

        sprite.Draw(spriteBatch, Position, effects);
    }
    
    public override void Update(GameTime gameTime, Game1 game) {
        frameCounter++;
        Position = Vector2.Add(Position, Velocity);

        if (frameCounter == 45) {
            player.AbilityManager.RemoveCurrentAbility();
        }
    }
}