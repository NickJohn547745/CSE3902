using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.MenuItems.Inventory;

namespace sprint0.GameStateClasses;

public class InventoryState : AGameState
{
    private AbilitySelect abilitySelect { get; set; }
    public InventoryState(GameState state)
    {
        gameState = state;
        AbilitySelect.Instance.UpdateInventory(gameState.player.GetInventory());
        abilitySelect = AbilitySelect.Instance;
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        abilitySelect.Draw(spriteBatch);
    }
}