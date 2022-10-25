using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0.Interfaces;

namespace sprint0.TileClasses
{
    public class TileType9 : TileType
    {
        public TileType9(int x, int y)
        {
            this.SetLocation(x, y);
            this.SetTextureCoords(3, 1);
            this.SetCollidable(true);
            type = ICollidable.objectType.Tile;
        }

        public override Type GetObjectType()
        {
            return typeof(TileType);
        }

    }
}
