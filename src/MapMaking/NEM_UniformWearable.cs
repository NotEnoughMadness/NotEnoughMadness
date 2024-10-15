using System.Collections.Generic;
using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    public class NEM_UniformWearable : MonoBehaviour
    {
        [Tooltip("List of StatCard_Armor names")]
        public string[] armorList;

        [Tooltip("0 is the default material of the armor")]
        public int altMaterialIndex = 0;

        [Tooltip("0 is the default mesh of the armor")]
        public int altMeshIndex = 0;

        [Tooltip("Primary swatch color")]
        public Color tint1Color;

        [Tooltip("Secondary swatch color")]
        public Color tint2Color;

        [Tooltip("Tertiary/Glow/Glass swatch color")]
        public Color glassColor;
    }
}