using System.Collections.Generic;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class PlayerInventory {
    
    private const int AbilityCount = 4;
    
    public Dictionary<AbilityTypes, int> Abilities { get; set; }
    public List<AbilityTypes> AbilityPositions = new List<AbilityTypes>() { AbilityTypes.Boomerang, AbilityTypes.Bomb, AbilityTypes.Arrow, AbilityTypes.Candle};

    public int SwordTier { get; set; }
    public bool BowUnlocked { get; set; }
    

    public int RupeeCount { get; set; }
    public int KeyCount { get; set; }
    
    public bool MapUnlocked { get; set; }
    public bool CompassUnlocked { get; set; }
    
    public AbilityTypes CurrentAbility { get; set; }

    public PlayerInventory()
    {
        Abilities = new Dictionary<AbilityTypes, int>()
        {
            { AbilityTypes.Boomerang, 2 },
            { AbilityTypes.Bomb, 6 },
            { AbilityTypes.Arrow, 0 },
            { AbilityTypes.Candle, 0 }
        };
        BowUnlocked = true;
        RupeeCount = 0;
        KeyCount = 0;
        MapUnlocked = false;
        CompassUnlocked = false;
        CurrentAbility = AbilityTypes.None;
    }

    // Will definitely be expanded upon later, not all things are included in AbilityTypes and/or Inventory
    public AbilityTypes GetCurrentA()
    {
        return AbilityTypes.Bomb;
    }
    public AbilityTypes GetCurrentB()
    {
        return AbilityTypes.Boomerang;
    }

    public void UseBomb()
    {
        Abilities[AbilityTypes.Bomb]--;

        if (Abilities[AbilityTypes.Bomb] == 0)
        {
            CycleAbility();
            if (CurrentAbility == AbilityTypes.Bomb)
            {
                CurrentAbility = AbilityTypes.None;
            }
        }
    }

    public void CycleAbility()
    {
        int start = AbilityPositions.IndexOf(CurrentAbility);

        for (int i = 1; i < AbilityCount; i++)
        {
            AbilityTypes newAbility = AbilityPositions[(start + i) % AbilityCount];
            if (Abilities[newAbility] > 0)
            {
                if (newAbility != AbilityTypes.Arrow || BowUnlocked)
                {
                    CurrentAbility = newAbility;
                    i = AbilityCount;
                }
            }
        }



    }
}