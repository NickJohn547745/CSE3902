using sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Commands
{
    public class NextItemCommand : ICommand
    {
        public void Execute(Game1 game)
        {
            game.NextItem();        
        }
    }
}
