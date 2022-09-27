using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Classes
{
    public class TextureStorage
    {
        // Player spritesheets
        private static Texture2D
            playerSpritesheet;
        // Item Spritesheets
        private static Texture2D
            compassSpritesheet,
            mapSpritesheet,
            keySpritesheet,
            heartcontainerSpritesheet,
            triforceSpritesheet,
            boomerangSpritesheet,
            bowSpritesheet,
            heartSpritesheet,
            rupeeSpritesheet,
            arrowSpritesheet,
            bombSpritesheet,
            fairySpritesheet,
            clockSpritesheet;

        // Enemy Spritesheets
        private static Texture2D
            keeseSpritesheet,
            stalfosSpritesheet,
            goriyaSpritesheet,
            gelSpritesheet,
            zolSpritesheet,
            wallmasterSpritesheet,
            trapSpritesheet,
            aquamentusSpritesheet,
            fireballSpritesheet;

        // Other Spritesheets
        private static Texture2D
            enemycloudSpritesheet,
            enemyexplosionSpritesheet,
            tilesSpritesheet;

        private static ContentManager content;

        public static void LoadAllTextures(ContentManager content)
        {
            TextureStorage.content = content;

            LoadPlayerTextures();
            LoadItemTextures();
            LoadEnemyTextures();
            LoadOtherTextures();
        }
        private static void LoadPlayerTextures()
        {
            playerSpritesheet = content.Load<Texture2D>("Spritesheets/LinkSpritesheet");
        }
        private static void LoadItemTextures()
        {
            /* compassSpritesheet = content.Load<Texture2D>("Spritesheets/compass");
            mapSpritesheet = content.Load<Texture2D>("Spritesheets/map");
            keySpritesheet = content.Load<Texture2D>("Spritesheets/key");
            heartcontainerSpritesheet = content.Load<Texture2D>("Spritesheets/heartcontainer");
            triforceSpritesheet = content.Load<Texture2D>("Spritesheets/triforce");
            boomerangSpritesheet = content.Load<Texture2D>("Spritesheets/boomerang");
            bowSpritesheet = content.Load<Texture2D>("Spritesheets/bow");
            heartSpritesheet = content.Load<Texture2D>("Spritesheets/heart");
            rupeeSpritesheet = content.Load<Texture2D>("Spritesheets/rupee");
            arrowSpritesheet = content.Load<Texture2D>("Spritesheets/arrow");
            bombSpritesheet = content.Load<Texture2D>("Spritesheets/bomb");
            fairySpritesheet = content.Load<Texture2D>("Spritesheets/fairy");
            clockSpritesheet = content.Load<Texture2D>("Spritesheets/clock"); */
        }
        private static void LoadEnemyTextures()
        {
            keeseSpritesheet = content.Load<Texture2D>("Spritesheets/keese");
            stalfosSpritesheet = content.Load<Texture2D>("Spritesheets/stalfos");
            goriyaSpritesheet = content.Load<Texture2D>("Spritesheets/goriya");
            gelSpritesheet = content.Load<Texture2D>("Spritesheets/gel");
            zolSpritesheet = content.Load<Texture2D>("Spritesheets/zol");
            wallmasterSpritesheet = content.Load<Texture2D>("Spritesheets/wallmaster");
            trapSpritesheet = content.Load<Texture2D>("Spritesheets/trap");
            aquamentusSpritesheet = content.Load<Texture2D>("Spritesheets/aquamentus");
            fireballSpritesheet = content.Load<Texture2D>("Spritesheets/fireball");
        }

        private static void LoadOtherTextures()
        {
            enemycloudSpritesheet = content.Load<Texture2D>("Spritesheets/enemycloud");
            enemyexplosionSpritesheet = content.Load<Texture2D>("Spritesheets/enemyexplosion");
            tilesSpritesheet = content.Load<Texture2D>("Spritesheets/tiles");
        }

        public static Texture2D GetPlayerSpritesheet()
        {
            return playerSpritesheet;
        }

        public static Texture2D GetCompassSpritesheet()
        {
            return compassSpritesheet;
        }
        public static Texture2D GetMapSpritesheet()
        {
            return mapSpritesheet;
        }
        public static Texture2D GetKeySpritesheet()
        {
            return keySpritesheet;
        }
        public static Texture2D GetHeartcontainerSpritesheet()
        {
            return heartcontainerSpritesheet;
        }
        public static Texture2D GetTriforceSpritesheet()
        {
            return triforceSpritesheet;
        }
        public static Texture2D GetBoomerangSpritesheet()
        {
            return boomerangSpritesheet;
        }
        public static Texture2D GetBowSpritesheet()
        {
            return bowSpritesheet;
        }
        public static Texture2D GetHeartSpritesheet()
        {
            return heartSpritesheet;
        }
        public static Texture2D GetRupeeSpritesheet()
        {
            return rupeeSpritesheet;
        }
        public static Texture2D GetArrowSpritesheet()
        {
            return arrowSpritesheet;
        }
        public static Texture2D GetBombSpritesheet()
        {
            return bombSpritesheet;
        }
        public static Texture2D GetFairySpritesheet()
        {
            return fairySpritesheet;
        }
        public static Texture2D GetClockSpritesheet()
        {
            return clockSpritesheet;
        }

        public static Texture2D GetKeeseSpritesheet()
        {
            return keeseSpritesheet;
        }
        public static Texture2D GetStalfosSpritesheet()
        {
            return stalfosSpritesheet;
        }
        public static Texture2D GetGoriyaSpritesheet()
        {
            return goriyaSpritesheet;
        }
        public static Texture2D GetgelSpritesheet()
        {
            return gelSpritesheet;
        }
        public static Texture2D GetzolSpritesheet()
        {
            return zolSpritesheet;
        }
        public static Texture2D GetWallmasterSpritesheet()
        {
            return wallmasterSpritesheet;
        }
        public static Texture2D GetTrapSpritesheet()
        {
            return trapSpritesheet;
        }
        public static Texture2D GetAquamentusSpritesheet()
        {
            return aquamentusSpritesheet;
        }
        public static Texture2D GetFireballSpritesheet()
        {
            return fireballSpritesheet;
        }
        public static Texture2D GetEnemycloudSpritesheet()
        {
            return enemycloudSpritesheet;
        }
        public static Texture2D GetEnemyexplosionSpritesheet()
        {
            return enemyexplosionSpritesheet;
        }
        public static Texture2D GetTilesSpritesheet()
        {
            return tilesSpritesheet;
        }
    }
}
