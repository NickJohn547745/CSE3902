using System;
using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.ItemClasses.Pickups
{
    public class BombPickup : Item
    {

        private bool readyToDelete = false;
        public BombPickup(int xCoord, int yCoord, IPlayer player) 
        {
            Inventory = player.GetInventory();
            Type = ICollidable.ObjectType.Item;
            Sprite = ItemSpriteFactory.Instance.BombSprite();
            Position = new Vector2(xCoord, yCoord);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
            if (obj.Type == ICollidable.ObjectType.Player)
            {
                Inventory.Abilities[AbilityTypes.Bomb] = Math.Min(8, Inventory.Abilities[AbilityTypes.Bomb] + 4);
                if (Inventory.CurrentAbility == AbilityTypes.None)
                    Inventory.CurrentAbility = AbilityTypes.Bomb;
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