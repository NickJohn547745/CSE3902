using Microsoft.Xna.Framework.Graphics;
using sprint0.PlayerClasses.Abilities;
using Microsoft.Xna.Framework;
using System;
using sprint0.Classes;

namespace sprint0.Interfaces; 

public interface IPlayerState {
    public const int playerSpeed = 3;
    public ISprite sprite { get; set; }
    public Rectangle GetHitBox();
    public void Collide(ICollidable obj, ICollidable.Edge edge);
    void Draw(SpriteBatch spriteBatch, Color color);
    void Update();
    void MoveUp();
    void MoveDown();
    void MoveLeft();
    void MoveRight();
    void SwordAttack();
    void UseAbility(AbilityTypes abilityType);
}