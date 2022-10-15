using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Sprites;

namespace sprint0.Factories; 

public class PlayerSpriteFactory 
{
    private const int FacingDelay = 5;
    private const int SwordDelay = 3;
    private const int AbilityDelay = 1;
    private const int FireballDelay = 8;
    private const int FireballDynamicDelay = 3;
    private const int PlayerScale = 4;
    private const int AbilityScale = 4;

    private Texture2D playerSpriteSheet;
    
    private static PlayerSpriteFactory instance = new PlayerSpriteFactory();

    public static PlayerSpriteFactory Instance
    {
        get { return instance; }
    }

    private PlayerSpriteFactory() {
        playerSpriteSheet = TextureStorage.GetPlayerSpritesheet();
    }

    public ISprite GetWalkingUpSprite() {
        List<Rectangle> frameSources = new List<Rectangle> {
            new Rectangle(69, 11, 16, 16),
            new Rectangle(86, 11, 16, 16)
        };

        return new BasicSprite(playerSpriteSheet, frameSources, FacingDelay, PlayerScale);
    }
    
    public ISprite GetWalkingDownSprite() {
        List<Rectangle> frameSources = new List<Rectangle> {
            new Rectangle(1, 11, 16, 16),
            new Rectangle(18, 11, 16, 16)
        };

        return new BasicSprite(playerSpriteSheet, frameSources, FacingDelay, PlayerScale);
    }

    public ISprite GetWalkingSideSprite() {
        List<Rectangle> frameSources = new List<Rectangle> {
            new Rectangle(34, 11, 16, 16),
            new Rectangle(51, 11, 16, 16)
        };

        return new BasicSprite(playerSpriteSheet, frameSources, FacingDelay, PlayerScale);
    }
    
    public ISprite GetSwordUpSprite() {
        List<Rectangle> frameSources = new List<Rectangle> {
            new Rectangle(1, 109, 16, 16),
            new Rectangle(18, 97, 16, 28),
            new Rectangle(35, 98, 16, 27),
            new Rectangle(52, 106, 16, 19)
        };
        return new BasicSprite(playerSpriteSheet, frameSources, Vector2.Zero, SwordDelay, PlayerScale);
    }

    public ISprite GetSwordDownSprite() {
        List<Rectangle> frameSources = new List<Rectangle> {
            new Rectangle(1, 47, 16, 16),
            new Rectangle(18, 47, 16, 27),
            new Rectangle(35, 47, 16, 23),
            new Rectangle(52, 47, 16, 19)
        };
        return new BasicSprite(playerSpriteSheet, frameSources, SwordDelay, PlayerScale);
    }
    
    public ISprite GetSwordSideSprite() {
        List<Rectangle> frameSources = new List<Rectangle> {
            new Rectangle(1, 77, 16, 16),
            new Rectangle(18, 77, 27, 16),
            new Rectangle(46, 77, 23, 16),
            new Rectangle(70, 77, 19, 16)
        };
        return new BasicSprite(playerSpriteSheet, frameSources, SwordDelay, PlayerScale);
    }

    public ISprite GetAbilityDownSprite() {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(107, 11, 16, 16) };
        return new BasicSprite(playerSpriteSheet, frameSource, AbilityDelay, PlayerScale);
    }
    public ISprite GetAbilityUpSprite() {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(141, 11, 16, 16) };
        return new BasicSprite(playerSpriteSheet, frameSource, AbilityDelay, PlayerScale);
    }
    public ISprite GetAbilitySideSprite() {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(124, 11, 16, 16) };
        return new BasicSprite(playerSpriteSheet, frameSource, AbilityDelay, PlayerScale);
    }

    public ISprite GetDamagedSprite() {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(1, 249, 16, 16) };
        return new BasicSprite(playerSpriteSheet, frameSource, AbilityDelay, PlayerScale);
    }

    public ISprite GetBombSprite() {
        List<Rectangle> frameSources = new List<Rectangle> {
            new Rectangle(129, 185, 8, 16),
            new Rectangle(138, 185, 16, 16),
            new Rectangle(155, 185, 16, 16),
            new Rectangle(173, 185, 16, 16)
        };
        return new BasicSprite(playerSpriteSheet, frameSources, AbilityDelay, AbilityScale);
    }
    
    public ISprite GetWoodenBoomerangSprite() {
        List<Rectangle> frameSources = new List<Rectangle> {
            new Rectangle(64, 185, 8, 16),
            new Rectangle(73, 185, 8, 16),
            new Rectangle(82, 185, 8, 16)
        };
        return new BasicSprite(playerSpriteSheet, frameSources, AbilityDelay, AbilityScale);
    }
    
    public ISprite GetMagicalBoomerangSprite() {
        List<Rectangle> frameSources = new List<Rectangle> {
            new Rectangle(91, 185, 8, 16),
            new Rectangle(100, 185, 8, 16),
            new Rectangle(109, 185, 8, 16)
        };
        return new BasicSprite(playerSpriteSheet, frameSources, AbilityDelay, AbilityScale);
    }

    public ISprite GetWoodenArrowVerticalSprite() {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(1, 185, 8, 16) };
        return new BasicSprite(playerSpriteSheet, frameSource, AbilityDelay, AbilityScale);
    }

    public ISprite GetWoodenArrowHorizontalSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(10, 185, 16, 16) };

        return new BasicSprite(playerSpriteSheet, frameSource, AbilityDelay, AbilityScale);
    }

    public ISprite GetSilverArrowHorizontalSprite() {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(36, 185, 16, 16) };
        return new BasicSprite(playerSpriteSheet, frameSource, AbilityDelay, PlayerScale);
    }

    public ISprite GetSilverArrowVerticalSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(27, 185, 8, 16) };
        return new BasicSprite(playerSpriteSheet, frameSource, AbilityDelay, AbilityScale);
    }

    public ISprite GetFireballSprite() {
        Rectangle frameSource =  new Rectangle(191, 185, 16, 16) ;
        return new FrameFlipSprite(playerSpriteSheet, frameSource, Vector2.Zero, FireballDelay, FireballDynamicDelay, AbilityScale);
    }
}