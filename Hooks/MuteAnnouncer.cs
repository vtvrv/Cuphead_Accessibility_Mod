using HarmonyLib;
using UnityEngine;

namespace CupheadQOL.Hooks
{
    internal class MuteAnnouncer
    {
        private static void DisableObj(string objName)
        {
            var obj = GameObject.Find(objName);
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        [HarmonyPrefix, HarmonyPatch(typeof(Level), "PlayAnnouncerReady")]
        private static void PlayAnnouncerReady(Level __instance)
        {
            DisableObj("Level_Audio(Clone)/Announcer/Begin");
            DisableObj("Level_Audio(Clone)/Announcer/Ready");
            return;
        }

        [HarmonyPrefix, HarmonyPatch(typeof(Level), "PlayAnnouncerBegin")]
        private static void PlayAnnouncerBegin(Level __instance)
        {
            DisableObj("Level_Audio(Clone)/Announcer/Begin");
            DisableObj("Level_Audio(Clone)/Announcer/Ready");
            return;
        }
    }
}
