using sprint0.PlayerClasses;
using sprint0.PlayerClasses.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Classes
{
    public class HUD
    {
        public Game1 Game { get; set; }
        public PlayerInventory Inventory { get; set; }
        AbilityTypes currentAbilityA { get; set; }
        AbilityTypes currentAbilityB { get; set; }
        public HUD (Game1 game, PlayerInventory inventory, AbilityTypes currentA, AbilityTypes currentB)
        {
            Game = game;
            Inventory = inventory;
            currentAbilityA = currentA;
            currentAbilityB = currentB;
        }
    }
}
