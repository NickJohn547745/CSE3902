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
        Vector2 PlayerPosition { get; set; }
        public Game1 Game { get; set; }
        public PlayerInventory Inventory { get; set; }
        public AbilityTypes currentAbilityA { get; set; }
        public AbilityTypes currentAbilityB { get; set; }
        public int Health { get; set; }
        
        public int Bombs { get; set; }

        // get from game? For now we only have 1 dungeon anyway
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
        public HUD (Game1 game, PlayerInventory inventory, int currentHealth, Vector2 position, SpriteFont font)
        {
            Game = game;
            Font = font;
            Update(inventory, currentHealth, position);

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

        public void Update(PlayerInventory inventory, int currentHealth, Vector2 position)
        {
            Inventory = inventory;
            Health = currentHealth;
            PlayerPosition = position;

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

            const int scaleY = 50;
            const int scaleX = 26;

            spriteBatch.DrawString(Font, "X" + Rupees.ToString(), countVector, Color.White);
            spriteBatch.DrawString(Font, "X" + Keys.ToString(), new Vector2(countX, countY + scaleY), Color.White);
            spriteBatch.DrawString(Font, "X" + Bombs.ToString(), new Vector2(countX, countY + 2 * scaleY), Color.White);

            Rectangle rupeeRectangle = new Rectangle((int)countX - scaleX, (int)countY, 24, 30);
            Rectangle rupeeSource = new Rectangle(0, 0, 8, 16);
            spriteBatch.Draw(rupeeTexture, rupeeRectangle, rupeeSource, Color.White);

            Rectangle keyRectangle = new Rectangle((int)countX - scaleX, (int)countY + scaleY, 24, 30);
            spriteBatch.Draw(keyTexture, keyRectangle, Color.White);

            Rectangle bombRectangle = new Rectangle((int)countX - scaleX, (int)countY + 2 * scaleY, 24, 30);
            spriteBatch.Draw(bombTexture,bombRectangle, Color.White);
        }
        public void DrawItemA(SpriteBatch spriteBatch)
        {
            Vector2 itemVectorA = Sections["A"];
            float aX = itemVectorA.X;
            float aY = itemVectorA.Y;

            Vector2 ItemTextVector = new Vector2((int)aX, aY);
            spriteBatch.DrawString(Font, "A", ItemTextVector, Color.White);

            Texture2D itemTextureA = GetItemToDraw(currentAbilityA);

            const int offsetY = 45;
            Rectangle destinationRectangle = new Rectangle((int)aX, (int) aY + offsetY, 40, 80);
            spriteBatch.Draw(itemTextureA, destinationRectangle, Color.White);

        }
        public void DrawItemB(SpriteBatch spriteBatch)
        {
            Vector2 itemVectorB = Sections["B"];
            float bX = itemVectorB.X;
            float bY = itemVectorB.Y;

            Vector2 ItemTextVector = new Vector2((int)bX, bY);
            spriteBatch.DrawString(Font, "B", ItemTextVector, Color.White);

            Texture2D itemTextureB = GetItemToDraw(currentAbilityB);

            const int offsetY = 45;
            Rectangle destinationRectangle = new Rectangle((int)bX, (int)bY + offsetY, 40, 80);
            spriteBatch.Draw(itemTextureB, destinationRectangle, Color.White);
        }
        public void DrawLife(SpriteBatch spriteBatch)
        {
            Vector2 lifeVector = Sections["Life"];
            float lifeX = lifeVector.X;
            float lifeY = lifeVector.Y;

            float lifeTextX = lifeX + (float).5 * ((float)HUDWidth - lifeX);
            Vector2 LifeTextVector = new Vector2(lifeTextX, lifeY);

            spriteBatch.DrawString(Font, "-LIFE-", LifeTextVector, Color.Red);
            Texture2D heartTexture = TextureStorage.GetHeartSpritesheet();

            const int offsetX = 35;
            const int offsetY = 50;
            Rectangle heartRectangle = new Rectangle(0, 0, 7, 8);
            const int destinationHeight = 30;
            const int destinationWidth = 30;

            const int MAXHEALTHINROW = 8;
            int rowCount = 0;
            for (int i = 0; i < Health; i++)
            {
                if (i % MAXHEALTHINROW == 0)
                {
                    rowCount++;
                }
                int drawX = (int)lifeX + (offsetX * (i % MAXHEALTHINROW));
                int drawY = (int)lifeY + (offsetY * rowCount);
                spriteBatch.Draw(heartTexture, new Rectangle(drawX, drawY, destinationWidth, destinationHeight), heartRectangle, Color.White);
            }
        }

        public Texture2D GetItemToDraw(AbilityTypes currentAbility)
        {
            Texture2D FinalTexture;
            switch (currentAbility)
            {
                case AbilityTypes.Bomb:
                    FinalTexture = TextureStorage.GetBombSpritesheet();
                    break;
                case AbilityTypes.WoodenBoomerang:
                    FinalTexture = TextureStorage.GetBoomerangSpritesheet();
                    break;
                case AbilityTypes.MagicalBoomerang:
                    FinalTexture = TextureStorage.GetBoomerangSpritesheet();
                    break;
                case AbilityTypes.WoodenArrow:
                    FinalTexture = TextureStorage.GetArrowSpritesheet();
                    break;
                case AbilityTypes.SilverArrow:
                    FinalTexture = TextureStorage.GetArrowSpritesheet();
                    break;
                case AbilityTypes.Fireball:
                    FinalTexture = TextureStorage.GetFireballSpritesheet();
                    break;
                default:
                    FinalTexture = TextureStorage.GetBowSpritesheet();
                    break;
            }
            return FinalTexture;
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

        public Vector2 ConvertCoordinates(Vector2 position)
        {
            Vector2 MapBounds = Sections["Level"];
            float MapXMin = MapBounds.X;
            float MapYMin = MapBounds.Y + 33;

            Vector2 CountBounds = Sections["Count"];
            float MapXMax = CountBounds.X - 15;
            float MapYMax = MapBounds.Y;

            float MapWidth = MapXMax - MapXMin;
            float MapHeight = MapYMax - MapYMin;

            return position;
        }

    }
}
