/*
using HarmonyLib;
using UnityEngine;
using System;

namespace Cuphead_Accessibility.Hooks
{
    internal class DisableAudioWarbleHook
    {
        [HarmonyPrefix, HarmonyPatch(typeof(AudioManagerComponent), "OnBGMWarblePitch", new Type[] { typeof(int), typeof(float[]), typeof(float[]), typeof(float[]), typeof(float[]) })]

        private static void OnBGMWarblePitch(AudioManagerComponent __instance, ref int warbles, ref float[] minValue, ref float[] maxValue, ref float[] warbleTime, ref float[] playTime)
        {
            return;
        }

        [HarmonyPrefix, HarmonyPatch(typeof(AudioManagerComponent), "OnBGMWarblePitch", new Type[] { typeof(float[]), typeof(float[]), typeof(float[]), typeof(float[]) })]
        private static void OnBGMWarblePitch(AudioManagerComponent __instance, ref float[] minValue, ref float[] maxValue, ref float[] warbleTime, ref float[] playTime)
        {
            return;
        }

        [HarmonyPrefix, HarmonyPatch(typeof(AudioManagerComponent), "OnAttenuation")]
        private static void OnAttenuation(AudioManagerComponent __instance, ref string key, ref bool attenuating, ref float endVolume)
        {
            return;
        }

        [HarmonyPrefix, HarmonyPatch(typeof(AudioWarble), "HandleWarble")]
        private static void HandleWarble(AudioWarble __instance)
        {
            __instance.enabled = false;
            return;
        }
    }
}
*/