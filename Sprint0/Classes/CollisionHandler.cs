using sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Classes
{
    public class CollisionHandler
    {

        private int CompareBounds(ICollidable source1, ICollidable source2)
        {
            return source1.GetHitBox().X.CompareTo(source2.GetHitBox().X);
        }

        private void CollisionResponse(ICollidable obj1, ICollidable obj2)
        {
            



        }

        public void DetectCollisions(List<ICollidable> collidables)
        {
            List<ICollidable> active = new List<ICollidable>();
            int currentX = 0;
            int j = 0;

            // sort collidables in ascending order by Hitbox x-value
            collidables.Sort(CompareBounds);

            for (int i = 0; i < collidables.Count; i++)
            {
                currentX = collidables[i].GetHitBox().X;   

                // remove hitboxes that are out of active zone
                while (collidables[j].GetHitBox().X + collidables[j].GetHitBox().Width < currentX)
                {
                    active.Remove(collidables[j]);
                    j++;
                }

                // check if active hitBoxes are colliding with current hitBox
                foreach (ICollidable obj in active)
                {
                    if (collidables[i].GetHitBox().Intersects(obj.GetHitBox()))
                    {
                        CollisionResponse(collidables[i], obj);
                    }
                }

                active.Add(collidables[i]);
            }


        }

    }
}
