using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses.Abilities;

public class Bomb : Ability {
    private int frameCounter;

    public Bomb(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        Velocity = velocity;
        sprite = PlayerSpriteFactory.Instance.GetBombSprite();
        if (Velocity.X != 0) {
            Position = Vector2.Add(position, new Vector2(sprite.GetWidth() * (velocity.X - 1)/2, -sprite.GetHeight()/2));
        }
        else {
            Position = Vector2.Add(position, new Vector2(-sprite.GetWidth()/2, sprite.GetHeight() * (velocity.Y - 1)/2));
        }
        type = ICollidable.objectType.Ability;
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
            game.CollidablesToDelete.Add(this);
            player.AbilityManager.RemoveCurrentAbility(AbilityTypes.Bomb);
        }
    }
}