using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Interfaces
{
    public enum Direction {
        Up = 0, 
        Right = 1,
        Down = 2,
        Left = 3,
        None = 4
    };
    public interface ICollidable
    {
        public enum Edge {Top, Bottom, Left, Right};
        
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
            Sword,
            Trap
        }
        
        public ObjectType Type { get; set; }

        public int Damage { get; set; }

        public void Collide(ICollidable obj, Edge edge);

        public Vector2 GetVelocity();

        public Rectangle GetHitBox();

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);

        public void Reset();
    }
}
