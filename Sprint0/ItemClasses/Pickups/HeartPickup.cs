using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses;

namespace sprint0.ItemClasses.Pickups
{
    public class HeartPickup : Item
    {

        private bool readyToDelete = false;
        public HeartPickup(int xCoord, int yCoord) 
        {
            type = ICollidable.ObjectType.Item;
            Sprite = ItemSpriteFactory.Instance.HeartSprite();
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