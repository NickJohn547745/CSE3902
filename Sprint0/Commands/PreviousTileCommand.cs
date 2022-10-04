using sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Commands
{
    public class PreviousTileCommand : ICommand
    {
        public CommandData CommandData { get; set; }
        public void Execute(Game1 game)
        {
            if (CommandData.KeyState == IController.KeyState.Pressed)
            {
                game.PreviousTile();
            }
        }
    }
}
