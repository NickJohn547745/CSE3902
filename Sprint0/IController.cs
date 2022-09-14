using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

interface IController
{
    /* Tracks mouse vs keyboard controllers. */
    public bool IsKeyboardController { get; set; }

    /* I chose to use a dictionary because it can deliver a variety 
     * of different information while keeping the accessing method
     clear and concise. */
    public Dictionary<string, int> ControllerContents { get; set; }
    void Update();
}
