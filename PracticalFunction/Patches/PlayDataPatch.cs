using HarmonyLib;
using MBMScripts;

namespace PracticalFunction.Patches;

[HarmonyPatch(typeof(PlayData))]
public class PlayDataPatch
{
    //Allow proper achievement points acquisition when initializing a new save.
    [HarmonyPatch(nameof(PlayData.AchievementPoint), MethodType.Setter)]
    [HarmonyPrefix]
    public static bool AchievementPointPrefix(int value)
    {
        if (value == 0 && !GameManager.Instance.PlayerData.GetGameEventFlag(EGameEvent.SavePoint_10000000)) 
            return false;
        return true;
    }
}