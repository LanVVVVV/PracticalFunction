using HarmonyLib;
using MBMScripts;
using PracticalFunction.ModConfig;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

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

    #region AllowDNAWithoutNiel
    public static bool EnableAllowDNAWithoutNiel => ModSettingsDataRegister.AllowDNAWithoutNiel.GetValue;

    [HarmonyPatch(typeof(PlayData), nameof(PlayData.FloraDismantle))]
    [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);

        var getUpgradeFlag = AccessTools.Method(typeof(PlayData), nameof(PlayData.GetUpgradeFlag), new[] { typeof(EUpgradeType) });

        var enableGetter = AccessTools.PropertyGetter(typeof(PlayDataPatch), nameof(EnableAllowDNAWithoutNiel));
        
        for (int i = 0; i < codes.Count; i++)
        {
            if (codes[i].Calls(getUpgradeFlag))
            {
                if (i > 0 && codes[i - 1].opcode == OpCodes.Ldc_I4_S
                    && (sbyte)codes[i - 1].operand == (sbyte)EUpgradeType.UpgradeNiel)
                {
                    codes.Insert(i + 1, new CodeInstruction(OpCodes.Call, enableGetter));
                    codes.Insert(i + 2, new CodeInstruction(OpCodes.Or));
                    break;
                }
            }
        }

        return codes;
    }
    #endregion
}