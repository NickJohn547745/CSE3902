using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;

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

    public void UseAbility(AbilityTypes abilityType, Vector2 position, Vector2 velocity) {
        if (currentAbility == null) {
            switch (abilityType) {
                case AbilityTypes.Bomb:
                    currentAbility = new Bomb(player, position, velocity);
                    break;
                case AbilityTypes.WoodenBoomerang:
                    currentAbility = new WoodenBoomerang(player, position, velocity);
                    break;
                case AbilityTypes.MagicalBoomerang:
                    currentAbility = new MagicalBoomerang(player, position, velocity);
                    break;
                case AbilityTypes.WoodenArrow:
                    currentAbility = new WoodenArrow(player, position, velocity);
                    break;
                case AbilityTypes.SilverArrow:
                    currentAbility = new SilverArrow(player, position, velocity);
                    break;
                case AbilityTypes.Fireball:
                    currentAbility = new Fireball(player, position, velocity);
                    break;
            }
        }
    }

    public void RemoveCurrentAbility() {
        currentAbility = null;
    }

}