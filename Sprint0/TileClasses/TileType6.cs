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
    public class TileType6 : TileType
    {
        public TileType6(int x, int y)
        {
            Type = ICollidable.ObjectType.Tile;
            IsCollidable = false;

            this.SetLocation(x, y);
            this.SetTextureCoords(0, 1);
        }
    }
}
