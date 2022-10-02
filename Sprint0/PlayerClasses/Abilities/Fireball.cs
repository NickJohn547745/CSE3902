using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses.Abilities; 

public class Fireball : IAbility {
    private Player player;
    public Vector2 Position { get; set; }
    private Vector2 velocity;


    private Vector2 finalPosition;
    private int waitFrames;
    private int frameCount;

    public Fireball(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        Position = position;
        this.velocity = Vector2.Multiply(velocity, new Vector2(4));
        finalPosition = Vector2.Add(position, Vector2.Multiply(velocity, new Vector2(128)));
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetFireballSprite();
        Vector2 normalizedVelocity = Vector2.Normalize(velocity);
        SpriteEffects spriteEffects = SpriteEffects.None;
        if (frameCount % 8 < 4) {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        spriteBatch.Draw(sprite, Position, texturePos, Color.White, 0, new Vector2(texturePos.Width * (-normalizedVelocity.X + 1)/2,texturePos.Height * (-normalizedVelocity.Y + 1)/2), player.ScaleFactor, spriteEffects, 0);
    }
    public void Update() {
        frameCount++;
        if (Vector2.Distance(Position, finalPosition) < 5) {
            waitFrames++;
        }
        else {
            Position = Vector2.Add(Position, velocity);
        }

        if (waitFrames == 20) {
            player.AbilityManager.RemoveCurrentAbility();
        }
    }
}