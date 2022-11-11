using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Interfaces
{
    public interface ICollidable
    {
        public enum Edge {Top, Bottom, Left, Right };
        
        public enum ObjectType
        {
            Enemy,
            Player,
            Door,
            Wall,
            Tile,
            Projectile,
            Ability,
            Item,
            ItemTwoHands,
            ItemOneHand,
            Boomerang,
            Sword
        }
        
        public ObjectType type { get; set; }

        public int Damage { get; set; }

        public void Collide(ICollidable obj, Edge edge);

        public Rectangle GetHitBox();

        public void Update(GameTime gameTime, Game1 game);

        public void Draw(SpriteBatch spriteBatch);

        public void Reset(Game1 game);
    }
}
