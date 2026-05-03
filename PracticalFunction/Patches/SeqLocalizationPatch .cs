using HarmonyLib;
using MBM.ModLoader.Core;
using MBMScripts;
using PracticalFunction.ModConfig;
using System.Collections.Generic;

namespace PracticalFunction.Patches;

[HarmonyPatch(typeof(SeqLocalization))]
public class SeqLocalizationPatch
{
    public static readonly Dictionary<string, string> DicDefaultPrivateEstateCost = new Dictionary<string, string>
    {
        { "en", "50,000" },
        { "zh-CN", "5万" },
        { "zh-TW", "5萬" },
    };

    private static string DefaultPrivateEstateCost { get; set; } = "50,000";
    private static string PrivateEstateCost { get => ModSettingsDateRegister.PrivateEstateCostDate.GetValue.ToString(); }

    internal static void SetDefaultPrivateEstateCost()
    {
        if (!DicDefaultPrivateEstateCost.TryGetValue(Localization.CurrentLanguageCode, out string text))
            text = "50000";
        DefaultPrivateEstateCost = text;
    }

    // PrivateEstateCost 
    [HarmonyPatch(nameof(SeqLocalization.Localize))]
    [HarmonyPostfix]
    public static void LocalizePostfix(ref string __result, string text)
    {
        if (text != "#BuyPrivateEstate") return;
        ModEntry.Log(__result);
        __result = __result.Replace(DefaultPrivateEstateCost, PrivateEstateCost);
    }
}