using HarmonyLib;

namespace Cuphead_Accessibility.Hooks
{
    internal class HealthBarTextHook
    {
        public static string padding = "0000";

        //sets number of leading zeros in the damage text to match the length of the enemy's health
        [HarmonyPostfix, HarmonyPatch(typeof(Level), "Awake")]
        private static void Awake(Level __instance)
        {
            if (__instance.timeline != null)
            {
                int numlength = __instance.timeline.health.ToString().Length;
                padding = new string('0', numlength);
            }
            else
            {
                padding = "0000";
            }
            updateHealthBarText();
        }

        public static void updateHealthBarText()
        {
            if (Level.Current.timeline != null)
                Plugin.healthBarText = Level.Current.timeline.damage.ToString(padding) + "/" + Level.Current.timeline.health.ToString();
            else
                Plugin.healthBarText = "";
        }

        [HarmonyPostfix, HarmonyPatch(typeof(Level.Timeline), "DealDamage")]
        public static void DealDamage(Level.Timeline __instance, ref float damage)
        {
            updateHealthBarText();
        }
    }
}
