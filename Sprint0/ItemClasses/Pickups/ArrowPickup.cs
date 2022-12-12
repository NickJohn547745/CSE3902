using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.ItemClasses.Pickups
{
    public class ArrowPickup : Item
    {
        private int animationFrames = 0;
        public ArrowPickup(int xCoord, int yCoord, IPlayer player) 
        {
            Inventory = player.GetInventory();
            Type = ICollidable.ObjectType.ItemOneHand;
            Sprite = ItemSpriteFactory.Instance.ArrowSprite();
            Position = new Vector2(xCoord, yCoord);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
            if (obj.Type == ICollidable.ObjectType.Player)
            {
                Inventory.Abilities[AbilityTypes.Arrow] = 1;
                if (Inventory.CurrentAbility == AbilityTypes.None && Inventory.BowUnlocked)
                    Inventory.CurrentAbility = AbilityTypes.Arrow;
                Position = Vector2.Subtract(new Vector2(obj.GetHitBox().X, obj.GetHitBox().Y), new Vector2(0, Sprite.GetHeight()));
                if (animationFrames == 0)
                    animationFrames = 1;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (animationFrames > 0)
                animationFrames++;

            if (animationFrames == 20)
            {
                CollisionManager.Collidables.Remove(this);
            }

        }
    }
}