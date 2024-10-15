using HarmonyLib;
using Popup;

namespace NotEnoughMadness.Patches
{
    // Increase size for popups when in fps
    [HarmonyPatch(typeof(Popup_Base), "Init")]
    class Popup_Base_Init
    {
        [HarmonyPostfix]
        static void Postfix(Popup_Base __instance)
        {
            if (NEMMenu.GetCameraType() == NEMMenu.CameraTypes.Fps)
            {
                __instance.transform.localScale *= 2.5f;
            }
        }
    }

    // Correct the aim
    [HarmonyPatch(typeof(Item_AnimController), "applyAimUp")]
    class Item_AnimController_ApplyAimUp
    {
        [HarmonyPrefix]
        static bool Prefix(Item_AnimController __instance, ref Item_AnimController.GunAimHeight inAimUp)
        {
            if (NEMMenu.GetCameraType() != NEMMenu.CameraTypes.Vanilla)
            {
                inAimUp = Item_AnimController.GunAimHeight.Normal;
            }

            return true;
        }
    }

    // TODO: COPY OVER Controller_Player.RunControls_MouseAim() from NEM earlier
    // ^^^ FPSCamera.AimChange() try to understand it and reimplement
    // Combatant_Base.ReturnHeatseekTarget() see whats up with that and if you can ignore this



}
