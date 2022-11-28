using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using sprint0.Utility;

namespace sprint0.Managers
{
    public class HealthManager
    {
        private const int DamageDelay = 14;

        public int CurrentHealth { get; private set; }
        private int maxHealth;
        private Timer damageTimer;
        private SoundEffect damageSound;
        public Color Color { get; private set; }

        public HealthManager(int maxHealth, SoundEffect sound)
        {
            this.maxHealth = maxHealth;
            CurrentHealth = maxHealth;
            damageTimer = new Timer(DamageDelay);
            damageSound = sound;
            Color = Color.White;
        }

        public void TakeDamage(int damage)
        {
            if (damageTimer.Status() && damage > 0)
            {
                CurrentHealth -= damage;
                Color = Color.Red;
                damageSound.Play();
                damageTimer.Start();
            }
        }

        public void UpdateCounters()
        {
                if (damageTimer.ConditionalUpdate())
                {
                    Color = Color.White;
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
            damageTimer.Reset();
        }

        public bool Dead()
        {
            return CurrentHealth <= 0;
        }
    }
}
