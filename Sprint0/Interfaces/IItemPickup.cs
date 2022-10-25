using Microsoft.Xna.Framework;

namespace sprint0.Interfaces;

public interface IItemPickup : ICollidable
{
    Vector2 Position { get; set; }
    ISprite Sprite { get; set; }

}