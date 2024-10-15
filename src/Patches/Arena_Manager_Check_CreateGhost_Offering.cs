using UnityEngine;
using HarmonyLib;

namespace NotEnoughMadness.Patches
{
    /// <summary>
    /// Boosts the offering creation chance to 50%. Optional, can toggle in config.
    /// </summary>
    [HarmonyPatch(typeof(Arena_Manager), "Check_CreateGhost_Offering")]
    class Arena_Manager_Check_CreateGhost_Offering
    {
        [HarmonyPrefix]
        static bool Prefix(ref Combatant_Base inVictim)
        {
            if (NEMConfig.CreateGhostOfferingPatch.Value == false)
            {
                return true;
            }

            if (!Arena_Manager.Check_GhostValid_Character(inVictim, .5f, false) || !Arena_Manager.Check_GhostValid_Conditions(inVictim))
            {
                return false;
            }

            return true;
        }
    }
}

