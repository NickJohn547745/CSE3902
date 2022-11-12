using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Interfaces;
using sprint0.PlayerClasses;
using sprint0.RoomClasses;

namespace sprint0.DoorClasses
{
    public abstract class Door : ICollidable
    {
        public int Damage { get; set; }
        public ICollidable.ObjectType type { get; set; }

        public Boolean HasCollided { get; set; }
        public Direction TransitionDirection { get; set; }

        public int Id { get; set; }

        public void Collide(ICollidable obj, ICollidable.Edge edge)
        {
            if (obj.type == ICollidable.ObjectType.Player)
                HasCollided = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, new Point(0, 0));
        }

        public void Draw(SpriteBatch spriteBatch, Point offset)
        {
            Texture2D doorTexture = TextureStorage.GetBottomDoorsSpritesheet();

            const String classPrefix = "sprint0.DoorClasses.";

            switch (GetObjectType().ToString())
            {
                case classPrefix + "TopDoor":
                    doorTexture = TextureStorage.GetTopDoorsSpritesheet();
                    break;
                case classPrefix + "LeftDoor":
                    doorTexture = TextureStorage.GetLeftDoorsSpritesheet();
                    break;
                case classPrefix + "RightDoor":
                    doorTexture = TextureStorage.GetRightDoorsSpritesheet();
                    break;
            }

            Rectangle sourceRect = new Rectangle(Id * 32, 0, 32, 32);
            Rectangle hitBox = GetHitBox();

            spriteBatch.Draw(doorTexture, new Rectangle(hitBox.Location + offset, hitBox.Size),
                             sourceRect, Color.White);
        }

        public abstract Rectangle GetHitBox();
        public abstract Type GetObjectType();

        public void Reset()
        {
            // Not needed
        }

        public void Update(GameTime gameTime, Game1 game)
        {

        }
    }
}
