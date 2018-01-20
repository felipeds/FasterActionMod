using Harmony;
using UnityEngine;
namespace FasterActionMod
{
    [HarmonyPatch(typeof(AccelTimePopup), "SetActive")]
    public class FasterActionMod
    {
        public static void Prefix(bool active)
        {
            if (active)
            {
                Time.timeScale = 30f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        public static void Postfix()
        {
        }
    }
}
