using HarmonyLib;
using System.Collections.Generic;
using System.Linq;

namespace NotEnoughMadness.Patches
{
    [HarmonyPatch(typeof(InteractiveMode), "Start")]
    public class InteractiveMode_Start
    {
        [HarmonyPostfix]
        public static void Postfix(InteractiveMode __instance)
        {
            if (NEMConfig.UnlockInteractiveRestrictions.Value == false)
            {
                return;
            }

            Traverse interactiveTraverse = Traverse.Create(__instance);

            // Get ALL characters, even ones where o.CharacterEnabled = false
            // This list is also used for morph characters
            // For morhps in vanilla it removes characters who's myRef isn't Character_Default (the default grunt rig).
            // That makes characters using custom rigs impossible to morph into. We don't care 😱😱😱😱😱
            List<StatCard_Character> allCharacters = StatCard_Base.ReturnAllCardsByType<StatCard_Character>().ToList();

            // Get ALL weapons, not just ((StatCard_Weapon o) => o.ItemEnabled && o.TierValidForStore() && o.ForSale != StatCard_Item.Store.Arcane)
            List<StatCard_Weapon> allWeapons = StatCard_Base.ReturnAllCardsByType<StatCard_Weapon>().ToList();

            // Sort the lists like in vanilla
            allCharacters.SortCards<StatCard_Character>();
            allWeapons.SortCards<StatCard_Weapon>();

            interactiveTraverse.Field("allDudes_Spawn").SetValue(allCharacters);
            interactiveTraverse.Field("allDudes_Morph").SetValue(allCharacters);
            interactiveTraverse.Field("allWeapons").SetValue(allWeapons);
            
            //🤙🤙🤙les go
        }
    }
}
