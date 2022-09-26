using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;

namespace sprint0.Factories; 

public class PlayerSpriteFactory {

    private Texture2D playerSpriteSheet;
    
    private static PlayerSpriteFactory instance = new PlayerSpriteFactory();

    public static PlayerSpriteFactory Instance
    {
        get { return instance; }
    }

    private PlayerSpriteFactory() {
        this.playerSpriteSheet = TextureStorage.GetPlayerSpritesheet();
    }

    public static Texture2D GetDownIdleSprite() {
        return null;
    }

    public static Rectangle GetWalkingUpSprite(int frame) {
        List<Rectangle> spritePositions = new List<Rectangle> {
            new Rectangle(69, 11, 16, 16),
            new Rectangle(86, 11, 16, 16)
        };

        // Do modulus so that we don't get index out of bounds error.
        return spritePositions[frame % spritePositions.Count];
    }
    
    public static Rectangle GetWalkingDownSprite(int frame) {
        List<Rectangle> spritePositions = new List<Rectangle> {
            new Rectangle(1, 11, 16, 16),
            new Rectangle(18, 11, 16, 16)
        };

        // Do modulus so that we don't get index out of bounds error.
        return spritePositions[frame % spritePositions.Count];
    }
    
    public static Rectangle GetWalkingRightSprite(int frame) {
        List<Rectangle> spritePositions = new List<Rectangle> {
            new Rectangle(34, 11, 16, 16),
            new Rectangle(51, 11, 16, 16)
        };

        // Do modulus so that we don't get index out of bounds error.
        return spritePositions[frame % spritePositions.Count];
    }
    
    public static Rectangle GetWalkingLeftSprite(int frame) {
        List<Rectangle> spritePositions = new List<Rectangle> {
            new Rectangle(34, 11, 16, 16),
            new Rectangle(51, 11, 16, 16)
        };

        // Do modulus so that we don't get index out of bounds error.
        return spritePositions[frame % spritePositions.Count];
    }

}