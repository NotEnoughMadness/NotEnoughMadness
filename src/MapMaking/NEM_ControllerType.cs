using System;
using System.Collections.Generic;
using System.Text;

namespace NotEnoughMadness.MapMaking
{
    [Serializable]
    public enum NEM_ControllerType
    {
        Empty,
        Player,
        Network,
        NPC,
        Boss,
        Simple,
        Bot,
        Turret,
        DEFAULT = 100
    }
}
