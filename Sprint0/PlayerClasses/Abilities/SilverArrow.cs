using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses.Abilities; 

public class SilverArrow : IAbility{
    
    private Player player;
    private int frameCounter;
    
    public Vector2 Position { get; set; }

    public Vector2 Velocity;

    private int spriteVersion;

    public SilverArrow(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        Position = position;
        Velocity = Vector2.Multiply(velocity, new Vector2(7));
        if (Velocity.X == 0) {
            spriteVersion = 0;
        }
        else {
            spriteVersion = 1;
        }
    }

    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetSilverArrowSprite(spriteVersion);
        SpriteEffects effects = SpriteEffects.None;
        if (spriteVersion == 0 && Velocity.Y > 0) {
            effects = SpriteEffects.FlipVertically;
        }
        else if (spriteVersion == 1 && Velocity.X < 0) {
            effects = SpriteEffects.FlipHorizontally;
        }
        
        spriteBatch.Draw(sprite, Position, texturePos, Color.White, 0, new Vector2((float)texturePos.Width/2,(float)texturePos.Height/2), player.ScaleFactor, effects, 0);
    }
    
    public void Update() {
        frameCounter++;
        Position = Vector2.Add(Position, Velocity);

        if (frameCounter == 60) {
            player.AbilityManager.RemoveCurrentAbility();
        }
    }
    
}