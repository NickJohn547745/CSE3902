using System;
using Microsoft.Xna.Framework;

public interface IEnemy
{
    /* Enemy health functions */
    private interface Health
    {
        void SetMaxHealth(int maxHealth);
        int GetMaxHealth();

        void SetHealth(int health);
        int GetHealth();

        void DecreaseHealth(int difference);
        void IncreaseHealth(int difference);
    }

    /* Enemy item/weapon functions */
    private interface Item
    {
        void SetItem(object item);
        //void SetItem(IItem item);
        object GetItem();
        //IItem GetItem();
    }

    void Update(GameTime gameTime);
}
