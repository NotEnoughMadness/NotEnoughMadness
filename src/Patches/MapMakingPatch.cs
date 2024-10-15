//using System.IO;
//using UnityEngine;
//using HarmonyLib;
//using Cutscene;

//namespace NotEnoughMadness.Patches
//{

//    [HarmonyPatch(typeof(UI_MissionMap_Blip), "Awake")]
//    public class UI_MissionMap_Blip_Awake
//    {
//        [HarmonyPrefix]
//        static bool Prefix(UI_MissionMap_Blip __instance)
//        {
//            Traverse blipTravel = Traverse.Create(__instance);
//            StatCard_Stage stage = blipTravel.Field("Stage").GetValue<StatCard_Stage>();

//            StatCard_Stage_Story storyStage = stage as StatCard_Stage_Story;
//            StatCard_Stage_Arena arenaStage = stage as StatCard_Stage_Arena;

//            if (storyStage is not null)
//            {
//                // STORY STAGE
                
//                Hotswap.StageCharacterSet(storyStage.RequiredCharacters);
//                Hotswap.StageCharacterSet(storyStage.BonusPlayerCharacters);
//                Hotswap.StatCard_Loadout(storyStage.Prize_Loadout);
//                Hotswap.StatCard_Loadout_Wardrobe(storyStage.Prize_Wardrobe);

//                Debug.Log("NEM: SWAPPED OUT STORY STAGE IN MISSIONMAP BLIP");
//            }
//            else if (arenaStage is not null)
//            {
//                // ARENA STAGE

//                Hotswap.WaveSpawn(arenaStage.Waves_Normal);
//                arenaStage.FinalInfiniteSequence = Hotswap.Arena_Wave_Sequence(arenaStage.FinalInfiniteSequence);
//                Hotswap.StatCard_Loadout(arenaStage.ItemDrops);
//                Hotswap.Arena_Wave_Sequence(arenaStage.WaveSequences);
//                Hotswap.WaveSpawn(arenaStage.Waves_Easy);
//                Hotswap.WaveSpawn(arenaStage.Waves_Normal);
//                Hotswap.WaveSpawn(arenaStage.Waves_Hard);
//                Hotswap.WaveSpawn(arenaStage.Waves_Madness);

//                Debug.Log("NEM: SWAPPED OUT ARENA STAGE IN MISSIONMAP BLIP");
//            }
//            else
//            {
//                // couldnt convert to either ARENA or STORY stage
//                // BOO HOO
//                // cry about it 
//            }


//            return true;
//        }
//    }
//    [HarmonyPatch(typeof(Squad_DataAssigner), "Awake")]
//    public class Squad_DataAssigner_Awake
//    {
//        [HarmonyPrefix]
//        static bool Prefix(Squad_DataAssigner __instance)
//        {
//            Debug.Log("NEM: Squad_DataAssigner Awake PREFIX");

//            __instance.spawnChatter = Hotswap.SpawnChatter(__instance.spawnChatter);
//            __instance.Wave = Hotswap.WaveSpawn(__instance.Wave);

//            return true;
//        }
//    }

//    [HarmonyPatch(typeof(Char_DataAssigner), "Awake")]
//    public class Char_DataAssigner_Awake
//    {
//        [HarmonyPrefix]
//        static bool Prefix(Char_DataAssigner __instance)
//        {
//            __instance.myType = Hotswap.StatCard_Character(__instance.myType);
//            __instance.spawnChatter = Hotswap.SpawnChatter(__instance.spawnChatter);
//            Hotswap.StatCard_Armor(__instance.itemsWorn);
//            Hotswap.UniformWearable(__instance.Uniform);
//            __instance.itemThrown = Hotswap.StatCard_Thrown(__instance.itemThrown);
//            Hotswap.StatCard_Weapon(__instance.itemsHeld);
//            Hotswap.StatCard_Weapon(__instance.itemsBack);
            

//            return true;
//        }
//    }

//    /*[HarmonyPatch(typeof(Char_Background), "Awake")]
//    public class Char_Background_Awake
//    {
//        [HarmonyPrefix]
//        static bool Prefix(Char_Background __instance)
//        {

//            Debug.Log("NEM: Char_Background Awake");

//            Hotswap.StatCard_Armor(__instance.AdditionalArmor);
//            Hotswap.UniformWearable(__instance.Uniforms);
//            __instance.Type = Hotswap.StatCard_Character(__instance.Type);
//           // Hotswap.StatCard_Item(__instance.HeldInHands);

//            return true;
//        }
//    }*/

    
//}

