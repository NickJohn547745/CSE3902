using Microsoft.Xna.Framework;
using sprint0.PlayerClasses.Abilities;
using sprint0.PlayerClasses;


namespace sprint0.Interfaces; 

public interface IPlayer : ICollidable
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    
    public PlayerWeapons PrimaryWeapon { get; set; }

    public int GetHealth();
    public void SetHealth(int hp);
    public void TakeDamage(int damage, Edge collideSide);
    public void MoveUp();
    public void MoveDown();
    public void MoveLeft();
    public void MoveRight();
    public void PrimaryAttack();
    public void UseAbility();

    public PlayerInventory GetInventory();

}