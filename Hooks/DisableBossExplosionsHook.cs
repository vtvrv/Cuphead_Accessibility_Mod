using HarmonyLib;
using UnityEngine;

namespace CupheadQOL.Hooks
{
    internal class DisableBossExplosionsHook
    {
        [HarmonyPrefix, HarmonyPatch(typeof(LevelBossDeathExploder), "Start")]
        private static void Start(LevelBossDeathExploder __instance)
        {
            Traverse.Create(__instance).Field("offset").SetValue(new Vector2(10000f, 10000f)); //Move offscreen
        }
    }
}
