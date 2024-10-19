using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    public class NEM_World_Object : MonoBehaviour
    {
        [Header("NEM_World_Object")]
        [Tooltip("This is the serial number of the world object")]
        public string serialNumber = "";
        // the rest is either public but hidden in inspector ( we can set those at runtime ) or protected/private

        public enum NEM_SelectionTypes
        {
            Use,
            Pickup,
            Cover,
            SquadOrder,
            Grapple,
            NONE = 50
        }
    }

    
}