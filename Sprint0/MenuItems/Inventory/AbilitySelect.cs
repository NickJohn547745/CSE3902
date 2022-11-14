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
    private int cursorPosition { get; set; }
    
    private ISprite Boomerang { get; set; }
    private ISprite Bomb { get; set; }
    private ISprite Arrow { get; set; }
    private ISprite Bow { get; set; }
    private ISprite Candle { get; set; }

    private PlayerInventory Inventory;
    
    private static AbilitySelect instance = new AbilitySelect();
    
    public static AbilitySelect Instance
    {
        get {
            return instance;
        }
    }

    private AbilitySelect()
    {
        cursorPosition = 1;
        SelectedAbilityTier = 1;
    }

    public void UpdateInventory(PlayerInventory inventory)
    {
        Inventory = inventory;
        SelectBackground = MenuSpriteFactory.Instance.ItemSelectSprite();
        SelectionCursor = MenuSpriteFactory.Instance.SelectionCursorSprite();

        if (inventory.BoomerangTier > 0)
        {
            Boomerang = MenuSpriteFactory.Instance.BoomerangSprite();
        }

        if (inventory.BombCount > 0)
        {
            Bomb = MenuSpriteFactory.Instance.BombSprite();
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

        SelectedAbility = Boomerang;
    }

    public void Update()
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        SelectBackground.Draw(spriteBatch, Vector2.Zero, SpriteEffects.None, Color.White);
        SelectionCursor.Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 8, SelectionCursor.GetHeight() * 3), SpriteEffects.None, Color.White);
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
        int loops = 0;
        bool flag = false;
        while (loops < 4 && !flag)
        {
            cursorPosition++;
            if (cursorPosition > 4)
            {
                cursorPosition = 1;
            }
            if (cursorPosition == 1 && Inventory.BoomerangTier > 0)
            {
                SelectedAbility = Boomerang;
                SelectedAbilityTier = Inventory.BoomerangTier;
                flag = true;
                if (SelectedAbilityTier == 1)
                    Inventory.CurrentAbility = AbilityTypes.WoodenBoomerang;
                else
                    Inventory.CurrentAbility = AbilityTypes.MagicalBoomerang;
            }
            else if (cursorPosition == 2 && Inventory.BombCount > 0)
            {
                SelectedAbility = Bomb;
                flag = true;
                Inventory.CurrentAbility = AbilityTypes.Bomb;
            }
            else if (cursorPosition == 3 && Inventory.ArrowTier > 0 && Inventory.BowUnlocked)
            {
                SelectedAbility = Arrow;
                SelectedAbilityTier = Inventory.ArrowTier;
                flag = true;
                if (SelectedAbilityTier == 1)
                    Inventory.CurrentAbility = AbilityTypes.WoodenArrow;
                else
                    Inventory.CurrentAbility = AbilityTypes.SilverArrow;
            }
            else if (cursorPosition == 4 && Inventory.CandleTier > 0)
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