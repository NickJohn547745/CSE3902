using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses;
using sprint0.PlayerClasses.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
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

        public SpriteFont Font { get; set; }

        // may want more precise values later. 107 value is buffer for left and right. 33 value is for buffer up and down
        private int HUDX = 107;
        private int HUDY = 880 + 33;
        private int HUDWidth = 1280 - 214;
        private int HUDHeight = 200 - 66;
        private Rectangle HUDArea;

        float nextWidth;
        float widthTrack;

        private Dictionary<string, Vector2> Sections = new Dictionary<string, Vector2>();



        // currentA and currentB may be better implemented in the inventory class. They are just needed to display the equipped items
        public HUD (Game1 game, PlayerInventory inventory, int currentHealth, SpriteFont font)
        {
            Game = game;
            Font = font;
            Update(inventory, currentHealth);

            // Will simplify this later
            nextWidth = (float)(.275 * HUDWidth);

            Sections.Add("Level", new Vector2(HUDX, HUDY));

            widthTrack = HUDX + nextWidth;

            nextWidth = (float) (.15 * HUDWidth);
            Sections.Add("Count", new Vector2(widthTrack, HUDY));

            widthTrack += nextWidth;

            nextWidth = (float)(.15 * HUDWidth);
            Sections.Add("B", new Vector2(widthTrack, HUDY));

            widthTrack += nextWidth;

            nextWidth = (float)(.15 * HUDWidth);
            Sections.Add("A", new Vector2(widthTrack, HUDY));

            widthTrack += nextWidth;

            nextWidth = (float)(.275 * HUDWidth);
            Sections.Add("Life", new Vector2(widthTrack, HUDY));
           
        }

        public void Update(PlayerInventory inventory, int currentHealth)
        {
            Inventory = inventory;
            Health = currentHealth;

            // currently won't work for things not in AbilityType enum
            currentAbilityA = Inventory.GetCurrentA();
            currentAbilityB = Inventory.GetCurrentB();

            Bombs = Inventory.GetBombs();

            Keys = Inventory.GetKeys();

            Rupees = Inventory.GetRupees();

            Level = 1;

            HUDArea = new Rectangle(HUDX, HUDY, HUDWidth, HUDHeight);
        }

        public void DrawLevelText(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, "LEVEL - " + Level.ToString(), Sections["Level"], Color.White);
        }

        public void DrawMap(SpriteBatch spriteBatch)
        {
            Vector2 LevelVector = Sections["Level"];
            float levelX = LevelVector.X;
            float levelY = LevelVector.Y;
            spriteBatch.DrawString(Font, "MAP WILL GO HERE", new Vector2(levelX, levelY + 33), Color.White);
        }
        public void DrawInventoryItems(SpriteBatch spriteBatch)
        {
            Texture2D keyTexture = TextureStorage.GetKeySpritesheet();
            Texture2D bombTexture = TextureStorage.GetBombSpritesheet();
            Texture2D rupeeTexture = TextureStorage.GetRupeeSpritesheet();
            Vector2 countVector = Sections["Count"];
            float countX = countVector.X;
            float countY = countVector.Y;

            int scaleY = 20;

            spriteBatch.DrawString(Font, "X" + Rupees.ToString(), countVector, Color.White);
            spriteBatch.DrawString(Font, "X" + Keys.ToString(), new Vector2(countX, countY + scaleY), Color.White);
            spriteBatch.DrawString(Font, "X" + Bombs.ToString(), new Vector2(countX, countY + 2 * scaleY), Color.White);

            Rectangle rupeeRectangle = new Rectangle((int)countX - 16, (int)countY, 16, 20);
            spriteBatch.Draw(rupeeTexture, rupeeRectangle, Color.White);

            Rectangle keyRectangle = new Rectangle((int)countX - 16, (int)countY + scaleY, 16, 20);
            spriteBatch.Draw(keyTexture, keyRectangle, Color.White);

            Rectangle bombRectangle = new Rectangle((int)countX - 16, (int)countY + 2 * scaleY, 16, 20);
            spriteBatch.Draw(bombTexture, bombRectangle, Color.White);
        }
        public void DrawItemA(SpriteBatch spriteBatch)
        {
            Vector2 itemVectorA = Sections["A"];
            float aX = itemVectorA.X;
            float aY = itemVectorA.Y;
            spriteBatch.DrawString(Font, "A", itemVectorA, Color.White);

            // just drawing bow for now
            Texture2D bowTexture = TextureStorage.GetBowSpritesheet();
            Rectangle destinationRectangle = new Rectangle((int)aX, (int) aY + 33, 40, 80);
            spriteBatch.Draw(bowTexture, destinationRectangle, Color.White);

        }
        public void DrawItemB(SpriteBatch spriteBatch)
        {
            Vector2 itemVectorB = Sections["B"];
            float bX = itemVectorB.X;
            float bY = itemVectorB.Y;
            spriteBatch.DrawString(Font, "B", itemVectorB, Color.White);

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
            Rectangle destinationRectangle = new Rectangle((int)bX, (int)bY + 33, 40, 80);
            spriteBatch.Draw(itemTextureB, destinationRectangle, Color.White);
        }
        public void DrawLife(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, "-LIFE-", Sections["Life"], Color.Red);
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
