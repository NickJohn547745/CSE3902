using Microsoft.Xna.Framework;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.ItemClasses.Pickups
{
    public class TriforcePickup : Item
    {

        private int animationFrames = 0;
        public TriforcePickup(int xCoord, int yCoord) 
        {
            type = ICollidable.ObjectType.ItemTwoHands;
            Sprite = ItemSpriteFactory.Instance.TriforceSprite();
            Position = new Vector2(xCoord, yCoord);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            if (obj.type == ICollidable.ObjectType.Player)
            {
                Position = Vector2.Subtract(new Vector2(obj.GetHitBox().X, obj.GetHitBox().Y), new Vector2((Sprite.GetWidth()-obj.GetHitBox().Width)/2, Sprite.GetHeight()));
                if (animationFrames == 0)
                    animationFrames = 1;
            }
        }

        public override void Update(GameTime gameTime, Game1 game)
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