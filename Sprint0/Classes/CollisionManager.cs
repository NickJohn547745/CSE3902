using sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Classes
{
    public class CollisionManager
    {

        private int CompareBounds(ICollidable source1, ICollidable source2)
        {
            return source1.GetHitBox().X.CompareTo(source2.GetHitBox().X);
        }

        /*
         * Determine which side of obj is colliding with current; respond accordingly
        */
        private void CollisionResponse(ICollidable current, ICollidable obj)
        {
            int currentLeft = current.GetHitBox().X;
            int currentTop = current.GetHitBox().Y;
            int objTop = obj.GetHitBox().Y;
            int currentBottom = current.GetHitBox().Y + current.GetHitBox().Height;
            int objRight = obj.GetHitBox().X + obj.GetHitBox().Width;
            int objBottom = obj.GetHitBox().Y + obj.GetHitBox().Height;

            ICollidable.Edge currentEdge = ICollidable.Edge.Left;
            ICollidable.Edge objEdge = ICollidable.Edge.Right;

            // determine which edge it collides with the most
            int sideOverlap = Math.Abs(objRight - currentLeft);

            // guaranteed to be left side collision with current
            // can't be right since only objects to the left of current are in Active list
            
            // bottom of obj collide with top of current
            if (objBottom > currentTop && objBottom - currentTop > sideOverlap)
            {
                currentEdge = ICollidable.Edge.Top;
                objEdge = ICollidable.Edge.Bottom;
            } else if (objTop < currentBottom && currentBottom - objTop > sideOverlap)
            {
                currentEdge = ICollidable.Edge.Bottom;
                objEdge = ICollidable.Edge.Top;
            }

            current.Collide(obj.GetObjectType(), currentEdge);
            obj.Collide(current.GetObjectType(), objEdge);
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
