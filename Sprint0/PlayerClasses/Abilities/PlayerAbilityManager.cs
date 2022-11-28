using System.Collections.Generic;
using Microsoft.Xna.Framework;
using sprint0.Managers;

namespace sprint0.PlayerClasses.Abilities;

public class PlayerAbilityManager {
    private Player player;

    private Game1 Game;

    private Dictionary<AbilityTypes, bool> UsingAbility;

    public PlayerAbilityManager(Player player) {
        this.player = player;
        UsingAbility = new Dictionary<AbilityTypes, bool>();
        UsingAbility.Add(AbilityTypes.Bomb, false);
        UsingAbility.Add(AbilityTypes.WoodenBoomerang, false);
        UsingAbility.Add(AbilityTypes.MagicalBoomerang, false);
        UsingAbility.Add(AbilityTypes.WoodenArrow, false);
        UsingAbility.Add(AbilityTypes.SilverArrow, false);
        UsingAbility.Add(AbilityTypes.Fireball, false);
        Game = player.Game;
    }

    public void Update(GameTime gameTime) {
        
    }

    public void UseAbility(AbilityTypes abilityType, Vector2 position, Vector2 velocity) {
        if (!UsingAbility[abilityType]) {
            Ability currentAbility = null;
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

            UsingAbility[abilityType] = true;
            if (currentAbility != null) {
                CollisionManager.Collidables.Add(currentAbility);
            }
        }
    }

    public void RemoveCurrentAbility(AbilityTypes abilityType) {
        UsingAbility[abilityType] = false;
    }

}