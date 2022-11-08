using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using System;
using sprint0.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.DoorClasses
{
    public class RightDoor : Door
    {
        public RightDoor()
        {
            type = ICollidable.objectType.Door;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle(Id * 32, 0, 32, 32);

            spriteBatch.Draw(TextureStorage.GetRightDoorsSpritesheet(),
                                 GetHitBox(), sourceRect, Color.White);
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(1120, 360, 5 * 32, 5 * 32);
        }
        public override Type GetObjectType()
        {
            return typeof(RightDoor);
        }
    }
}
