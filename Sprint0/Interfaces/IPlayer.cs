using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.Interfaces
{
    public interface IPlayer
    {
        int xPos { get; set; }
        int yPos { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Update();
        void TakeDamage();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void SwordAttack();
        void UseAbility(AbilityTypes abilityType);

    }
}
