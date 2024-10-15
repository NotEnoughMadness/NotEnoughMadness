using System;
using System.Collections.Generic;
using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    public class NEM_Entrance_Base : NEM_Person_Repository
    {
        // CharacterQueue is set automatically methinks
        // entrancePathRecords

        public bool disableSpawn = false;
        public bool snapToFloor = true;
        public bool spawnWhenClosed = true;

        [Tooltip("Time before door self-closes (-1 means never)")]
        public float doorOpenTime = 30f;

        [Tooltip("Time to wait after being given a guy (when I was empty) before spawning him. Gives time for others to spawn before it opens (ex: Lifts)")]
        public float startupWaitTime = -1f;

        public bool clearStartupAfterFirst = false;

        public string closeSound;
        public string openSound;

        public float useSpeedMult = 2f;

        public bool disableLightIfNoLink = true;

        public List<Transform> exitPoints = new List<Transform>();
        public List<Transform> spawnPoints = new List<Transform>();

        List<Animator> accessLights = new List<Animator>();

        void Awake()
        {

        }


        [Serializable]
        public enum NEM_DoorStatus
        {
            Open,
            Closed,
            Opening,
            Closing
        }

        [Serializable]
        public enum NEM_ExitSpeed
        {
            // Token: 0x040026E2 RID: 9954
            Walk,
            // Token: 0x040026E3 RID: 9955
            Run,
            // Token: 0x040026E4 RID: 9956
            Sprint
        }
    }
}
