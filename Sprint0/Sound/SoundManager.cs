using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.Sound
{
    class SoundManager
    {
        private static SoundManager manager = null;

        public static SoundManager Manager
        {
            get
            {
                if (manager == null)
                {
                    manager = new SoundManager();
                }
                return manager;
            }
        }

        private static SoundEffect music = null;
        private static SoundEffect sword = null;
        private static SoundEffect itemPickUp = null;
        private static SoundEffect linkDamage = null;
        private static SoundEffect linkDead = null;
        private static SoundEffect enemyDamage = null;
        private static SoundEffect enemyDead = null;
        private static SoundEffect arrowBoomerang = null;
        private static SoundEffect bombDrop = null;
        private static SoundEffect bombBlowUp = null;
        private static SoundEffect candle = null;
        private static SoundEffect fireball = null;
        public static SoundEffectInstance musicLoop = null;


        private SoundManager() { }

        public void LoadContent(ContentManager content)
        {
            music = content.Load<SoundEffect>(@"Sound/Dungeon");
            sword = content.Load<SoundEffect>(@"Sound/LOZ_Sword_Slash");
            itemPickUp = content.Load<SoundEffect>(@"Sound/LOZ_Get_Item");
            linkDamage = content.Load<SoundEffect>(@"Sound/LOZ_Link_Hurt");
            linkDead = content.Load<SoundEffect>(@"Sound/LOZ_Link_Die");
            enemyDamage = content.Load<SoundEffect>(@"Sound/LOZ_Enemy_Hit");
            enemyDead = content.Load<SoundEffect>(@"Sound/LOZ_Enemy_Die");
            arrowBoomerang = content.Load<SoundEffect>(@"Sound/LOZ_Arrow_Boomerang");
            bombDrop = content.Load<SoundEffect>(@"Sound/LOZ_Bomb_Drop");
            bombBlowUp = content.Load<SoundEffect>(@"Sound/LOZ_Bomb_Blow");
            candle = content.Load<SoundEffect>(@"Sound/LOZ_Candle");
            fireball = content.Load<SoundEffect>(@"Sound/LOZ_Fireball");

            if (musicLoop != null)
            {
                musicLoop.Stop();
            }

            musicLoop = music.CreateInstance();
            musicLoop.IsLooped = true;
            musicLoop.Play();
        }

        public SoundEffect swordSound()
        {
            return sword;
        }
        public SoundEffect itemPickUpSound()
        {
            return itemPickUp;
        }
        public SoundEffect linkDamageSound()
        {
            return linkDamage;
        }
        public SoundEffect linkDeadSound()
        {
            return linkDead;
        }
        public SoundEffect enemyDamageSound()
        {
            return enemyDamage;
        }
        public SoundEffect enemyDeadSound()
        {
            return enemyDead;
        }

        public void AbilitySounds(AbilityTypes type)
        {
            switch (type)
            {
                case AbilityTypes.Arrow:
                    arrowBoomerang.Play();
                    break;
                case AbilityTypes.Boomerang:
                    arrowBoomerang.Play();
                    break;
                case AbilityTypes.Bomb:
                    bombDrop.Play();
                    break;
                case AbilityTypes.Candle:
                    candle.Play();
                    break;
            }
        }
        public SoundEffect bombBlowUpSound()
        {
            return bombBlowUp;
        }
    }
}
