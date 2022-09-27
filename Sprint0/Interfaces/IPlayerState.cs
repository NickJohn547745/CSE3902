using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Interfaces; 

public interface IPlayerState {
    void Draw(SpriteBatch spriteBatch);
    void Update();
    void TakeDamage();
    void MoveUp();
    void MoveDown();
    void MoveLeft();
    void MoveRight();
    void SwordAttack();
}