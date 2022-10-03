using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.Interfaces
{
    public interface IPlayer
    {
        Vector2 Position {get; set;}
        int Health { get; set; }
        IPlayerState PlayerState { get; set; }
        PlayerAbilityManager AbilityManager { get; }
        void Draw(SpriteBatch spriteBatch);
        void Update();
        void TakeDamage(Game1 game);
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void SwordAttack();
        void UseAbility(AbilityTypes abilityType);

    }
}
