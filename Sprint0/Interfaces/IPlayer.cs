using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Interfaces
{
    public interface IPlayer
    {
        void SetHealth(int health);

        int GetHealth();

        // action methods such as this may not be necessary
        void Jump();

        void Move(int distance);

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
