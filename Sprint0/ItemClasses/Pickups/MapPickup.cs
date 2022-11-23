using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.ItemClasses.Pickups
{
    public class MapPickup : Item
    {

        private bool readyToDelete = false;
        public MapPickup(int xCoord, int yCoord, IPlayer player) 
        {
            Inventory = player.GetInventory();
            type = ICollidable.ObjectType.Item;
            Sprite = ItemSpriteFactory.Instance.MapSprite();
            Position = new Vector2(xCoord, yCoord);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
            if (obj.type == ICollidable.ObjectType.Player)
            {
                Inventory.MapUnlocked = true;
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