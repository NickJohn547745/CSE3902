using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;


namespace sprint0.PlayerClasses; 

public class PlayerAbilityLeftState : PlayerAbilityState {

    public PlayerAbilityLeftState(Player player) {
        this.player = player;
        frameCount = 21;
        sprite = PlayerSpriteFactory.Instance.GetAbilitySideSprite();
        player.Damage = 0;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        // Fun math to make sure sprite is positioned correctly. Position is the middle point of the outside of Link, so this does some math to center the texture far enough away so that there is no overlap
        sprite.Draw(spriteBatch, player.Position, SpriteEffects.FlipHorizontally);
    }

    public override void Update()
    {
        frameCount--;
        if (frameCount == 0)
        {
            player.PlayerState = new PlayerFacingLeftState(player);
        }
    }
}