using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace sprint0.Classes
{
    public class TextureStorage
    {
        private static Dictionary<String, Texture2D> spritesheets = new Dictionary<string, Texture2D>();

        public static void LoadAllTextures(ContentManager content)
        {
            LoadItemTextures(content);
            LoadEnemyTextures(content);
            LoadTileTextures(content);
            LoadPlayerTextures(content);
        }
        private static void LoadItemTextures(ContentManager content)
        {
           
        }
        private static void LoadEnemyTextures(ContentManager content)
        {
            /* spritesheets["keeseSpritesheet"] = content.Load<Texture2D>("Spritesheets/keese");
            spritesheets["stalfosSpritesheet"] = content.Load<Texture2D>("Spritesheets/stalfos");
            spritesheets["goriyaSpritesheet"] = content.Load<Texture2D>("Spritesheets/goriya");
            spritesheets["gelSpritesheet"] = content.Load<Texture2D>("Spritesheets/gel");
            spritesheets["zolSpritesheet"] = content.Load<Texture2D>("Spritesheets/zol");
            spritesheets["wallmasterSpritesheet"] = content.Load<Texture2D>("Spritesheets/wallmaster");
            spritesheets["trapSpritesheet"] = content.Load<Texture2D>("Spritesheets/trap");
            spritesheets["aquamentusSpritesheet"] = content.Load<Texture2D>("Spritesheets/aquamentus");
            spritesheets["fireballSpritesheet"] = content.Load<Texture2D>("Spritesheets/fireball");
            spritesheets["enemycloudSpritesheet"] = content.Load<Texture2D>("Spritesheets/enemycloud");
            spritesheets["enemyexplosionSpritesheet"] = content.Load<Texture2D>("Spritesheets/enemyexplosion"); */
        }
        private static void LoadTileTextures(ContentManager content)
        {
            spritesheets["tilesSpritesheet"] = content.Load<Texture2D>("Spriteshees/tiles");
        }

        private static void LoadPlayerTextures(ContentManager content) {
            spritesheets["linkSpritesheet"] = content.Load<Texture2D>("Spritesheets/LinkSpritesheet");
        }
        
        public static Texture2D GetMapSpritesheet()
        {
            return spritesheets["mapSpritesheet"];
        }
        public static Texture2D GetKeySpritesheet()
        {
            return spritesheets["keySpritesheet"];
        }
        public static Texture2D GetHeartcontainerSpritesheet()
        {
            return spritesheets["heartcontainerSpritesheet"];
        }
        public static Texture2D GetTriforceSpritesheet()
        {
            return spritesheets["triforceSpritesheet"];
        }
        public static Texture2D GetBoomerangSpritesheet()
        {
            return spritesheets["boomerangSpritesheet"];
        }
        public static Texture2D GetBowSpritesheet()
        {
            return spritesheets["bowSpritesheet"];
        }
        public static Texture2D GetHeartSpritesheet()
        {
            return spritesheets["heartSpritesheet"];
        }
        public static Texture2D GetRupeeSpritesheet()
        {
            return spritesheets["rupeeSpritesheet"];
        }
        public static Texture2D GetArrowSpritesheet()
        {
            return spritesheets["arrowSpritesheet"];
        }
        public static Texture2D GetBombSpritesheet()
        {
            return spritesheets["bombSpritesheet"];
        }
        public static Texture2D GetFairySpritesheet()
        {
            return spritesheets["fairySpritesheet"];
        }
        public static Texture2D GetClockSpritesheet()
        {
            return spritesheets["clockSpritesheet"];
        }

        public static Texture2D GetKeeseSpritesheet()
        {
            return spritesheets["keeseSpritesheet"];
        }
        public static Texture2D GetStalfosSpritesheet()
        {
            return spritesheets["stalfosSpritesheet"];
        }
        public static Texture2D GetGoriyaSpritesheet()
        {
            return spritesheets["goriyaSpritesheet"];
        }
        public static Texture2D GetgelSpritesheet()
        {
            return spritesheets["gelSpritesheet"];
        }
        public static Texture2D GetzolSpritesheet()
        {
            return spritesheets["zolSpritesheet"];
        }
        public static Texture2D GetWallmasterSpritesheet()
        {
            return spritesheets["wallmasterSpritesheet"];
        }
        public static Texture2D GetTrapSpritesheet()
        {
            return spritesheets["trapSpritesheet"];
        }
        public static Texture2D GetAquamentusSpritesheet()
        {
            return spritesheets["aquamentusSpritesheet"];
        }
        public static Texture2D GetFireballSpritesheet()
        {
            return spritesheets["fireballSpritesheet"];
        }
        public static Texture2D GetEnemycloudSpritesheet()
        {
            return spritesheets["enemycloudSpritesheet"];
        }
        public static Texture2D GetEnemyexplosionSpritesheet()
        {
            return spritesheets["enemyexplosionSpritesheet"];
        }

        public static Texture2D getTilesSpritesheet()
        {
            return spritesheets["tilesSpritesheet"];

        public static Texture2D GetPlayerSpritesheet() {
            return spritesheets["linkSpritesheet"];
        }
    }
}
