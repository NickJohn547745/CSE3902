using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.RoomClasses
{
    public class TopLeftWall : Wall
    {
        public TopLeftWall()
        {
            type = ICollidable.objectType.Wall;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(0, 0, 560, 160);
        }
    }
}
