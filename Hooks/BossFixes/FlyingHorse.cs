using HarmonyLib;
using UnityEngine;

namespace Cuphead_Accessibility.Hooks.BossFixes
{
    internal class FlyingHorse
    {
        [HarmonyPostfix, HarmonyPatch(typeof(DicePalaceFlyingHorseLevel), "Start")]
        private static void Start(DicePalaceFlyingHorseLevel __instance)
        {
            Plugin.DisableObj("Level/Foreground/kd_horse_bg_near_big_porch");
            Plugin.DisableObj("Level/Foreground/kd_horse_bg_near_bleacher");
            Plugin.DisableObj("Level/Foreground/kd_horse_bg_near_lamp_01");
            Plugin.DisableObj("Level/Foreground/kd_horse_bg_near_lamp_02 (1)");
            Plugin.DisableObj("Level/Foreground/kd_horse_bg_near_lamp_02");
            Plugin.DisableObj("Level/Foreground/kd_horse_bg_near_trees_01-loop");
            Plugin.DisableObj("Level/Foreground/kd_horse_bg_near_trees_02-loop");
            Plugin.DisableObj("Level/Foreground/kd_horse_bg_near_trees_03-loop");
            Plugin.DisableObj("Level/Foreground/kd_horse_bg_near_very_close_trees_01");
            Plugin.DisableObj("Level/Foreground/kd_horse_bg_near_very_close_trees_02");
        }
    }
}
