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
    public class ZolEnemy : Enemy
    {
        private const int BehaviorDelay = 50;
        private const int RandBound = 6;

        private Dictionary<int, Vector2> DirectionChoice;

        public ZolEnemy(Vector2 position, float speed)
        {
            initPosition = position;
            Position = position;
            PreviousPosition = position;
            Sprite = EnemySpriteFactory.Instance.CreateZolSprite();
            this.speed = speed;
            Velocity = Vector2.One;
            delay = BehaviorDelay;
            MaxHealth = 1;
            Damage = 1;
            
            InitEnemyFields();

            DirectionChoice = new Dictionary<int, Vector2>();
            DirectionChoice.Add(0, new Vector2(0, -1));
            DirectionChoice.Add(1, new Vector2(-1, 0));
            DirectionChoice.Add(2, new Vector2(1, 0));
            DirectionChoice.Add(3, new Vector2(0, 1));
            DirectionChoice.Add(4, Vector2.Zero);
            DirectionChoice.Add(5, Vector2.Zero);
        }

        protected override void Behavior(GameTime gameTime)
        {
            Random rand = new Random();

            // randomly choose movement direction
            int direction = rand.Next(0, RandBound);
            if (DirectionChoice.ContainsKey(direction)) Velocity = DirectionChoice[direction];
            
        }
    }
}
