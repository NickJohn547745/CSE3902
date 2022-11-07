using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using sprint0.Interfaces;
using sprint0.PlayerClasses;

namespace sprint0.Commands; 

public class MuteCommand : ICommand
{ 
    public void Execute(Game1 game)
    {
        if (SoundEffect.MasterVolume == 1.0f) SoundEffect.MasterVolume = 0.0f;
        else SoundEffect.MasterVolume = 1.0f;
    }
}