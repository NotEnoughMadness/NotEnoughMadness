using HarmonyLib;

namespace NotEnoughMadness.Patches
{
    /// <summary>
    /// Sets the version in the corner of the screen. You can change it in NEMConfig.cs
    /// </summary>
    [HarmonyPatch(typeof(UI_Version), "ResetVersion")]
    class UI_Version_ResetVersion
    {
        [HarmonyPostfix]
        static void Postfix()
        {
            if (UI_Version.currentWidget == null)
            {
                return;
            }
            UI_Version.currentWidget.Text_Version.text = NEMConfig.Version;
        }
    }
}

