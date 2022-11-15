using System;
using Microsoft.Xna.Framework;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.ItemClasses.Pickups
{
    public class BombPickup : Item
    {

        private bool readyToDelete = false;
        public BombPickup(int xCoord, int yCoord, IPlayer player) 
        {
            Inventory = player.GetInventory();
            type = ICollidable.ObjectType.Item;
            Sprite = ItemSpriteFactory.Instance.BombSprite();
            Position = new Vector2(xCoord, yCoord);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
            if (obj.type == ICollidable.ObjectType.Player)
            {
                Inventory.BombCount = Math.Min(8, Inventory.BombCount + 4);
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