
using FMODUnity;
using NotEnoughMadness.Classes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    // TODO:
    // hook up component events
    // reorder the order of the fields to match up with the vanilla class order (i wrote this alphabetically from dnspy tree view 😭😭😭😭)
    // test if room works in mpn >:)


    public class NEM_Room_Main : NEM_Static_Object
    {
        [Header("NEM_Room_Main")]

        private HashSet<NEM_Target_Object> myOccupants = new HashSet<NEM_Target_Object>();
        private Dictionary<NEM_Factions, HashSet<NEM_Target_Object>> myOccupantsByFaction = new Dictionary<NEM_Factions, HashSet<NEM_Target_Object>>();

        private HashSet<string> mySerialNumbers = new HashSet<string>();

        private NEM_Room_Main.NEM_BangRecord myLastBangRecord;
        // do we need any of those ^^^^^^^

        [Tooltip("Left [0] and right [1] points of the Layout prefab")]
        public GameObject[] borderX = new GameObject[2];

        [Tooltip("Back [0] and forward [1] points of the Layout prefab")]
        public GameObject[] borderZ = new GameObject[2];

        [Tooltip("Camera target of the Layout prefab")]
        public GameObject cameraTarget;

        [Tooltip("Camera point of the Layout prefab")]
        public Camera startCamera;

        [Tooltip("How much camera shake")]
        public float handCamAmount;

        [Tooltip("Depth of Field multiplier")]
        public float depthOfFieldMult = 1f;

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

        // SKYBOX

        [Tooltip("Will search up the material by name at runtime when you play M:PN. Leave empty if you want to use Material in unity")]
        public string mySkyboxRuntime;
        [Tooltip("Skybox material")]
        public Material mySkybox;

        // FOG

        [Tooltip("Fog color")]
        public Color myFog = new Color(0f, 0f, 0f);
        [Tooltip("How dense the fog should be")]
        public float fogDensity;
        public Vector2 fogLinearStartEnd = new Vector2(0f, 300f);
        public FogMode fogMode = FogMode.ExponentialSquared; // FogMode is a UnityEngine enum, should be fine 

        [Tooltip("Ambient light color of the room")]
        public Color myAmbientLight = new Color(0.3f, 0.3f, 0.3f);

        [Tooltip("FMOD Event path")]
        public string myAmbientSound;

        [Tooltip("Multiplier for the ambient sound volume")]
        [Range(0f, 2f)]
        public float myAmbientVolume = 1f;

        [Tooltip("Objects that will be enabled *only when the room is active*")]
        public List<GameObject> activeRoomObjects = new List<GameObject>();
        public GameObject[] Toys_ResetOnReEnter = new GameObject[0];

        public List<NEM_Spawn_Point> guardPoints = new List<NEM_Spawn_Point>();
        public List<NEM_PatrolPath> patrolPaths = new List<NEM_PatrolPath>();

        public NEM_Room_Main.NEM_CaveInEvent caveInCauses = NEM_Room_Main.NEM_CaveInEvent.None;

        [Tooltip("")]
        public bool amBigOutdoors = false;
        [Tooltip("If true, scene will be forced to default to this room on start.")]
        public bool forceSceneStartRoom = false;

        [Tooltip("Are the doors here locked")]
        public bool roomDoorsLocked = false;

        [Tooltip("Room can't be combat locked")]
        public bool disableEnemyLeaveLock = false;
        [Tooltip("In story mode, rooms default to locking forever when you pass through them. If true, this leaves them unlocked. (IN STORY MODE. In arena and playground they are not locked this way.)")]
        public bool disableLockout = false;
        [Tooltip("Same as above, but place this on a locker room. It will not lock out the room you used to get here.")]
        public bool disableLockoutEntering = false;
        [Tooltip("Lets arena and Overworld doors lock you in when enemies present, as if in a Story room.")]
        public bool forceEnemyLeaveLock = false;
        [Tooltip("The room you just left gets locked out, regardless of its lockout rules.")]
        public bool forcePrevRoomLockout = false;
        [Tooltip("Even if you lock out this room, its' gameobject still won't disable. Used to keep Cutscene NPCs active once room gets locked out.")]
        public bool keepRoomActiveOnLeave = false;

        [Tooltip("Stops other players from teleporting to you when playing co-op")]
        public bool noTeammateTeleport = false;

        [Tooltip("This room won't be considered for a new wave of enemies in ANY stage, including Arena Infiltration stages.")]
        public bool notInfiltrationRoom = false;


        private Vector3 leewayLookAt = new Vector3(1f, 1f, 0f);
        private Vector2 leewayMouse = new Vector3(1f, 1f);
        private Vector3 leewayPosition = new Vector3(1f, 1f, 0f);

        

        NEM_Room_Main()
        {
            Debug.Log("NEM: NEM_Room_Main constructor called");


            MapManager.OnCreateMapComponents += OnCreateMapComponents;
            MapManager.OnConnectMapComponents += OnConnectMapComponents;
        }

        void OnCreateMapComponents(object sender, EventArgs e)
        {
            Debug.Log("NEM: NEM_Room_Main.OnCreateMapComponents called");
            gameObject.SetActive(false);

            Room_Main room = gameObject.AddComponent<Room_Main>();

            room.borderX = borderX;
            room.borderZ = borderZ;

            room.cameraTarget = cameraTarget;
            room.startCamera = startCamera;

            room.handCamAmount = handCamAmount;
            room.DepthOfFieldMult = depthOfFieldMult;

            room.allBackgrounds = allBackgrounds;
            room.allCharacters = allCharacters;
            room.allDoors = allDoors;
            room.allEvents = allEvents;
            room.allInteract = allInteract;
            room.allItems = allItems;
            room.allObstacles = allObstacles;
            room.allSounds = allSounds;
            room.allWaypoints = allWaypoints;

            if (mySkyboxRuntime != string.Empty)
            {
                // todo
                // implement runtime material searching
                // 🔥🔥🔥🔥🔥🔥

                // room.mySkybox = foundMaterial;

                // also add the other skybox down below to else { } so it doesnt override this one
            }

            room.mySkybox = mySkybox;

            room.myFog = myFog;
            room.fogDensity = fogDensity;
            room.fogLinearStartEnd = fogLinearStartEnd;
            room.fogMode = fogMode;

            room.myAmbientLight = myAmbientLight;

            room.myAmbientSound = myAmbientSound;
            room.myAmbientVolume = myAmbientVolume;

            room.ActiveRoomObjects = activeRoomObjects;
            room.Toys_ResetOnReEnter = Toys_ResetOnReEnter;

            room.CaveInCauses = (Room_Main.CaveInEvent)(int)caveInCauses;

            room.AmBigOutdoors = amBigOutdoors;
            room.ForceSceneStartRoom = forceSceneStartRoom;

            room.disableEnemyLeaveLock = disableEnemyLeaveLock;
            room.disableLockout = disableLockout;
            room.disableLockoutEntering = disableLockoutEntering;
            room.forceEnemyLeaveLock = forceEnemyLeaveLock;
            room.forcePrevRoomLockout = forcePrevRoomLockout;
            room.keepRoomActiveOnLeave = keepRoomActiveOnLeave;

            room.NoTeammateTeleport = noTeammateTeleport;

            room.notInfiltrationRoom = notInfiltrationRoom;

            room.leewayLookAt = leewayLookAt;
            room.leewayMouse = leewayMouse;
            room.leewayPosition = leewayPosition;

            room.myVehicles = new List<Vehicle_Base>();
            room.myEntrances = new List<Entrance_Base>();
        }
        void OnConnectMapComponents(object sender, EventArgs e)
        {
            Debug.Log("NEM: NEM_Room_Main.OnConnectMapComponents called");
            Room_Main room = gameObject.GetComponent<Room_Main>();

            HashSet<FMODUnity.StudioEventEmitter_Swain> newEmitters = new HashSet<FMODUnity.StudioEventEmitter_Swain>();
            foreach(NEM_StudioEventEmitter_Swain nemEmitter in allEmitters)
            {
                StudioEventEmitter_Swain foundEmitter = nemEmitter.gameObject.GetComponent<StudioEventEmitter_Swain>();

                if (foundEmitter == null) continue;

                newEmitters.Add(foundEmitter);
            }

            room.allEmitters = newEmitters;

            List<Spawn_Point> newGuardPoints = new List<Spawn_Point>();
            foreach(NEM_Spawn_Point nemPoint in guardPoints)
            {
                Spawn_Point foundPoint = nemPoint.gameObject.GetComponent<Spawn_Point>();

                if (foundPoint == null) continue;

                newGuardPoints.Add(foundPoint);
            }

            room.GuardPoints = newGuardPoints;

            List<PatrolPath> newPatrolPaths = new List<PatrolPath>();
            foreach (NEM_PatrolPath nemPath in patrolPaths)
            {
                PatrolPath newPath = new PatrolPath();

                List<Room_Point> newPathPoints = new List<Room_Point>();
                foreach(NEM_Room_Point nemPoint in nemPath.allPathPoints) 
                {
                    Room_Point foundPoint = nemPoint.gameObject.GetComponent<Room_Point>();

                    if (foundPoint == null) continue;

                    newPathPoints.Add(foundPoint);
                }

                newPath.AllPathPoints = newPathPoints;

                newPath.GenerateReturnPath = nemPath.generateReturnPath;
                newPath.LoopPath = nemPath.loopPath;
            }

            room.PatrolPaths = newPatrolPaths;

            gameObject.SetActive(true);
        }

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
