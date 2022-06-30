using HarmonyLib;
using UnityEngine;

namespace CupheadQOL.Hooks.BossFixes
{
    internal class Bee
    {
        //Destroy the animated honey on the borders
        [HarmonyPostfix, HarmonyPatch(typeof(BeeLevelBackground), "LevelInit")]
        private static void LevelInit(BeeLevelBackground __instance)
        {
            GameObject honeyObj = GameObject.Find("Honey");
            if (honeyObj != null)
                GameObject.Destroy(honeyObj);
        }

        //Destroy honey dripping from top of level
        [HarmonyPrefix, HarmonyPatch(typeof(BeeLevelHoneyDrip), "Awake")]
        private static void Awake(BeeLevelHoneyDrip __instance)
        {
            GameObject.Destroy(__instance.gameObject);
        }

        //Stop animations of platforms
        [HarmonyPostfix, HarmonyPatch(typeof(BeeLevelPlatforms), "Init")]
        private static void Init(BeeLevelPlatforms __instance)
        {
            Transform[] rows = Traverse.Create(__instance).Field("rows").GetValue() as Transform[];
            foreach(Transform row in rows)
            {
                foreach (var component in row.gameObject.GetComponentsInChildren<AnimationHelper>())
                    GameObject.Destroy(component);
                foreach (var component in row.gameObject.GetComponentsInChildren<UnityEngine.Animator>())
                    GameObject.Destroy(component);
            }
        }
        
    }
}
