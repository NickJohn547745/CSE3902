using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses.Abilities; 

public class Bomb : IAbility {
    private Player player;
    public Vector2 Position { get; set; }

    private int frameCounter = 0;
    private int animationFrame = 0;

    public Bomb(Player player, Vector2 position) {
        this.player = player;
        this.Position = position;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetBombSprite(animationFrame);

        spriteBatch.Draw(sprite, Position, texturePos, Color.White, 0, new Vector2((float)texturePos.Width/2,(float)texturePos.Height/2), player.ScaleFactor, SpriteEffects.None, 0);
    }

    public void Update() {
        frameCounter++;
        if (frameCounter == 20) {
            animationFrame = 1;
        }
        else if (frameCounter == 25) {
            animationFrame = 2;
        }
        else if (frameCounter == 30) {
            animationFrame = 3;
        }
        else if (frameCounter == 35) {
            player.AbilityManager.RemoveCurrentAbility();
        }
    }
}