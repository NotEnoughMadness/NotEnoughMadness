using System;
using System.Collections.Generic;
using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    [Serializable]
    public class NEM_PatrolPath
    {
        [Header("NEM_PatrolPath")]

        // do we need this
        [Tooltip("All path points in the entire room ever probably maybe???")]
        public List<NEM_Room_Point> allPathPoints = new List<NEM_Room_Point>();

        [Tooltip("If TRUE, the exact path used to get from the first to the last Point will be duplicated and reversed, allowing the Squad to return the way they came.")]
        public bool generateReturnPath = true;

        public bool loopPath = true;
    }
}