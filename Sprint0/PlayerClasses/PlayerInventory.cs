using System;
using System.Collections.Generic;
using sprint0.ItemClasses;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class PlayerInventory {
    public Dictionary<AbilityTypes, int> AbilityCounts { get; set; }
    
    public int SwordTier { get; set; }
    
    
    public int BoomerangTier { get; set; }
    public int BombCount { get; set; }
    public int ArrowTier { get; set; }
    public bool BowUnlocked { get; set; }
    
    public int CandleTier { get; set; }

    public int RupeeCount { get; set; }
    public int KeyCount { get; set; }
    
    public bool MapUnlocked { get; set; }
    public bool CompassUnlocked { get; set; }
    
    public AbilityTypes CurrentAbility { get; set; }

    public PlayerInventory()
    {
        BombCount = 4;
        BoomerangTier = 0;
        ArrowTier = 1;
        BowUnlocked = true;
        CandleTier = 2;
        RupeeCount = 0;
        KeyCount = 0;
        MapUnlocked = false;
        CompassUnlocked = false;
        CurrentAbility = AbilityTypes.Bomb;
    }

    // Will definitely be expanded upon later, not all things are included in AbilityTypes and/or Inventory
    public AbilityTypes GetCurrentA()
    {
        return AbilityTypes.Bomb;
    }
    public AbilityTypes GetCurrentB()
    {
        return AbilityTypes.WoodenBoomerang;
    }
}