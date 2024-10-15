﻿using HarmonyLib;
using System.IO;
using UnityEngine;

namespace NotEnoughMadness.Patches
{
    // This runs when you apply disabled/enabled mods but it doesn't go through all directories again so you have to 
    [HarmonyPatch(typeof(Mod_Manager), "CommitAllModsIfPending")]
    public class Mod_Manager_CommitAllModsIfPending
    {
        [HarmonyPrefix]
        static bool Prefix(Mod_Manager __instance)
        {

            // Clear custom scene paths and unload their bundles
            Debug.Log("NEM: Unloading all scene paths and bundles.");

            FileReader.customScenePaths.Clear();

            foreach (AssetBundle loadedBundle in FileReader.loadedBundles)
            {
                if (loadedBundle == null)
                {
                    Debug.Log("NEM: Ermmm what in the madness. The loaded bundle is null?");
                    continue;
                }

                Debug.Log("NEM: Unloading bundle " + loadedBundle.name);
                loadedBundle.Unload(true);
            }

            FileReader.loadedBundles.Clear();

            return true;
        }
    }



    // This runs at the start of the game and every time you reapply mods (After the clearing above), tinker with it a bit to see if you can do everything HERE
    [HarmonyPatch(typeof(Mod_Manager), "CommitMods_MadObjs")]
    public class Mod_Manager_CommitMods_MadObj
    {
        [HarmonyPrefix]
        static bool Prefix(Mod_Manager __instance)
        {
            // GET ALL ENABLED MODS
            // CHECK DIRECTORIES FOR .MOBJ FILES (ALTERNATIVELY .NEM FILES ???)
            // 

            // FOR ALL ENABLED MODS
            foreach (Mod_Manager.ModItem modItem in Mod_Manager.ReturnAllMods(false))
            {
                // CHECK DIRECTORY FOR .NEM FILES
                foreach (FileInfo fileInfo in modItem.Directory.GetFiles("*", SearchOption.AllDirectories))
                {
                    if (fileInfo.Extension == ".nem" || fileInfo.Extension == "")
                    {
                        FileReader.ProcessModBundle(fileInfo);
                    }
                }
            }


            return true;
        }
    }
}
