using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.SaveLoadClasses
{
    public class SaveLoadManager
    {
        public Game1 Game { get; set; }
        public SaveLoadManager(Game1 game)
        {
            Game = game;
        }

        public void SaveGame()
        {
            using (FileStream fileStream = new FileStream("Save1.sav", FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(fileStream))
                {
                    SavePlayer(writer);
                    SaveRoom(writer);
                }
            }
        }

        public void SavePlayer(BinaryWriter writer)
        {
            writer.Write(Game.Player.GetHealth());
            writer.Write(Game.Player.Position.X);
            writer.Write(Game.Player.Position.Y);
        }
        
        public void SaveRoom(BinaryWriter writer)
        {
            writer.Write(Game.state.Room.levelConfig.Id);
        }

        public void LoadGame()
        {
            if (File.Exists("Save1.sav"))
            {
                using (FileStream fileStream = new FileStream("Save1.sav", FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        LoadPlayer(reader);
                    }
                }
            }
        }

        public void LoadPlayer(BinaryReader reader)
        {
            Game.Player.SetHealth(reader.ReadInt32());
            Game.Player.Position = new Microsoft.Xna.Framework.Vector2(reader.ReadSingle(), reader.ReadSingle());
        }
        public void LoadRoom(BinaryReader reader)
        {
            Game.state.Room.levelConfig.Id = reader.ReadInt32();
        }
    }
}
