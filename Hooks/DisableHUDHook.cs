using HarmonyLib;
using UnityEngine;

namespace CupheadQOL.Hooks
{
    internal class DisableHUDHook
    {
        private static void DisableObj(string objName)
        {
            var obj = GameObject.Find(objName);
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(MapUI), "Start")]
        private static void Start(MapUI __instance)
        {
            DisableObj("Map_UI(Clone)/HUDCanvas");
        }

        [HarmonyPostfix, HarmonyPatch(typeof(LevelHUD), "Start")]
        private static void Start(LevelHUD __instance)
        {
            DisableObj("Level_HUD/Canvas/Players/Cuphead/Health");
            DisableObj("Level_HUD/Canvas/Players/Cuphead/Weapon");
            DisableObj("Level_HUD/Canvas/Players/Cuphead/Super");

            DisableObj("Level_HUD/Canvas/Players/Mugman/Health");
            DisableObj("Level_HUD/Canvas/Players/Mugman/Weapon");
            DisableObj("Level_HUD/Canvas/Players/Mugman/Super");
        }
    }
}
