using HarmonyLib;
using UnityEngine;

namespace CupheadQOL.Hooks
{
    internal class HideLevelIntroAnimHook
    {
        [HarmonyPostfix, HarmonyPatch(typeof(PlatformingLevelIntroAnimation), "Play")]
        private static void Play(PlatformingLevelIntroAnimation __instance)
        {
            __instance.gameObject.transform.position = new Vector3(10000f, 10000f, 0f);
        }

        [HarmonyPostfix, HarmonyPatch(typeof(LevelIntroAnimation), "Play")]
        private static void Play(LevelIntroAnimation __instance)
        {
            __instance.gameObject.transform.position = new Vector3(10000f, 10000f, 0f);
        }
    }
}
