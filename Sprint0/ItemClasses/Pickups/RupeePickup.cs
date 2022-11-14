using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.ItemClasses.Pickups
{
    public class RupeePickup : Item
    {

        private bool readyToDelete = false;
        public RupeePickup(IPlayer player)
        {
            Inventory = player.GetInventory();
            type = ICollidable.ObjectType.Item;
            Sprite = ItemSpriteFactory.Instance.RupeeSprite();
            Position = new Vector2(300, 300);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
            if (obj.type == ICollidable.ObjectType.Player)
            {
                Inventory.RupeeCount++;
                readyToDelete = true;
            }
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (readyToDelete)
            {
                CollisionManager.Collidables.Remove(this);
            }

        }
    }
}