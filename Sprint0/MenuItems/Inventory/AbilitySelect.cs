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
    private int CursorPosition { get; set; }
    
    private Dictionary<AbilityTypes, ISprite> AbilitySprites { get; set; }
    private ISprite Bow { get; set; }

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
        SelectBackground = MenuSpriteFactory.Instance.ItemSelectSprite();
        SelectionCursor = MenuSpriteFactory.Instance.SelectionCursorSprite();
        CursorPositions = new List<Vector2>();
        CursorPositions.Add(new Vector2(SelectionCursor.GetWidth() * 8, SelectionCursor.GetHeight() * 3));
        CursorPositions.Add(new Vector2(SelectionCursor.GetWidth() * (float)9.5, SelectionCursor.GetHeight() * 3));
        CursorPositions.Add(new Vector2(SelectionCursor.GetWidth() * 11, SelectionCursor.GetHeight() * 3));
        CursorPositions.Add(new Vector2(SelectionCursor.GetWidth() * (float)12.5, SelectionCursor.GetHeight() * 3));


        AbilitySprites = new Dictionary<AbilityTypes, ISprite>()
        {
            { AbilityTypes.Boomerang, MenuSpriteFactory.Instance.BoomerangSprite() },
            { AbilityTypes.Bomb, MenuSpriteFactory.Instance.BombSprite() },
            { AbilityTypes.Arrow, MenuSpriteFactory.Instance.ArrowSprite() },
            { AbilityTypes.Candle, MenuSpriteFactory.Instance.CandleSprite() }
        };
        
        Bow = MenuSpriteFactory.Instance.BowSprite();
    }

    public void UpdateInventory(PlayerInventory inventory)
    {
        Inventory = inventory;
        CursorPosition = Inventory.AbilityPositions.IndexOf(Inventory.CurrentAbility);
        
    }

    public void Update()
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        SelectBackground.Draw(spriteBatch, Vector2.Zero, SpriteEffects.None, Color.White);
        SelectionCursor.Draw(spriteBatch, CursorPositions[CursorPosition], SpriteEffects.None, Color.White);
        int count = 0;
        foreach (var (type, tier) in Inventory.Abilities)
        {
            Vector2 position = CursorPositions[count];
            if (type != AbilityTypes.Arrow)
                position += new Vector2(AbilitySprites[type].GetWidth() / 2, 0);
            if (tier > 0)
            {
                AbilitySprites[type].Draw(spriteBatch, position, Inventory.Abilities[type] - 1, SpriteEffects.None, Color.White);
            }

            count++;
        }
        
        if(Inventory.CurrentAbility != AbilityTypes.None)
            AbilitySprites[Inventory.CurrentAbility].Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 4 + AbilitySprites[Inventory.CurrentAbility].GetWidth()/2, AbilitySprites[Inventory.CurrentAbility].GetHeight() * 3), Inventory.Abilities[Inventory.CurrentAbility] - 1, SpriteEffects.None, Color.White);
        if(Inventory.BowUnlocked)
            Bow.Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 11 + Bow.GetWidth(), SelectionCursor.GetHeight() * 3), SpriteEffects.None, Color.White);
    }

    public void CycleAbility()
    {
        Inventory.CycleAbility();
        CursorPosition = Inventory.AbilityPositions.IndexOf(Inventory.CurrentAbility);
    }
}