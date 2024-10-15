using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotEnoughMadness.src.Patches
{
    [HarmonyPatch(typeof(Game_Manager), "IsDebugMode")]
    public class Game_Manager_IsDebugMode
    {
        [HarmonyPostfix]
        static void Postfix(Game_Manager __instance, ref bool __result)
        {
            if (NEMConfig.DebugModeOn.Value == true)
            {
                __result = true;
            }
        }
    }
}
