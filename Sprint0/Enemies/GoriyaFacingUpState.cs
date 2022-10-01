using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Sprites;
using sprint0.Factories;

namespace sprint0.Enemies
{
    public class GoriyaFacingUpState: IEnemyState
    {
        private Goriya goriya;
        private Vector2 rotation;

        public GoriyaFacingUpState(Goriya goriya)
        {
            this.goriya = goriya;
            this.goriya.sprite = EnemySpriteFactory.Instance.CreateGoriyaFacingUpStateSprite();
            this.rotation = Vector2.One;
        }

        public void Update()
        {
            goriya.velocity = new Vector2(0, -1);
        }  
        
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            this.goriya.sprite.Draw(spriteBatch, position, rotation);
            rotation.X *= -1;
        }
    }
}
