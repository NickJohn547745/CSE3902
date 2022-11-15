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
    public class Heart : ItemType
    {
        public Heart(int xCoord, int yCoord)
        {
            this.SetLocation(xCoord, yCoord);
            Texture2D texture = TextureStorage.GetHeartSpritesheet();
            this.SetTexture(texture, new Rectangle(0, 0, 7, 8));
        }
    }
}
