using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.PlayerClasses;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.MenuItems.Inventory;

public class AbilitySelect
{
    private ISprite SelectBackground { get; set; }
    private ISprite SelectionCursor { get; set; }
    
    private ISprite SelectedAbility { get; set; }
    private int SelectedAbilityTier { get; set; }
    private int CursorPosition { get; set; }
    
    private ISprite Boomerang { get; set; }
    private ISprite Bomb { get; set; }
    private ISprite Arrow { get; set; }
    private ISprite Bow { get; set; }
    private ISprite Candle { get; set; }

    private PlayerInventory Inventory;
    
    private List<Vector2> CursorPositions { get; set; }
    
    private static AbilitySelect instance = new AbilitySelect();
    
    public static AbilitySelect Instance
    {
        get {
            return instance;
        }
    }

    private AbilitySelect()
    {
        CursorPosition = 1;
        SelectedAbilityTier = 1;
        SelectBackground = MenuSpriteFactory.Instance.ItemSelectSprite();
        SelectionCursor = MenuSpriteFactory.Instance.SelectionCursorSprite();
        CursorPositions = new List<Vector2>();
        CursorPositions.Add(new Vector2(SelectionCursor.GetWidth() * 8, SelectionCursor.GetHeight() * 3));
        CursorPositions.Add(new Vector2(SelectionCursor.GetWidth() * (float)9.5, SelectionCursor.GetHeight() * 3));
        CursorPositions.Add(new Vector2(SelectionCursor.GetWidth() * 11, SelectionCursor.GetHeight() * 3));
        CursorPositions.Add(new Vector2(SelectionCursor.GetWidth() * (float)12.5, SelectionCursor.GetHeight() * 3));
    }

    public void UpdateInventory(PlayerInventory inventory)
    {
        Inventory = inventory;

        if (inventory.BoomerangTier > 0)
        {
            Boomerang = MenuSpriteFactory.Instance.BoomerangSprite();
        }

        if (inventory.BombCount > 0)
        {
            Bomb = MenuSpriteFactory.Instance.BombSprite();
        }
        else
        {
            Bomb = null;
        }

        if (inventory.ArrowTier > 0)
        {
            Arrow = MenuSpriteFactory.Instance.ArrowSprite();
        }

        if (inventory.BowUnlocked)
        {
            Bow = MenuSpriteFactory.Instance.BowSprite();
        }

        if (inventory.CandleTier > 0)
        {
            Candle = MenuSpriteFactory.Instance.CandleSprite();
        }

        if (SelectedAbility == null)
        {
            CursorPosition = 1;
            if (Boomerang != null)
            {
                SelectedAbility = Boomerang;
                SelectedAbilityTier = Inventory.BoomerangTier;
            }
            else if (Bomb != null)
            {
                CursorPosition = 2;
                SelectedAbility = Bomb;
            }
            else if (Arrow != null && Bow != null)
            {
                CursorPosition = 3;
                SelectedAbility = Arrow;
                SelectedAbilityTier = Inventory.ArrowTier;
            }
            else if (Candle != null)
            {
                CursorPosition = 4;
                SelectedAbility = Candle;
                SelectedAbilityTier = Inventory.CandleTier;
            }
            else
            {
                SelectedAbility = Boomerang;
            }
        }
    }

    public void Update()
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        SelectBackground.Draw(spriteBatch, Vector2.Zero, SpriteEffects.None, Color.White);
        SelectionCursor.Draw(spriteBatch, CursorPositions[CursorPosition - 1], SpriteEffects.None, Color.White);
        if (Boomerang != null)
        {
            Boomerang.Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 8 + Boomerang.GetWidth()/2, SelectionCursor.GetHeight() * 3), Inventory.BoomerangTier -1, SpriteEffects.None, Color.White);
        }
        if(SelectedAbility != null)
            SelectedAbility.Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 4 + SelectedAbility.GetWidth()/2, SelectedAbility.GetHeight() * 3), SelectedAbilityTier - 1, SpriteEffects.None, Color.White);
        if(Bomb != null)
            Bomb.Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 10 - Bomb.GetWidth()/2, SelectionCursor.GetHeight() * 3), SpriteEffects.None, Color.White);
        if(Arrow != null)
            Arrow.Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 11, SelectionCursor.GetHeight() * 3), Inventory.ArrowTier - 1, SpriteEffects.None, Color.White);
        if(Bow != null)
            Bow.Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 11 + Bow.GetWidth(), SelectionCursor.GetHeight() * 3), SpriteEffects.None, Color.White);
        if(Candle != null)
            Candle.Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 13 - Candle.GetWidth()/ 2, SelectionCursor.GetHeight() * 3), Inventory.CandleTier - 1, SpriteEffects.None, Color.White);
    }

    public void CycleAbility()
    {
        if (Inventory != null)
        {
            int loops = 0;
            bool flag = false;
            while (loops < 4 && !flag)
            {
                CursorPosition++;
                if (CursorPosition > 4)
                {
                    CursorPosition = 1;
                }

                if (CursorPosition == 1 && Inventory.BoomerangTier > 0)
                {
                    SelectedAbility = Boomerang;
                    SelectedAbilityTier = Inventory.BoomerangTier;
                    flag = true;
                    if (SelectedAbilityTier == 1)
                        Inventory.CurrentAbility = AbilityTypes.WoodenBoomerang;
                    else
                        Inventory.CurrentAbility = AbilityTypes.MagicalBoomerang;
                }
                else if (CursorPosition == 2 && Inventory.BombCount > 0)
                {
                    SelectedAbility = Bomb;
                    flag = true;
                    Inventory.CurrentAbility = AbilityTypes.Bomb;
                }
                else if (CursorPosition == 3 && Inventory.ArrowTier > 0 && Inventory.BowUnlocked)
                {
                    SelectedAbility = Arrow;
                    SelectedAbilityTier = Inventory.ArrowTier;
                    flag = true;
                    if (SelectedAbilityTier == 1)
                        Inventory.CurrentAbility = AbilityTypes.WoodenArrow;
                    else
                        Inventory.CurrentAbility = AbilityTypes.SilverArrow;
                }
                else if (CursorPosition == 4 && Inventory.CandleTier > 0)
                {
                    SelectedAbility = Candle;
                    SelectedAbilityTier = Inventory.CandleTier;
                    flag = true;
                    Inventory.CurrentAbility = AbilityTypes.Fireball;
                }

                loops++;
            }
        }
    }
}