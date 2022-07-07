using HarmonyLib;

namespace Cuphead_Accessibility.Hooks
{
    internal class DisableGrainHook
    {
        [HarmonyPrefix, HarmonyPatch(typeof(BlurGamma), "CheckResources")]
        private static bool CheckResources(BlurGamma __instance)
        {
            return false;
        }

        [HarmonyPrefix, HarmonyPatch(typeof(ChromaticAberrationFilmGrain), "CheckResources")]
        private static bool CheckResources(ChromaticAberrationFilmGrain __instance)
        {
            return false;
        }
    }
}
