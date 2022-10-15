using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses.Abilities;
using Microsoft.Xna.Framework;
using System;

namespace sprint0.Interfaces; 

public interface IPlayerState {
    public ISprite sprite { get; set; }
    public void Collide(Type type, ICollidable.Edge edge);
    void Draw(SpriteBatch spriteBatch);
    void Update();
    void MoveUp();
    void MoveDown();
    void MoveLeft();
    void MoveRight();
    void SwordAttack();
    void UseAbility(AbilityTypes abilityType);
}