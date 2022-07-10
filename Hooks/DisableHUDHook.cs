using HarmonyLib;
using UnityEngine;

namespace Cuphead_Accessibility.Hooks
{
    internal class DisableHUDHook
    {
        //MAP

        [HarmonyPostfix, HarmonyPatch(typeof(MapUI), "Start")]
        private static void Start(MapUI __instance)
        {
            Plugin.DisableObj("Map_UI(Clone)/HUDCanvas");
        }





        //LEVEL
        private static void DisableLevelHud()
        {
            Plugin.HideObj("Level_HUD/Canvas/Players/");

        }

        [HarmonyPostfix, HarmonyPatch(typeof(LevelHUD), "Start")]
        private static void Start(LevelHUD __instance)
        {
            DisableLevelHud();
        }

        [HarmonyPostfix, HarmonyPatch(typeof(LevelHUD), "OnPlayerJoined")]
        private static void OnPlayerJoined(LevelHUD __instance, ref PlayerId player)
        {
            DisableLevelHud();
        }
    }
}
