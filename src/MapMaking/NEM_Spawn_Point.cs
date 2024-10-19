using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    public class NEM_Spawn_Point : NEM_Room_Point
    {
        [Header("NEM_Spawn_Point")]

        public bool disablePublicUse;

        [Tooltip("Do I parent to my room, or can I go anywhere?")]
        public bool mobilePoint;

        public int objectiveNumber;
    }
}