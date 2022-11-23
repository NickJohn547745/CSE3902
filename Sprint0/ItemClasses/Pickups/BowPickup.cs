using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.ItemClasses.Pickups
{
    public class BowPickup : Item
    {
        private int animationFrames = 0;
        public BowPickup(int xCoord, int yCoord, IPlayer player) 
        {
            Inventory = player.GetInventory();
            type = ICollidable.ObjectType.ItemOneHand;
            Sprite = ItemSpriteFactory.Instance.BowSprite();
            Position = new Vector2(xCoord, yCoord);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
            if (obj.type == ICollidable.ObjectType.Player)
            {
                Inventory.BowUnlocked = true;
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