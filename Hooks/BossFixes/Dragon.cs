using HarmonyLib;
using UnityEngine;

namespace CupheadQOL.Hooks.BossFixes
{
    internal class Dragon
    {
        //BUG. One frame of lightning plays at the beginning of the final phase. 
        [HarmonyPrefix, HarmonyPatch(typeof(DragonLevelLightning), "PlayLightning")]
        private static void PlayLightning(DragonLevelLightning __instance)
        {
            GameObject.Destroy(__instance.gameObject);
            return;
        }

        [HarmonyPrefix, HarmonyPatch(typeof(DragonLevelRain), "StartRain")]
        private static void StartRain(DragonLevelRain __instance)
        {
            GameObject.Destroy(__instance.gameObject);
            return;
        }
    }
}
