using System;
using System.Collections.Generic;
using System.Text;

namespace NotEnoughMadness.MapMaking
{
    [Serializable]
    public enum NEM_AlertStatus
    {
        Unaware,
        Hunting,
        Combat,
        Match = 100
    }
}
