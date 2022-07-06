using HarmonyLib;
using UnityEngine;

namespace CupheadQOL.Hooks
{
    internal class DebugMenuFix
    {
        [HarmonyPostfix, HarmonyPatch(typeof(LevelSelectScene), "Update")]
        private static void Update(LevelSelectScene __instance)
        {
            Cursor.visible = true;
            //Still freezes after a few seconds
            //Something to do with event system
            //Doesn't freeze when UnityExplorer is open https://github.com/sinai-dev/UnityExplorer
            //See https://github.com/sinai-dev/UniverseLib/blob/main/src/Input/CursorUnlocker.cs
        }
    }
}