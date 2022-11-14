using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Interfaces
{
    public interface IMap
    {
        public Point PlayerPosition { get; set; }
        public Game1 game { get; set; }
        public void Draw(SpriteBatch spriteBatch);
        public void Reset();
        public void Update(Game1 game);
    }
}
