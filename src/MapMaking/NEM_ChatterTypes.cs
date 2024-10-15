using System;
using System.Collections.Generic;
using System.Text;

namespace NotEnoughMadness.MapMaking
{
    [Serializable]
    public enum NEM_ChatterTypes
    {
        Wakeup,
        Spawned,
        Chasing,
        Waiting,
        Attacking,
        Wounded,
        Died,
        FriendDied,
        EnemyDown,
        Taunt,
        NONE = 100
    }
}
