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
    private static string PrivateEstateCost => ModSettingsDataRegister.PrivateEstateCostData.GetValue.ToString(); 

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
        if (text != "#BuyPrivateEstate" && text != "#StoryText58400") return;
        string cost;
        if (text == "#BuyPrivateEstate") cost = DefaultPrivateEstateCost;
        else cost =  "50000";
        __result = __result.Replace(cost, PrivateEstateCost);
    }
}