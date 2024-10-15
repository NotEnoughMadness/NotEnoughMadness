using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    [Serializable]
    public class NEM_SpawnChatter
    {
        [Tooltip("If true, it will display with character portrait on the top of the screen. If false, it will display the character's chatter blurb above their heads.")]
        public bool amNarrative = false;

        [Tooltip("Name of the AnimationClip object.")]
        public string animationClip = "";

        [TextArea(0, 2)]
        [Tooltip("What the character will say.")]
        public string chatterText = "";

        [Tooltip("If false, the character will NOT say the thing if they're in combat.")]
        public bool playInCombat = true;

        [Tooltip("How much seconds to delay before saying the text.")]
        public float delayTime = 0f;

        [Tooltip("What chatter type to say.")]
        public NEM_ChatterTypes chatterType = NEM_ChatterTypes.Spawned;
    }
}
