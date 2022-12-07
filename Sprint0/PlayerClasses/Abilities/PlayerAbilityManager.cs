using Microsoft.Xna.Framework;
using sprint0.Managers;

namespace sprint0.PlayerClasses.Abilities;

public class PlayerAbilityManager {
    private Player player;
    public Ability ActiveAbility { get; set; }
    
    public PlayerAbilityManager(Player player) {
        this.player = player;
    }

    public void UseAbility(Vector2 position, Vector2 velocity) {

        switch (player.PlayerInventory.CurrentAbility)
        {
            case AbilityTypes.Bomb:
                ActiveAbility = new Bomb(player, position, velocity);
                player.PlayerInventory.UseBomb();
                break;
            case AbilityTypes.Boomerang:
                ActiveAbility = new Boomerang(player, position, velocity);
                break;
            case AbilityTypes.Arrow:
                ActiveAbility = new Arrow(player, position, velocity);
                break;
            case AbilityTypes.Candle:
                ActiveAbility = new Candle(player, position, velocity);
                break;
        }
        if(ActiveAbility != null)
            CollisionManager.Collidables.Add(ActiveAbility);
    }

}