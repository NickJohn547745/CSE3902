using sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Commands
{
    public class CommandData
    {
        public IController.KeyState KeyState = IController.KeyState.KeyUp;
        public CommandData(IController.KeyState keyState)
        {
            KeyState = keyState;
        }
    }
}
