using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;

namespace sprint0.PlayerClasses.Abilities;

public class Bomb : Ability {
    private int frameCounter;

    public Bomb(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        Position = position;
        this.Velocity = velocity;
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite = PlayerSpriteFactory.Instance.GetBombSprite();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        sprite.Draw(spriteBatch, Position, animationFrame, SpriteEffects.None);
    }

    public override void Update(GameTime gameTime, Game1 game) {
        frameCounter++;
        if (frameCounter == 60) {
            animationFrame = 1;
        }
        else if (frameCounter == 65) {
            animationFrame = 2;
        }
        else if (frameCounter == 70) {
            animationFrame = 3;
        }
        else if (frameCounter == 75) {
            player.AbilityManager.RemoveCurrentAbility();
        }
    }
}