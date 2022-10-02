using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses.Abilities; 

public class Bomb : IAbility {
    private Player player;
    public Vector2 Position { get; set; }

    private int frameCounter;
    private int animationFrame;
    private Vector2 velocity;

    public Bomb(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        Position = position;
        this.velocity = velocity;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetBombSprite(animationFrame);
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        spriteBatch.Draw(sprite, Position, texturePos, Color.White, 0, new Vector2(texturePos.Width * (-velocity.X + 1)/2,texturePos.Height * (-velocity.Y + 1)/2), player.ScaleFactor, SpriteEffects.None, 0);
    }

    public void Update() {
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