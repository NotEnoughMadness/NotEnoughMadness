using HarmonyLib;
using System;

namespace NotEnoughMadness.Patches
{

    // Infinite ammo for throwables
    [HarmonyPatch(typeof(Item_Ranged), "SpendAmmo")]
    class Item_Ranged_SpendAmmo
    {
        [HarmonyPrefix]
        static bool Prefix(Item_Held __instance)
        {
            // check if the guy who has the ranged is player one 
            if (NEMMenu.toggleBools["InfiniteAmmo"] == true && __instance.amThrown && __instance.myOwner == Controller_Base.PlayerOne)
            {
                // Don't do anything and just return and don't execute the original code. We don't want no ammo wasting!!!!
                return false;
            }

            return true;
        }
    }

    // Infinite ammo for melees if player one is the owner
    [HarmonyPatch(typeof(Item_Held), "SpendMeleeAmmo")]
    class Item_Held_SpendMeleeAmmo
    {
        [HarmonyPrefix]
        static bool Prefix(Item_Held __instance, int inAmmo)
        {
            // check if the guy who has the melee is player one 
            /*
             * Note:
             * Checking for myOwner causes thrown weapon to lose durability even if you are the owner (because now you're not, not anymore, not until you wield your blade once more)
             * But at least enemies don't have infinite durability now, that's consistent with infinite ammo (a trait given to the player only)
             */
            if (NEMMenu.toggleBools["InfiniteAmmo"] == true && __instance.myOwner == Controller_Base.PlayerOne)
            {
                // Don't do anything and just return and don't execute the original code. We don't want no ammo wasting!!!!
                return false;
            }

            return true;
        }
    }

    // Infinite ammo for ranged guns, you reload infinitely with no spare mags
    [HarmonyPatch(typeof(Combatant_Base), "SpareMag_Have")]
    class Combatant_Base_SpareMag_Have
    {
        [HarmonyPostfix]
        static void Postfix(Combatant_Base __instance, ref bool __result)
        {
            if (NEMMenu.toggleBools["InfiniteAmmo"] == true && __instance == Controller_Base.PlayerOne)
            {
                __result = true;
            }
        }
    }
    [HarmonyPatch(typeof(Combatant_Base), "SpareMag_Spend")]
    class Combatant_Base_SpareMag_Spend
    {
        [HarmonyPostfix]
        static void Postfix(Combatant_Base __instance, ref bool __result)
        {
            // check if the guy who has the ranged is player one 
            if (NEMMenu.toggleBools["InfiniteAmmo"] == true && __instance == Controller_Base.PlayerOne)
            {
                // Don't do anything and just return and don't execute the original code. We don't want no ammo wasting!!!!
                __result = true;
            }
        }
    }

    // Bottomless mag (can be inf ammo if you have inf ammo enabled but by itself it just skips the reload animation 👍👍👍)
    [HarmonyPatch(typeof(Combatant_Base), "ReloadWeapon", new[] {typeof(Item_Ranged)})]
    class Combatant_Base_ReloadWeapon
    {
        [HarmonyPrefix]
        static bool Prefix(Combatant_Base __instance, Item_Ranged inRanged)
        {
            if (NEMMenu.toggleBools["BottomlessMag"] == true && __instance == Controller_Base.PlayerOne)
            {
                // Load the ammo here manually and skip animation

                if (inRanged.myExtraMags <= 0f && inRanged.myAmmo <= 0 && NEMMenu.toggleBools["InfiniteAmmo"] == false)
                {
                    return true;
                }

                inRanged.SetMags(UnityEngine.Mathf.Clamp(inRanged.myExtraMags - 1f, 0f, inRanged.myExtraMags));
                
                inRanged.SetAmmo(inRanged.myAmmoMax);
                
                return false;
            }

            return true;
        }
    }
}

