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
    public class TileType3 : TileType
    {
        public TileType3(int x, int y)
        {
            this.SetLocation(x, y);
            this.SetTextureCoords(2, 0);
        }
        public override Type GetObjectType()
        {
            return typeof(TileType);
        }
    }
}
