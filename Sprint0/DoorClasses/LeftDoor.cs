using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.DoorClasses
{
    public class LeftDoor : Door
    {
        public LeftDoor()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle(Id * 32, 0, 32, 32);

            spriteBatch.Draw(TextureStorage.GetLeftDoorsSpritesheet(),
                                 GetHitBox(), sourceRect, Color.White);
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(0, 360, 5 * 32, 5 * 32);
        }
        public override Type GetObjectType()
        {
            return typeof(LeftDoor);
        }
    }
}
