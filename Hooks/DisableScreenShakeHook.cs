using HarmonyLib;

namespace CupheadQOL.Hooks
{
    internal class DisableScreenShakeHook
    {
        [HarmonyPrefix, HarmonyPatch(typeof(AbstractCupheadGameCamera), "Shake")]
        private static void Shake(AbstractCupheadGameCamera __instance, ref float amount, ref float time)
        {
            amount = 0f;
        }
    }
}
