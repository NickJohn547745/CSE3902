using Microsoft.Xna.Framework;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.RoomClasses;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0.PlayerClasses.Abilities;

public class MagicalBoomerang : Ability {
    private int frameCounter = 0;
    
    private Vector2 Acceleration;
    private int hitFrame = 0;
    private Vector2 initialPosition;

    public MagicalBoomerang(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        sprite = PlayerSpriteFactory.Instance.GetMagicalBoomerangSprite();
        animationFrame = 0;
        if (velocity.X != 0) {
            Position = Vector2.Add(position, new Vector2(sprite.GetWidth() * (velocity.X - 1)/2, -sprite.GetHeight()/2));
        }
        else {
            Position = Vector2.Add(position, new Vector2(-sprite.GetWidth() / 2, sprite.GetHeight() * (velocity.Y - 1)/2));
        }
        initialPosition = Position;
        Velocity = Vector2.Multiply(velocity, new Vector2((float)9));
        Acceleration = Vector2.Multiply(Vector2.Normalize(Velocity), new Vector2((float)-0.1));
        Type = ICollidable.ObjectType.Boomerang;
    }
    
    public override void Update(GameTime gameTime) {
        frameCounter++;
        if (frameCounter % 5 == 0) {
            animationFrame++;
        }
        
        Velocity = Vector2.Add(Velocity, Acceleration);

        Position = Vector2.Add(Position, Velocity);
        
        if (hitFrame > 0)
            hitFrame++;
        
        if (hitFrame == 5 || (Vector2.Distance(initialPosition, Position) < 5 && frameCounter > 20)) {
            CollisionManager.Collidables.Remove(this);
            player.AbilityManager.RemoveCurrentAbility(AbilityTypes.MagicalBoomerang);
        }
    }
    
    public override void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        switch (obj.Type)
        {
            case ICollidable.ObjectType.Wall:
            case ICollidable.ObjectType.Tile:
                Velocity = Vector2.Zero;
                sprite = PlayerSpriteFactory.Instance.GetBoomerangHitSprite();
                if (hitFrame == 0)
                    hitFrame = 1;
                break;
            case ICollidable.ObjectType.Player:
                hitFrame = 4;
                break;
        }
    }
}