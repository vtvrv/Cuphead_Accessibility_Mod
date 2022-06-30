using HarmonyLib;
using UnityEngine;

namespace CupheadQOL.Hooks
{
    internal class DisableHitFlashHook
    {
        [HarmonyPrefix, HarmonyPatch(typeof(HitFlash), "Awake")]
        private static void Awake(HitFlash __instance)
        {
            Traverse.Create(__instance).Field("damageColor").SetValue(new Color(0f, 0f, 0f, 1f)); //set "damageColor" equal to "normalColor"
        }
    }
}
