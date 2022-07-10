using HarmonyLib;
using UnityEngine;

namespace Cuphead_Accessibility.Hooks
{
    internal class MuteAnnouncer
    {
        [HarmonyPostfix, HarmonyPatch(typeof(LevelAudio), "Create")]
        private static void PlayAnnouncerBegin(Level __instance)
        {
            Plugin.DestroyObj("Level_Audio(Clone)/Announcer");
        }
    }
}
