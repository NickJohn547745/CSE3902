using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.RoomClasses;
using System;
using System.Collections.Generic;

namespace sprint0.Classes
{
    public class CollisionManager
    {
        public List<ICollidable> collidables { get; set; }

        public CollisionManager(List<ICollidable> collidables)
        {
            this.collidables = collidables;
        }

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
            int currentBottom = current.GetHitBox().Y - current.GetHitBox().Height;
            int objRight = obj.GetHitBox().X + obj.GetHitBox().Width;
            int objBottom = obj.GetHitBox().Y - obj.GetHitBox().Height;

            ICollidable.Edge currentEdge = ICollidable.Edge.Left;
            ICollidable.Edge objEdge = ICollidable.Edge.Right;

            // determine which edge it collides with the most
            int sideOverlap = Math.Abs(objRight - currentLeft);

            // guaranteed to be left side collision with current
            // can't be right since only objects to the left of current are in Active list

            // bottom of obj collide with top of current
            if (objBottom < currentTop && objTop > currentTop && Math.Abs(objBottom - currentTop) < sideOverlap)
            {
                currentEdge = ICollidable.Edge.Top;
                objEdge = ICollidable.Edge.Bottom;
            }
            else if (objTop < currentBottom && objBottom < currentBottom && Math.Abs(objTop - currentBottom) < sideOverlap)
            {
                currentEdge = ICollidable.Edge.Bottom;
                objEdge = ICollidable.Edge.Top;
            }

            current.Collide(obj, currentEdge);
            obj.Collide(current, objEdge);
        }

        private int RemoveInactive(List<ICollidable> active, int currentX, int j)
        {
            while (collidables[j].GetHitBox().X + collidables[j].GetHitBox().Width < currentX)
            {
                active.Remove(collidables[j]);
                j++;
            }
            return j;
        }

        private void ActiveCollision(List<ICollidable> active, int i)
        {
            foreach (ICollidable obj in active)
            {
                if (collidables[i].GetHitBox().Intersects(obj.GetHitBox()))
                {
                    CollisionResponse(collidables[i], obj);
                }
            }
        }

        // uses sort and sweep algortithm
        public void DetectCollisions()
        {
            // store hitboxes with X values that overlap with collidable[i]
            List<ICollidable> active = new List<ICollidable>();
            int currentX = 0;
            int j = 0;

            // sort collidables in ascending order by Hitbox x-value
            collidables.Sort(CompareBounds);

            for (int i = 0; i < collidables.Count; i++)
            {
                currentX = collidables[i].GetHitBox().X;

                j = RemoveInactive(active, currentX, j);

                ActiveCollision(active, i);

                active.Add(collidables[i]);
            }
        }

        public void Update(GameTime gameTime, Game1 game) {
            for (int i = 0; i < collidables.Count; i++)
            {
                collidables[i].Update(gameTime, game);
            }
            DetectCollisions();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            List<ICollidable> frontCollidables = new List<ICollidable>();
            
            foreach (ICollidable collidable in collidables)
            {
                if (collidable.type != ICollidable.objectType.Wall)
                {
                    frontCollidables.Add(collidable);
                } else
                {
                    collidable.Draw(spriteBatch);
                }
            }

            foreach (ICollidable frontCollidable in frontCollidables)
            {
                frontCollidable.Draw(spriteBatch);
            }
        }
    }
}
