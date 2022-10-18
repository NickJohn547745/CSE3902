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
    public class TileType1 : TileType
    {
        public TileType1()
        {
            this.SetLocation(1000, 360);
            this.SetTextureCoords(0, 0);
            this.SetCollidable(false);
        }
    }
}
