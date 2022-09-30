using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.Utils;

namespace sprint0.PlayerClasses.Abilities; 

public class PlayerAbilityManager {
    private Player player;

    private IAbility currentAbility;

    public PlayerAbilityManager(Player player) {
        this.player = player;
    }

    public void Update() {
        if (currentAbility != null) {
            currentAbility.Update();
        }
        
    }

    public void Draw(SpriteBatch spriteBatch) {
        if (currentAbility != null) {
            currentAbility.Draw(spriteBatch);
        }
        
    }

    public void UseAbility(AbilityTypes abilityType, int startX, int startY, Direction direction) {
        if (currentAbility == null) {
            switch (abilityType) {
                case AbilityTypes.Bomb:
                    currentAbility = new Bomb(player, startX, startY);
                    break;
                case AbilityTypes.WoodenBoomerang:
                    currentAbility = new WoodenBoomerang(player, startX, startY, direction);
                    break;
                case AbilityTypes.MagicalBoomerang:
                    currentAbility = new MagicalBoomerang(player, startX, startY, direction);
                    break;
            }
        }
    }

    public void RemoveCurrentAbility() {
        currentAbility = null;
    }

}