using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.ItemClasses.Pickups
{
    public class TriforcePickup : Item
    {

        private int animationFrames = 0;
        public TriforcePickup() 
        {
            type = ICollidable.objectType.ItemTwoHands;
            Sprite = ItemSpriteFactory.Instance.TriforceSprite();
            Position = new Vector2(300, 300);
        }
        
        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            if (obj.type == ICollidable.objectType.Player)
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
                game.CollidablesToDelete.Add(this);
            }

        }
    }
}