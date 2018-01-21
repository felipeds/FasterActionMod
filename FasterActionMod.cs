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

    }


    [HarmonyPatch(typeof(Container), "BeginContainerInteraction")]
    public class FasterActionContainerUpdateMod
    {
        public static void Prefix(ref float searchTimeSeconds)
        {
            searchTimeSeconds = 0.01f;
        }

    }

    [HarmonyPatch(typeof(Panel_GenericProgressBar), "Launch")]
    public class FasterActionPanelLaunchMod
    {
        public static void Prefix(ref float seconds)
        {
            seconds = 0.5f;
        }

    }

}
