using HarmonyLib;
using UnityEngine;

namespace Cuphead_Accessibility.Hooks.BossFixes
{
    internal class FlyingHorse
    {
        private static void DisableObj(string objName)
        {
            var obj = GameObject.Find(objName);
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(DicePalaceFlyingHorseLevel), "Start")]
        private static void Start(DicePalaceFlyingHorseLevel __instance)
        {
            DisableObj("Level/Foreground/kd_horse_bg_near_big_porch");
            DisableObj("Level/Foreground/kd_horse_bg_near_bleacher");
            DisableObj("Level/Foreground/kd_horse_bg_near_lamp_01");
            DisableObj("Level/Foreground/kd_horse_bg_near_lamp_02 (1)");
            DisableObj("Level/Foreground/kd_horse_bg_near_lamp_02");
            DisableObj("Level/Foreground/kd_horse_bg_near_trees_01-loop");
            DisableObj("Level/Foreground/kd_horse_bg_near_trees_02-loop");
            DisableObj("Level/Foreground/kd_horse_bg_near_trees_03-loop");
            DisableObj("Level/Foreground/kd_horse_bg_near_very_close_trees_01");
            DisableObj("Level/Foreground/kd_horse_bg_near_very_close_trees_02");
        }
    }
}
