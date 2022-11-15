using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;

namespace sprint0.ItemClasses
{
    public class Arrow : ItemType
    {
        public Arrow(int xCoord, int yCoord)
        {
            Texture2D texture = TextureStorage.GetArrowSpritesheet();

            this.SetLocation(xCoord, yCoord);
            this.SetTexture(texture, new Rectangle(0, 0, 5, 16));
        }
    }
}
