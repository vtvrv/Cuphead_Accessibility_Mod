/*
using HarmonyLib;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CupheadQOL.Hooks
{
    internal class LauchToTileHook
    {
        [HarmonyPostfix, HarmonyPatch(typeof(StartScreen), "Start")]
        private static void Start(StartScreen __instance)
        {
            SceneManager.LoadScene("scene_slot_select");
        }
    }
}
*/