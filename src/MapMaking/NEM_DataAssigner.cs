using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    public class NEM_DataAssigner : NEM_Static_Object
    {
        [Header("DataAssigner")]

        [Tooltip("")]
        public NEM_AlertStatus alertStatus = NEM_AlertStatus.Unaware;

        [Tooltip("For special characters like the Pilot, Quartermaster, Bossman, etc. It will spawn them right when the scene loads, even when they're outside of the focus room (where the player is).")]
        public bool forceSpawnOutsideFocusRoom = false;

        [Tooltip("String name of your custom faction. Leave empty to use one of the default factions below. (it has to be present in MPN already, does not create new factions by itself.) \r\n\r\n***NOT YET IMPLEMENTED")]
        public string customFaction = "";

        [Tooltip("This will be used if customFaction string is empty.")]
        public NEM_Factions defaultFaction = NEM_Factions.None;

        [Tooltip("Parameters for the patrolling stuff. Leave default if you don't want to mess with this.")]
        public NEM_PatrolParameters patrolParameters = new NEM_PatrolParameters();

        [Tooltip("Spawn chatter of the character")]
        public NEM_SpawnChatter spawnChatter = new NEM_SpawnChatter();

        [Tooltip("Only count down to spawn when this is true. Can be enabled by Event System.")]
        public bool spawnEnabled = true;

        void Awake()
        {
            Debug.LogError("NEM: You attached a NEM_DataAssigner to a gameObject: " + gameObject.name + ".\r\nThat is INCORRECT. This class should not be used. It is here only to be inherited from by other, more specific assigners, like NEM_Char_DataAssigner. Use those instead.");
            Destroy(this);
        }
    }
}
