using System.Collections.Generic;
using HarmonyLib;

namespace NotEnoughMadness.Patches
{
    /// <summary>
    /// Unlocks all origin icons in character creation screen. Toggle in NEMConfig.cs
    /// Imprints will still affect stats regardless.
    /// </summary>
    [HarmonyPatch(typeof(UI_CharCreator), "UpdateOrigins")]
    class UI_CharCreator_UpdateOrigins {
        [HarmonyPostfix] 
        static void Postfix(UI_CharCreator __instance) 
        {
            if (NEMConfig.OriginsUnlocked.Value == false)
            {
                return;
            }

            Traverse charCreator = Traverse.Create(__instance);
            List<UI_CharCreator.OriginIcon> originIcons = charCreator.Field("allOriginIcons").GetValue() as List<UI_CharCreator.OriginIcon>;

            foreach (UI_CharCreator.OriginIcon icon in originIcons) 
            {
                /* og code for disabling
                  ui_Ref_Storage.Buttons[0].interactable = false;
			      ui_Ref_Storage.Images[0].color = Color.grey;
			      ui_Ref_Storage.Text[0].color = Color.grey;
			      ui_Ref_Storage.RawImages[0].enabled = false;
                */

                // Enable all icons 
                icon.myRef.Buttons[0].interactable = true;
                icon.myRef.Images[0].color = icon.myRef.Colors[0];
                icon.myRef.Text[0].color = icon.myRef.Colors[0];
                icon.myRef.RawImages[0].enabled = true;
            }

        }
    }
}

