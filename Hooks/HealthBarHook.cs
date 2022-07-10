using HarmonyLib;
using System;

namespace Cuphead_Accessibility.Hooks
{
    internal class HealthBarHook
    {
        [HarmonyPostfix, HarmonyPatch(typeof(UnityEngine.Screen), "SetResolution", new Type[] { typeof(int), typeof(int), typeof(bool) })]
        private static void SetResolution(UnityEngine.Screen __instance, ref int width, ref int height, ref bool fullscreen)
        {
            Plugin.UpdateHealthBarDimensions(width, height);
        }
        

        [HarmonyPostfix, HarmonyPatch(typeof(UnityEngine.Screen), "SetResolution", new Type[] { typeof(int), typeof(int), typeof(bool), typeof(int) })]
        private static void SetResolution(UnityEngine.Screen __instance, ref int width, ref int height, ref bool fullscreen, ref int preferredRefreshRate)
        {
            Plugin.UpdateHealthBarDimensions(width, height);
        }
    }
}
