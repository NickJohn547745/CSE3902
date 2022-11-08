using System;
using System.Collections.Generic;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class PlayerInventory {
    public Dictionary<AbilityTypes, int> AbilityCounts { get;set;}

    public PlayerInventory() {
        AbilityCounts = new Dictionary<AbilityTypes, int>();
        AbilityCounts.Add(AbilityTypes.Bomb, 4);
        AbilityCounts.Add(AbilityTypes.WoodenBoomerang, 1);
        AbilityCounts.Add(AbilityTypes.MagicalBoomerang, 1);
        AbilityCounts.Add(AbilityTypes.WoodenArrow, 1);
        AbilityCounts.Add(AbilityTypes.SilverArrow, 1);
        AbilityCounts.Add(AbilityTypes.Fireball, 1);
    }
    
    public int GetKeys()
    {
        return 3;
        // return AbilityCounts[AbilityTypes.Bomb];
    }

    public int GetBombs()
    {
        return AbilityCounts[AbilityTypes.Bomb];
    }
}