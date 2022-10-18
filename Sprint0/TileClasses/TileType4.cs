using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.TileClasses
{
    public class TileType4 : TileType
    {
        public TileType4(int x, int y)
        {
            this.SetLocation(x, y);
            this.SetTextureCoords(3, 0);
            this.SetCollidable(true);
        }

    }
}
