using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.ItemClasses.Pickups
{
    public class BoomerangPickup : Item
    {
        private bool readyToDelete = false;
        public BoomerangPickup(int xCoord, int yCoord, IPlayer player) 
        {
            Inventory = player.GetInventory();
            Type = ICollidable.ObjectType.Item;
            Sprite = ItemSpriteFactory.Instance.BoomerangSprite();
            Position = new Vector2(xCoord, yCoord);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
            if (obj.Type == ICollidable.ObjectType.Player)
            {
                Inventory.Abilities[AbilityTypes.Boomerang] = 1;
                if (Inventory.CurrentAbility == AbilityTypes.None)
                    Inventory.CurrentAbility = AbilityTypes.Boomerang;
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