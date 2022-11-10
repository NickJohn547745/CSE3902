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
            Position = position;
            Sprite = EnemySpriteFactory.Instance.CreateOldManNPCSprite();
            Velocity = Vector2.Zero;
            delay = 1;
            MaxHealth = 2;
            Health = MaxHealth;
            Damage = 0;
            deadCount = 0;
            type = ICollidable.ObjectType.Enemy;
        }

        protected override void Behavior(GameTime gameTime, Game1 game)
        {
            
        }

        public override void Collide(ICollidable obj, ICollidable.Edge edge)
        {

            if (obj.type == ICollidable.ObjectType.Player)
            {
                switch (edge)
                {
                    case ICollidable.Edge.Top:
                        Position += new Vector2(0, -TileOffset);
                        break;
                    case ICollidable.Edge.Right:
                        Position += new Vector2(-TileOffset, 0);
                        break;
                    case ICollidable.Edge.Left:
                        Position += new Vector2(TileOffset, 0);
                        break;
                    case ICollidable.Edge.Bottom:
                        Position += new Vector2(0, TileOffset);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
