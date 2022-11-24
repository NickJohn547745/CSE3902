using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using sprint0.Sound;

namespace sprint0.Managers
{
    public class HealthManager
    {
        private const int DamageDelay = 12;

        public int CurrentHealth { get; private set; }
        private int maxHealth;
        private int damageCount;
        private SoundEffect damageSound;
        private bool Damaged;
        public Color Color { get; private set; }

        public HealthManager(int maxHealth, SoundEffect sound)
        {
            this.maxHealth = maxHealth;
            CurrentHealth = maxHealth;
            damageCount = 0;
            Damaged = false;
            damageSound = sound;
            Color = Color.White;
        }

        public void TakeDamage(int damage)
        {
            if (!Damaged && damage > 0)
            {
                CurrentHealth -= damage;
                Damaged = true;
                Color = Color.Red;
                damageSound.Play();
            }
        }

        public void UpdateCounters()
        {
            if (Damaged)
            {
                damageCount++;
                if (damageCount % DamageDelay == 0)
                {
                    Damaged = false;
                    Color = Color.White;
                }
            }
        }

        public void Heal(int healing)
        {
            CurrentHealth += healing;
            
            if (CurrentHealth > maxHealth) CurrentHealth = maxHealth;
        }

        public void Reset()
        {
            CurrentHealth = maxHealth;
        }

        public bool Dead()
        {
            return CurrentHealth <= 0;
        }
    }
}
