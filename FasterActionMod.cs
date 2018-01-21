using Harmony;
using UnityEngine;
namespace FasterActionMod
{
    public class FasterConfig
    {
        public static float ACTION_TIME = 0.5f;
    }
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
            searchTimeSeconds = 0.2f;
        }

    }

    [HarmonyPatch(typeof(Panel_GenericProgressBar), "Launch")]
    public class FasterActionPanelLaunchMod
    {
        public static void Prefix(ref float seconds)
        {
            seconds = FasterConfig.ACTION_TIME;
        }

    }

    /// <summary>
    /// For drinking and eating you have to set the right speed on the ADd actions so you eat / drink the right ammount on the accelerated time.
    /// </summary>
    [HarmonyPatch(typeof(Thirst), "AddThirstOverTime")]
    public class FasterActionThirstMod
    {
        public static void Prefix(ref float timeSeconds)
        {
            timeSeconds = FasterConfig.ACTION_TIME;
        }

    }

    [HarmonyPatch(typeof(Hunger), "AddReserveCaloriesOverTime")]
    public class FasterActionHungerMod
    {
        public static void Prefix(ref float timeSeconds)
        {
            timeSeconds = FasterConfig.ACTION_TIME;
        }

    }
}
