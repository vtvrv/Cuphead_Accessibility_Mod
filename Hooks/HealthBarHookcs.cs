using HarmonyLib;
using System;

namespace CupheadQOL.Hooks
{
    internal class HealthBarHookcs
    {
        [HarmonyPostfix, HarmonyPatch(typeof(UnityEngine.Screen), "SetResolution", new Type[] { typeof(int), typeof(int), typeof(bool) })]
        private static void SetResolution(UnityEngine.Screen __instance, ref int width, ref int height, ref bool fullscreen)
        {
            CupheadQOL.Plugin.UpdateHealthBarDimensions(width, height);
        }

        [HarmonyPostfix, HarmonyPatch(typeof(UnityEngine.Screen), "SetResolution", new Type[] { typeof(int), typeof(int), typeof(bool), typeof(int) })]
        private static void SetResolution(UnityEngine.Screen __instance, ref int width, ref int height, ref bool fullscreen, ref int preferredRefreshRate)
        {
            CupheadQOL.Plugin.UpdateHealthBarDimensions(width, height);
        }
    }
}
