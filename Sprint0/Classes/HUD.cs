using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        // get from game?
        public int Level { get; set; }

        // Will get from inventory class when implemented
        public int Keys { get; set; }
        public int Rupees { get; set; }

        // will have to slide down if inventory is opened
        public bool inInventoryMode { get; set; }

        // map only shows if player has found it
        public bool hasMap { get; set; }

        private Vector2 HudHeightWidth;

        // currentA and currentB may be better implemented in the inventory class. They are just needed to display the equipped items
        public HUD (Game1 game, PlayerInventory inventory, AbilityTypes currentA, AbilityTypes currentB, int currentHealth)
        {
            Game = game;
            Update(inventory, currentA, currentB, currentHealth);
        }

        public void Update(PlayerInventory inventory, AbilityTypes currentA, AbilityTypes currentB, int currentHealth)
        {
            Inventory = inventory;
            // may make a separate updateHealth method
            Health = currentHealth;

            // currently won't work for things not in AbilityType enum
            currentAbilityA = currentA;
            currentAbilityB = currentB;

            Bombs = Inventory.GetBombs();

            Keys = Inventory.GetKeys();

            Rupees = Inventory.GetRupees();

            Level = 1;
        }

        public void DrawLevelText(SpriteBatch spriteBatch)
        {

        }

        public void DrawMap(SpriteBatch spriteBatch)
        {
            
        }
        public void DrawInventoryItems(SpriteBatch spriteBatch)
        {
            Texture2D keyTexture = TextureStorage.GetKeySpritesheet();
            Texture2D bombTexture = TextureStorage.GetBombSpritesheet();
            Texture2D rupeeTexture = TextureStorage.GetRupeeSpritesheet();
        }
        public void DrawItemA(SpriteBatch spriteBatch)
        {
            // just drawing bow for now
            Texture2D bowTexture = TextureStorage.GetBowSpritesheet();
        }
        public void DrawItemB(SpriteBatch spriteBatch)
        {
            Texture2D itemTextureB;
            switch (currentAbilityB)
            {
                case AbilityTypes.Bomb:
                    itemTextureB = TextureStorage.GetBombSpritesheet();
                    break;
                case AbilityTypes.WoodenBoomerang:
                    itemTextureB = TextureStorage.GetBoomerangSpritesheet();
                    break;
                case AbilityTypes.MagicalBoomerang:
                    itemTextureB = TextureStorage.GetBoomerangSpritesheet();
                    break;
                case AbilityTypes.WoodenArrow:
                    itemTextureB = TextureStorage.GetArrowSpritesheet();
                    break;
                case AbilityTypes.SilverArrow:
                    itemTextureB = TextureStorage.GetArrowSpritesheet();
                    break;
                case AbilityTypes.Fireball:
                    itemTextureB = TextureStorage.GetFireballSpritesheet();
                    break;
                default:
                    itemTextureB = TextureStorage.GetClockSpritesheet();
                    break;
            }
        }
        public void DrawLife(SpriteBatch spriteBatch)
        {
            Texture2D heartTexture = TextureStorage.GetHeartSpritesheet();
            Texture2D heartContainerTexture = TextureStorage.GetHeartcontainerSpritesheet();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            DrawLevelText(spriteBatch);
            DrawMap(spriteBatch);
            DrawInventoryItems(spriteBatch);
            DrawItemA(spriteBatch);
            DrawItemB(spriteBatch);
            DrawLife(spriteBatch);
        }
    }
}
