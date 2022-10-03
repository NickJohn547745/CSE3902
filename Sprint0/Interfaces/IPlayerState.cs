using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.Interfaces; 

public interface IPlayerState {
    void Draw(SpriteBatch spriteBatch);
    void Update();
    void MoveUp();
    void MoveDown();
    void MoveLeft();
    void MoveRight();
    void SwordAttack();
    void UseAbility(AbilityTypes abilityType);
}