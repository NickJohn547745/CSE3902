﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Interfaces
{
    public interface IEnemy
    {
        void SetHealth(int health);

        int GetHealth();

        int GetAttackDamage();

        Vector2 GetPosition();

        void Update(GameTime gameTime, Game1 game);

        void Draw(SpriteBatch spriteBatch);
    }
}
