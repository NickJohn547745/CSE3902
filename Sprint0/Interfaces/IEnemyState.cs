using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0.Interfaces; 

public interface IEnemyState {
    //void TakeDamage();
    //void Attack();
    public void Update();

    public void Draw(SpriteBatch spriteBatch, Vector2 position);
}