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
            fireballSpritesheet,
            goriyaProjectileSpritesheet,
            oldManSpritesheet;
        
        // Menu Spritesheets
        private static Texture2D
            inventorySpritesheet;

        // Other Spritesheets
        private static Texture2D
            enemycloudSpritesheet,
            enemyexplosionSpritesheet,
            tilesSpritesheet,
            wallsSpritesheet,
            topDoorsSpritesheet,
            rightDoorsSpritesheet,
            bottomDoorsSpritesheet,
            leftDoorsSpritesheet;
        

        private static ContentManager content;

        public static void LoadAllTextures(ContentManager content)
        {
            TextureStorage.content = content;

            LoadPlayerTextures();
            LoadItemTextures();
            LoadEnemyTextures();
            LoadMenuTextures();
            LoadOtherTextures();
        }
        private static void LoadPlayerTextures()
        {
            String prefix = "Spritesheets/Main/";
            playerSpritesheet = content.Load<Texture2D>(prefix + "LinkSpritesheet");
        }
        private static void LoadItemTextures()
        {
            String prefix = "Spritesheets/Items/";

            compassSpritesheet = content.Load<Texture2D>(prefix + "compass");
            mapSpritesheet = content.Load<Texture2D>(prefix + "map");
            keySpritesheet = content.Load<Texture2D>(prefix + "key");
            heartcontainerSpritesheet = content.Load<Texture2D>(prefix + "heartcontainer");
            triforceSpritesheet = content.Load<Texture2D>(prefix + "triforce");
            boomerangSpritesheet = content.Load<Texture2D>(prefix + "boomerang");
            bowSpritesheet = content.Load<Texture2D>(prefix + "bow");
            heartSpritesheet = content.Load<Texture2D>(prefix + "heart");
            rupeeSpritesheet = content.Load<Texture2D>(prefix + "rupee");
            arrowSpritesheet = content.Load<Texture2D>(prefix + "arrow");
            bombSpritesheet = content.Load<Texture2D>(prefix + "bomb");
            fairySpritesheet = content.Load<Texture2D>(prefix + "fairy");
            clockSpritesheet = content.Load<Texture2D>(prefix + "clock");
        }
        private static void LoadEnemyTextures()
        {
            String prefix = "Spritesheets/Enemies/";
            keeseSpritesheet = content.Load<Texture2D>(prefix + "keese");
            stalfosSpritesheet = content.Load<Texture2D>(prefix + "stalfos");
            goriyaSpritesheet = content.Load<Texture2D>(prefix + "goriya");
            gelSpritesheet = content.Load<Texture2D>(prefix + "gel");
            zolSpritesheet = content.Load<Texture2D>(prefix + "zol");
            wallmasterSpritesheet = content.Load<Texture2D>(prefix + "wallmaster");
            trapSpritesheet = content.Load<Texture2D>(prefix + "trap");
            aquamentusSpritesheet = content.Load<Texture2D>(prefix + "aquamentus");
            fireballSpritesheet = content.Load<Texture2D>(prefix + "fireball");
            goriyaProjectileSpritesheet = content.Load<Texture2D>(prefix + "goriyaprojectile");
            oldManSpritesheet = content.Load<Texture2D>(prefix + "oldMan");
        }

        private static void LoadMenuTextures()
        {
            String prefix = "Spritesheets/Menu/";
            inventorySpritesheet = content.Load<Texture2D>(prefix + "inventorySpritesheet");
        }

        private static void LoadOtherTextures()
        {
            String prefix = "Spritesheets/Others/";

            enemycloudSpritesheet = content.Load<Texture2D>(prefix + "enemycloud");
            enemyexplosionSpritesheet = content.Load<Texture2D>(prefix + "enemyexplosion");
            tilesSpritesheet = content.Load<Texture2D>(prefix + "tiles");
            wallsSpritesheet = content.Load<Texture2D>(prefix + "walls");
            topDoorsSpritesheet = content.Load<Texture2D>(prefix + "topDoors");
            rightDoorsSpritesheet = content.Load<Texture2D>(prefix + "rightDoors");
            bottomDoorsSpritesheet = content.Load<Texture2D>(prefix + "bottomDoors");
            leftDoorsSpritesheet = content.Load<Texture2D>(prefix + "leftDoors");
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

        public static Texture2D GetGelSpritesheet()
        {
            return gelSpritesheet;
        }
        public static Texture2D GetZolSpritesheet()
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
        public static Texture2D GetWallsSpritesheet()
        {
            return wallsSpritesheet;
        }
        public static Texture2D GetTopDoorsSpritesheet()
        {
            return topDoorsSpritesheet;
        }
        public static Texture2D GetRightDoorsSpritesheet()
        {
            return rightDoorsSpritesheet;
        }
        public static Texture2D GetBottomDoorsSpritesheet()
        {
            return bottomDoorsSpritesheet;
        }
        public static Texture2D GetLeftDoorsSpritesheet()
        {
            return leftDoorsSpritesheet;
        }

        public static Texture2D GetGoriyaProjectileSpritesheet()
        {
            return goriyaProjectileSpritesheet;
        }

        public static Texture2D GetOldManSpritesheet()
        {
            return oldManSpritesheet;
        }
        
        public static Texture2D GetInventorySpritesheet()
        {
            return inventorySpritesheet;
        }
    }
}
