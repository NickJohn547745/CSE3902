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
    private int cursorPosition { get; set; }
    
    private ISprite Boomerang { get; set; }
    private ISprite Bomb { get; set; }
    private ISprite Arrow { get; set; }
    private ISprite Bow { get; set; }
    private ISprite Flame { get; set; }

    private PlayerInventory inventory;

    public AbilitySelect(PlayerInventory inventory)
    {
        cursorPosition = 1;
        this.inventory = inventory;
        SelectBackground = MenuSpriteFactory.Instance.ItemSelectSprite();
        SelectionCursor = MenuSpriteFactory.Instance.SelectionCursorSprite();

        if (inventory.AbilityCounts[AbilityTypes.WoodenBoomerang] == 1)
        {
            Boomerang = MenuSpriteFactory.Instance.BoomerangSprite();
        }

        if (inventory.AbilityCounts[AbilityTypes.Bomb] > 0)
        {
            Bomb = MenuSpriteFactory.Instance.BombSprite();
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
            Boomerang.Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 8 + Boomerang.GetWidth()/2, SelectionCursor.GetHeight() * 3), 0, SpriteEffects.None, Color.White);
        }
        SelectedAbility.Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 4 + SelectedAbility.GetWidth()/2, SelectedAbility.GetHeight() * 3), 0, SpriteEffects.None, Color.White);
        Bomb.Draw(spriteBatch, new Vector2(SelectionCursor.GetWidth() * 10 - Bomb.GetWidth()/2, SelectionCursor.GetHeight() * 3), SpriteEffects.None, Color.White);
    }

    private void ChangeSelection(int newSelection)
    {
        switch (cursorPosition)
        {
            case 1:
                SelectedAbility = Boomerang;
                break;
        }
    }
}