
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    public class NEM_Room_Main : NEM_Static_Object
    {
        [Header("NEM_Room_Main")]

        [Tooltip("Left [0] and right [1] points of the Layout prefab")]
        public GameObject[] borderX = new GameObject[2];

        [Tooltip("Back [0] and forward [1] points of the Layout prefab")]
        public GameObject[] borderZ = new GameObject[2];

        [Tooltip("Camera target of the Layout prefab")]
        public GameObject cameraTarget;

        [Tooltip("Camera point of the Layout prefab")]
        public Camera startCamera;

        [Tooltip("Objects that will be enabled *only when the room is active*")]
        public List<GameObject> activeRoomObjects = new List<GameObject>();

        [Tooltip("Empty gameobject for background purposes")]
        public GameObject allBackgrounds;

        [Tooltip("Empty gameobject for characters")]
        public GameObject allCharacters;

        [Tooltip("Empty gameobject for doors")]
        public GameObject allDoors;

        [Tooltip("Empty gameobject for particle emitters")]
        public HashSet<NEM_StudioEventEmitter_Swain> allEmitters = new HashSet<NEM_StudioEventEmitter_Swain>();

        [Tooltip("Empty gameobject for events.")]
        public GameObject allEvents;

        [Tooltip("Empty gameobject for interactables")]
        public GameObject allInteract;

        [Tooltip("Empty gameobject for items.")]
        public GameObject allItems;

        [Tooltip("Empty gameobject for obstacles.")]
        public GameObject allObstacles;

        [Tooltip("Empty gameobject for sounds.")]
        public GameObject allSounds;

        [Tooltip("Empty gameobject for waypoints.")]
        public GameObject allWaypoints;

        public bool amBigOutdoors = false;

        public NEM_Room_Main.NEM_CaveInEvent caveInCauses = NEM_Room_Main.NEM_CaveInEvent.None;

        public float depthOfFieldMult = 1f;

        [Tooltip("Room can't be combat locked")]
        public bool disableEnemyLeaveLock = false;

        [Tooltip("In story mode, rooms default to locking forever when you pass through them. If true, this leaves them unlocked. (IN STORY MODE. In arena and playground they are not locked this way.)")]
        public bool disableLockout = false;
        [Tooltip("Same as above, but place this on a locker room. It will not lock out the room you used to get here.")]
        public bool disableLockoutEntering = false;

        [Tooltip("How dense the fog should be")]
        public float fogDensity;
        public Vector2 fogLinearStartEnd = new Vector2(0f, 300f);
        public FogMode fogMode = FogMode.ExponentialSquared; // FogMode is a UnityEngine enum, should be fine 

        [Tooltip("Lets arena and Overworld doors lock you in when enemies present, as if in a Story room.")]
        public bool forceEnemyLeaveLock = false;
        [Tooltip("The room you just left gets locked out, regardless of its lockout rules.")]
        public bool forcePrevRoomLockout = false;

        [Tooltip("If true, scene will be forced to default to this room on start.")]
        public bool forceSceneStartRoom = false;

        public List<NEM_Spawn_Point> guardPoints = new List<NEM_Spawn_Point>();

        public float handCamAmount;

        [Tooltip("Even if you lock out this room, its' gameobject still won't disable. Used to keep Cutscene NPCs active once room gets locked out.")]
        public bool keepRoomActiveOnLeave = false;

        public Vector3 leewayLookAt = new Vector3(1f, 1f, 0f);
        public Vector2 leewayMouse = new Vector3(1f, 1f);
        public Vector3 leewayPosition = new Vector3(1f, 1f, 0f);



        public Color myAmbientLight = new Color(0.3f, 0.3f, 0.3f);

        [Tooltip("FMOD Event path")]
        public string myAmbientSound;

        [Tooltip("Multiplier for the ambient sound volume")]
        [Range(0f, 2f)]
        public float myAmbientVolume = 1f;

        public Color myFog = new Color(0f, 0f, 0f);

        // do we need this?
        // public NEM_Room_Main.NEM_BangRecord myLastBangRecord;

        public HashSet<NEM_Target_Object> myOccupants = new HashSet<NEM_Target_Object>();
        // myoccupantsbyfaction

        // myserialnumbers

        [Tooltip("Will search up the material by name at runtime when you play M:PN. Leave empty if you want to use Material in unity")]
        public string mySkyboxRuntime;
        [Tooltip("Skybox material")]
        public Material mySkybox;


        public bool noTeammateTeleport = false;

        [Tooltip("This room won't be considered for a new wave of enemies in ANY stage, including Arena Infiltration stages.")]
        public bool notInfiltrationRoom = false;

        public List<NEM_PatrolPath> patrolPaths = new List<NEM_PatrolPath>();

        public bool roomDoorsLocked = false;

        public GameObject[] Toys_ResetOnReEnter = new GameObject[0];

        // your bangings are recorded 👽
        public class NEM_BangRecord
        {
            public NEM_Factions team;
            public int frameTime;
            public Vector3 location;
            public float loudness;
        }

        public class NEM_BattleRoom : MonoBehaviour
        {
            // ORIGINAL MPN HAS A TPYO HERE HAAHAHEHFEHAEHFHEAHFEAEHAFEAH
            public HashSet<NEM_Factions> factionsAlerted;
        }

        [Serializable]
        public enum NEM_CaveInEvent
        {
            None,
            MagSlam,
            BigSplode,
            AnySplode
        }

    }
}
