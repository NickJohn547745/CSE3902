using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.ItemClasses
{
    public class Compass : ItemType
    {
        public Compass(int xCoord, int yCoord)
        {
            this.SetLocation(xCoord, yCoord);
            Texture2D texture = TextureStorage.GetCompassSpritesheet();
            this.SetTexture(texture, new Rectangle(0, 0, 11, 12));
        }
    }
}
