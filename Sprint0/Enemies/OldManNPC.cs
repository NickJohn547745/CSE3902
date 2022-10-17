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
using sprint0.PlayerClasses;

namespace sprint0.Enemies
{
    public class OldManNPC : Enemy
    {
        public OldManNPC(Vector2 position)
        {
            initPosition = position;
            this.position = position;
            sprite = EnemySpriteFactory.Instance.CreateOldManNPCSprite();
            velocity = Vector2.Zero;
            delay = 1;
            health = 2;
            Damage = 0;
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            Type type = obj.GetObjectType();

            if (type == typeof(Player))
            {
                switch (edge)
                {
                    case ICollidable.Edge.Top:
                        position += new Vector2(0, -tileOffset);
                        break;
                    case ICollidable.Edge.Right:
                        position += new Vector2(-tileOffset, 0);
                        break;
                    case ICollidable.Edge.Left:
                        position += new Vector2(tileOffset, 0);
                        break;
                    case ICollidable.Edge.Bottom:
                        position += new Vector2(0, tileOffset);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
