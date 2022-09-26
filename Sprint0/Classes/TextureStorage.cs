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
        private Dictionary<String, Texture2D> spritesheets = new Dictionary<string, Texture2D>();
        private ContentManager content;
        public TextureStorage(ContentManager content)
        {
            this.content = content;
        }
        public void LoadAllTextures()
        {
            LoadMainTextures();
            LoadItemTextures();
            LoadEnemyTextures();
            LoadOtherTextures();
        }

        
        private void LoadMainTextures()
        {
            String prefix = "Spritesheets/Main/";

            spritesheets["linkSpritesheet"] = content.Load<Texture2D>(prefix + "link");
        }

        private void LoadItemTextures()
        {
            String prefix = "Spritesheets/Items/";

            spritesheets["compassSpritesheet"] = content.Load<Texture2D>(prefix + "compass");
            spritesheets["mapSpritesheet"] = content.Load<Texture2D>(prefix + "map");
            spritesheets["keySpritesheet"] = content.Load<Texture2D>(prefix + "key");
            spritesheets["heartcontainerSpritesheet"] = content.Load<Texture2D>(prefix + "heartcontainer");
            spritesheets["triforceSpritesheet"] = content.Load<Texture2D>(prefix + "triforce");
            spritesheets["boomerangSpritesheet"] = content.Load<Texture2D>(prefix + "boomerang");
            spritesheets["bowSpritesheet"] = content.Load<Texture2D>(prefix + "bow");
            spritesheets["heartSpritesheet"] = content.Load<Texture2D>(prefix + "heart");
            spritesheets["rupeeSpritesheet"] = content.Load<Texture2D>(prefix + "rupee");
            spritesheets["arrowSpritesheet"] = content.Load<Texture2D>(prefix + "arrow");
            spritesheets["bombSpritesheet"] = content.Load<Texture2D>(prefix + "bomb");
            spritesheets["fairySpritesheet"] = content.Load<Texture2D>(prefix + "fairy");
            spritesheets["clockSpritesheet"] = content.Load<Texture2D>(prefix + "clock");
        }
        private void LoadEnemyTextures()
        {
            String prefix = "Spritesheets/Enemies/";

            spritesheets["keeseSpritesheet"] = content.Load<Texture2D>(prefix + "keese");
            spritesheets["stalfosSpritesheet"] = content.Load<Texture2D>(prefix + "stalfos");
            spritesheets["goriyaSpritesheet"] = content.Load<Texture2D>(prefix + "goriya");
            spritesheets["gelSpritesheet"] = content.Load<Texture2D>(prefix + "gel");
            spritesheets["zolSpritesheet"] = content.Load<Texture2D>(prefix + "zol");
            spritesheets["wallmasterSpritesheet"] = content.Load<Texture2D>(prefix + "wallmaster");
            spritesheets["trapSpritesheet"] = content.Load<Texture2D>(prefix + "trap");
            spritesheets["aquamentusSpritesheet"] = content.Load<Texture2D>(prefix + "aquamentus");
            spritesheets["fireballSpritesheet"] = content.Load<Texture2D>(prefix + "fireball");
        }
        private void LoadOtherTextures()
        {
            String prefix = "Spritesheets/Other/";

            spritesheets["enemycloudSpritesheet"] = content.Load<Texture2D>(prefix + "enemycloud");
            spritesheets["enemyexplosionSpritesheet"] = content.Load<Texture2D>(prefix + "enemyexplosion");
            spritesheets["outerborderSpritesheet"] = content.Load<Texture2D>(prefix + "outerborder");
            spritesheets["doorsSpritesheet"] = content.Load<Texture2D>(prefix + "doors");
        }

        public Texture2D GetLinkSpritesheet()
        {
            return spritesheets["linkSpritesheet"];
        }
        public Texture2D GetCompassSpritesheet()
        {
            return spritesheets["compassSpritesheet"];
        }
        public Texture2D GetMapSpritesheet()
        {
            return spritesheets["mapSpritesheet"];
        }
        public Texture2D GetKeySpritesheet()
        {
            return spritesheets["keySpritesheet"];
        }
        public Texture2D GetHeartcontainerSpritesheet()
        {
            return spritesheets["heartcontainerSpritesheet"];
        }
        public Texture2D GetTriforceSpritesheet()
        {
            return spritesheets["triforceSpritesheet"];
        }
        public Texture2D GetBoomerangSpritesheet()
        {
            return spritesheets["boomerangSpritesheet"];
        }
        public Texture2D GetBowSpritesheet()
        {
            return spritesheets["bowSpritesheet"];
        }
        public Texture2D GetHeartSpritesheet()
        {
            return spritesheets["heartSpritesheet"];
        }
        public Texture2D GetRupeeSpritesheet()
        {
            return spritesheets["rupeeSpritesheet"];
        }
        public Texture2D GetArrowSpritesheet()
        {
            return spritesheets["arrowSpritesheet"];
        }
        public Texture2D GetBombSpritesheet()
        {
            return spritesheets["bombSpritesheet"];
        }
        public Texture2D GetFairySpritesheet()
        {
            return spritesheets["fairySpritesheet"];
        }
        public Texture2D GetClockSpritesheet()
        {
            return spritesheets["clockSpritesheet"];
        }

        public Texture2D GetKeeseSpritesheet()
        {
            return spritesheets["keeseSpritesheet"];
        }
        public Texture2D GetStalfosSpritesheet()
        {
            return spritesheets["stalfosSpritesheet"];
        }
        public Texture2D GetGoriyaSpritesheet()
        {
            return spritesheets["goriyaSpritesheet"];
        }
        public Texture2D GetgelSpritesheet()
        {
            return spritesheets["gelSpritesheet"];
        }
        public Texture2D GetzolSpritesheet()
        {
            return spritesheets["zolSpritesheet"];
        }
        public Texture2D GetWallmasterSpritesheet()
        {
            return spritesheets["wallmasterSpritesheet"];
        }
        public Texture2D GetTrapSpritesheet()
        {
            return spritesheets["trapSpritesheet"];
        }
        public Texture2D GetAquamentusSpritesheet()
        {
            return spritesheets["aquamentusSpritesheet"];
        }
        public Texture2D GetFireballSpritesheet()
        {
            return spritesheets["fireballSpritesheet"];
        }
        public Texture2D GetEnemycloudSpritesheet()
        {
            return spritesheets["enemycloudSpritesheet"];
        }
        public Texture2D GetEnemyexplosionSpritesheet()
        {
            return spritesheets["enemyexplosionSpritesheet"];
        }
        public Texture2D GetOuterborderSpritesheet()
        {
            return spritesheets["outerborderSpritesheet"];
        }
        public Texture2D GetDoorsSpritesheet()
        {
            return spritesheets["doorsSpritesheet"];
        }
    }
}
