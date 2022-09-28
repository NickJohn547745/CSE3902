using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses.Abilities; 

public class PlayerAbilityManager {
    private Player player;

    private IAbility currentAbility;

    public PlayerAbilityManager(Player player) {
        this.player = player;
    }

    public void Update() {
        if (currentAbility != null) {
            currentAbility.Update();
        }
        
    }

    public void Draw(SpriteBatch spriteBatch) {
        if (currentAbility != null) {
            currentAbility.Draw(spriteBatch);
        }
        
    }

    public void UseBomb(int startX, int startY) {
        if (currentAbility == null) {
            currentAbility = new Bomb(player, startX, startY);
        }
    }

    public void RemoveBomb() {
        currentAbility = null;
    }

}