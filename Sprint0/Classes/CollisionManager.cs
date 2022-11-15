using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using System;
using System.Collections.Generic;

namespace sprint0.Classes
{
    /// <summary>
    /// Class <c>CollisionManger</c> stores <c>ICollidable</c> objects and
    /// notifies them when they collide with each other.
    /// </summary>
    public class CollisionManager
    {
        public static List<ICollidable> Collidables { get; set; }
        private IPlayer Player;

        /// <summary>
        /// Constructor <c>ColisionManager</c> instantiates and defines an instance
        /// with Variables: <c>Collidables</c> and <c>Player</c>.
        /// </summary>
        /// <param name="player">Incoming main player object.</param>
        public CollisionManager(IPlayer player)
        {
            Collidables = new List<ICollidable>();
            Player = player;
            Collidables.Add(Player);
        }

        /// <summary>
        /// Method <c>CompareBounds</c> compares the hitboxes of two <c>ICollidable</c>
        /// objects and returns their relative comparison.
        /// </summary>
        /// <param name="source1">First <c>ICollidable</c> object to compare.</param>
        /// <param name="source2">Second <c>ICollidable</c> object to compare.</param>
        /// <returns>The comparison between the hitboxes of the two <c>ICollidable</c> objects.</returns>
        private int CompareBounds(ICollidable source1, ICollidable source2)
        {
            return source1.GetHitBox().X.CompareTo(source2.GetHitBox().X);
        }

        /// <summary>
        /// Method <c>CollisionResponse</c> determines which side of <c>ICollidable</c> obj is colliding
        /// with <c>ICollidable</c> current and responds accordingly.
        /// </summary>
        /// <param name="current">Reference <c>ICollidable</c> to compare side collisions to.</param>
        /// <param name="obj">Main <c>ICollidable</c> object to check sides of.</param>
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

        /// <summary>
        /// Method <c>RemoveInactive</c> removes items from <c>Collidables</c> that
        /// are to the left of the sweep line.
        /// </summary>
        /// <param name="active">Current <c>List<ICollidable></c> to remove inactive 
        ///     <c>ICollidable</c>'s from.
        /// </param>
        /// <param name="currentX">Current <c>int</c> x-coord of the sweep line.</param>
        /// <param name="index"><c>int</c> index of the current <c>ICollidable</c>.</param>
        /// <returns><c>int</c> index of next active <c>ICollidable</c></returns>
        private int RemoveInactive(List<ICollidable> active, int currentX, int index)
        {
            Rectangle currentHitBox = Collidables[index].GetHitBox();
            while (currentHitBox.X + currentHitBox.Width < currentX)
            {
                currentHitBox = Collidables[index].GetHitBox();

                active.Remove(Collidables[index]);
                index++;
            }
            return index;
        }

        /// <summary>
        /// Method <c>ActiveCollision</c> notifies each <c>ICollidable</c> object that
        /// intersects with the given <c>ICollidable</c> in <c>Collidables</c> at <c>index</c>.
        /// </summary>
        /// <param name="active"><c>ICollidable</c> List of active <c>ICollidables</c> to check for intersections.</param>
        /// <param name="index"><c>int</c> index of <c>ICollidable</c> object in <c>Collidables</c> to notify.</param>
        private void ActiveCollision(List<ICollidable> active, int index)
        {
            foreach (ICollidable obj in active)
            {
                Rectangle hitBox = Collidables[index].GetHitBox();
                if (hitBox.Intersects(obj.GetHitBox()))
                {
                    CollisionResponse(Collidables[index], obj);
                }
            }
        }
        /// <summary>
        /// Method <c>DetectCollisions</c> uses the sort and sweep method to detect collisions
        /// and notify objects that have collided.
        /// </summary>
        private void DetectCollisions()
        {
            // store hit-boxes with X values that overlap with collidable[i]
            List<ICollidable> active = new List<ICollidable>();
            int currentX = 0;
            int j = 0;

            // sort collidables in ascending order by Hitbox x-value
            Collidables.Sort(CompareBounds);

            for (int i = 0; i < Collidables.Count; i++)
            {
                currentX = Collidables[i].GetHitBox().X;

                j = RemoveInactive(active, currentX, j);

                ActiveCollision(active, i);

                active.Add(Collidables[i]);
            }
        }

        /// <summary>
        /// Method <c>Update</c> updates each <c>ICollidable</c> object in <c>Collidables</c>
        /// and checks for collisions via <c>DetectCollisions()</c>.
        /// </summary>
        /// <param name="gameTime">Current <c>GameTime</c> object.</param>
        /// <param name="game">Parent <c>Game1</c> object.</param>
        public void Update(GameTime gameTime, Game1 game) {
            for (int i = 0; i < Collidables.Count; i++)
            {
                Collidables[i].Update(gameTime, game);
            }
            DetectCollisions();
        }

        /// <summary>
        /// Method <c>Draw</c> draws applicable <c>ICollidable</c> objects in <c>Collidables</c>.
        /// </summary>
        /// <param name="spriteBatch"><c>SpriteBatch</c> object to draw <c>ICollidable</c> objects 
        /// to.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ICollidable collidable in Collidables)
            {
                if (collidable.type != ICollidable.ObjectType.Wall &&
                    collidable.type != ICollidable.ObjectType.Door &&
                    collidable.type != ICollidable.ObjectType.Tile)
                {
                    collidable.Draw(spriteBatch);
                }
            }
        }

        /// <summary>
        /// Method <c>Reset</c> re-instantiates <c>this</c> to its default state.
        /// </summary>
        public void Reset()
        {
            Collidables.Clear();
            Collidables.Add(Player);
        }
    }
}
