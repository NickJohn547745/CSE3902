using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.ItemClasses.Pickups
{
    public class ClockPickup : Item
    {

        private bool readyToDelete = false;
        public ClockPickup(int xCoord, int yCoord) 
        {
            type = ICollidable.ObjectType.Item;
            Sprite = ItemSpriteFactory.Instance.ClockSprite();
            Position = new Vector2(xCoord, yCoord);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
            if (obj.type == ICollidable.ObjectType.Player)
            {
                readyToDelete = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (readyToDelete)
            {
                CollisionManager.Collidables.Remove(this);
            }

        }
    }
}