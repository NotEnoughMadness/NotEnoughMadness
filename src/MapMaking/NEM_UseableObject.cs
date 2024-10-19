using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    public class NEM_UseableObject : NEM_Static_Object
    {
        [Header("NEM_UseableObject")]
        [Tooltip("Location of use point")]
        public Transform usePoint;
    }
}