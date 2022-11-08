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
    public class TileType4 : TileType
    {
        public TileType4(int x, int y)
        {
            type = ICollidable.objectType.Tile;
            IsCollidable = true;

            this.SetLocation(x, y);
            this.SetTextureCoords(3, 0);
        }
    }
}
