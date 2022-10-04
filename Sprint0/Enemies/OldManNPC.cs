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
    public class OldManNPC : Enemy
    {
        public OldManNPC(Vector2 position)
        {
            this.initPosition = position;
            this.position = position;
            sprite = EnemySpriteFactory.Instance.CreateOldManNPCSprite();
            velocity = Vector2.Zero;
            delay = 1;
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            // no behavior
        }
    }
}
