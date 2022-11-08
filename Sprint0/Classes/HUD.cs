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
        public AbilityTypes currentAbilityA { get; set; }
        public AbilityTypes currentAbilityB { get; set; }
        public int Health { get; set; }
        
        public int Bombs { get; set; }

        // Will get from inventory class when implemented
        public int Keys { get; set; }

        // currentA and currentB may be better implemented in the inventory class. They are just needed to display the equipped items
        public HUD (Game1 game, PlayerInventory inventory, AbilityTypes currentA, AbilityTypes currentB, int currentHealth)
        {
            Game = game;
            Inventory = inventory;
            currentAbilityA = currentA;
            currentAbilityB = currentB;
            Health = currentHealth;

            Bombs = Inventory.GetBombs();

            Keys = Inventory.GetKeys();
        }
    }
}
