using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.ItemClasses.Pickups
{
    public class BoomerangPickup : Item
    {
        private bool readyToDelete = false;
        public BoomerangPickup() 
        {
            type = ICollidable.objectType.Item;
            Sprite = ItemSpriteFactory.Instance.BoomerangSprite();
            Position = new Vector2(300, 300);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge) 
        {
            if (obj.type == ICollidable.objectType.Player)
            {
                readyToDelete = true;
            }
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (readyToDelete)
            {
                game.CollidablesToDelete.Add(this);
            }

        }
    }
}