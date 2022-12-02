using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;

namespace sprint0.ItemClasses.Pickups
{
    public class RupeePickup : Item
    {

        private bool readyToDelete = false;
        public RupeePickup(int xCoord, int yCoord, IPlayer player) 
        {
            Inventory = player.GetInventory();
            Type = ICollidable.ObjectType.Item;
            Sprite = ItemSpriteFactory.Instance.RupeeSprite();
            Position = new Vector2(xCoord, yCoord);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
            if (obj.Type == ICollidable.ObjectType.Player)
            {
                Inventory.RupeeCount++;
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