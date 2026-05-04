using HarmonyLib;
using MBMScripts;
using PracticalFunction.ModConfig;

namespace PracticalFunction.Patches;

[HarmonyPatch(typeof(ConfigData))]
public class ConfigDataPatch
{
    private static bool EnabledTitsModCompatibility => ModSettingsDateRegister.TitsModCompatibilityDate.GetValue;
    
    private static bool EnabledGameSpeedExtensions => ModSettingsDateRegister.GameSpeedExtensionsDate.GetValue;

    private static bool EnabledDisableSlaveEscape => ModSettingsDateRegister.DisableSlaveEscapeDate.GetValue;

    private static float PercentThatChangesToDrain => ModSettingsDateRegister.PercentThatChangesToDrainDate.GetValue;

    private static float SecondsOfDay => ModSettingsDateRegister.SecondsOfDayDate.GetValue;

    private static float RestTime => ModSettingsDateRegister.RestTimeDate.GetValue;

    private static float TimeBodyDecays => ModSettingsDateRegister.TimeBodyDecaysDate.GetValue;

    private static int StartGold => ModSettingsDateRegister.StartGoldDate.GetValue;

    private static float TimeToDieFromVenerealDisease => ModSettingsDateRegister.TimeToDieFromVenerealDiseaseDate.GetValue;

    private static int CostOfDisposingCorpse => ModSettingsDateRegister.CostOfDisposingCorpseDate.GetValue;

    private static int CostOfDisposingInfertileMonster => ModSettingsDateRegister.CostOfDisposingInfertileMonsterDate.GetValue;

    private static float PixyMoveDurationMultiplier => ModSettingsDateRegister.PixyMoveDurationMultiplierDate.GetValue;

    private static int LoanPeriod => ModSettingsDateRegister.LoanPeriodDate.GetValue;

    private static int SoulOfTentacleEgg => ModSettingsDateRegister.SoulOfTentacleEggDate.GetValue;

    private static int SoulForTentacleRoom => ModSettingsDateRegister.SoulForTentacleRoomDate.GetValue;

    private static int EggForTentacleRoom => ModSettingsDateRegister.EggForTentacleRoomDate.GetValue;

    private static int MaxSoul => ModSettingsDateRegister.MaxSoulDate.GetValue;

    private static int PrivateEstateCost => ModSettingsDateRegister.PrivateEstateCostDate.GetValue;

    [HarmonyPatch(nameof(ConfigData.GameSpeedArray), MethodType.Getter)]
    [HarmonyPostfix]
    public static void GameSpeedArrayPostfix(ref float[] __result)
    {
        if (!EnabledGameSpeedExtensions) return;
        __result = [1f, 1.5f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f];
    }

    [HarmonyPatch(nameof(ConfigData.ProbabilityOfEscapingArray), MethodType.Getter)]
    [HarmonyPostfix]
    public static void ProbabilityOfEscapingArrayPostfix(ref float[] __result)
    {
        if (!EnabledDisableSlaveEscape) return;
        __result = [0, 0, 0, 0, 0, 0];
    }

    [HarmonyPatch(nameof(ConfigData.PercentThatChangesToDrain), MethodType.Getter)]
    [HarmonyPostfix]
    public static void PercentThatChangesToDrainPostfix(ref float __result)
    {
        __result = PercentThatChangesToDrain;
    }

    // To solve Inlined Methods problem.
    [HarmonyPatch(nameof(ConfigData.SecondsOfDay), MethodType.Getter)]
    [HarmonyPrefix]
    public static void SecondsOfDayPrefix(ref float ___m_SecondsOfDay)
    {
        if (EnabledTitsModCompatibility && ___m_SecondsOfDay != ModEntry.TitsModSecondsOfDay) 
        {
            ___m_SecondsOfDay = ModEntry.TitsModSecondsOfDay;
            return; 
        }
        if (___m_SecondsOfDay != SecondsOfDay) ___m_SecondsOfDay = SecondsOfDay;
    }

    //[HarmonyPatch(nameof(ConfigData.SecondsOfDay), MethodType.Getter)]
    //[HarmonyPostfix]
    //public static void SecondsOfDayPostfix(ref float __result)
    //{
    //    if (EnabledTitsModCompatibility) return;
    //    __result = SecondsOfDay;
    //}

    [HarmonyPatch(nameof(ConfigData.RestTime), MethodType.Getter)]
    [HarmonyPostfix]
    public static void RestTimePostfix(ref float __result)
    {
        __result = RestTime;
    }

    [HarmonyPatch(nameof(ConfigData.TimeBodyDecays), MethodType.Getter)]
    [HarmonyPostfix]
    public static void TimeBodyDecaysPostfix(ref float __result)
    {
        if (EnabledTitsModCompatibility) return;
        __result = TimeBodyDecays;
    }

    [HarmonyPatch(nameof(ConfigData.StartGold), MethodType.Getter)]
    [HarmonyPostfix]
    public static void StartGoldPostfix(ref int __result)
    {
        __result = StartGold;
    }

    [HarmonyPatch(nameof(ConfigData.TimeToDieFromVenerealDisease), MethodType.Getter)]
    [HarmonyPostfix]
    public static void TimeToDieFromVenerealDiseasePostfix(ref float __result)
    {
        if (EnabledTitsModCompatibility) return;
        __result = TimeToDieFromVenerealDisease;
    }
    [HarmonyPatch(nameof(ConfigData.TimeToBeInfertileFromVenerealDisease), MethodType.Getter)]
    [HarmonyPostfix]
    public static void TimeToBeInfertileFromVenerealDiseasePostfix(ref float __result)
    {
        if (EnabledTitsModCompatibility) return;
        __result = TimeToDieFromVenerealDisease;
    }

    [HarmonyPatch(nameof(ConfigData.CostOfDisposingCorpse), MethodType.Getter)]
    [HarmonyPostfix]
    public static void CostOfDisposingCorpsePostfix(ref int __result)
    {
        if (EnabledTitsModCompatibility) return;
        __result = -CostOfDisposingCorpse;
    }

    [HarmonyPatch(nameof(ConfigData.CostOfDisposingInfertileMonster), MethodType.Getter)]
    [HarmonyPostfix]
    public static void CostOfDisposingInfertileMonsterPostfix(ref int __result)
    {
        if (EnabledTitsModCompatibility) return;
        __result = -CostOfDisposingInfertileMonster;
    }

    [HarmonyPatch(nameof(ConfigData.PixyMoveSpeed), MethodType.Getter)]
    [HarmonyPostfix]
    public static void PixyMoveSpeedPostfix(ref float __result)
    {
        if (EnabledTitsModCompatibility) return;
        __result = PixyMoveDurationMultiplier;
    }

    [HarmonyPatch(nameof(ConfigData.LoanPeriod), MethodType.Getter)]
    [HarmonyPostfix]
    public static void LoanPeriodPostfix(ref int __result)
    {
        __result = LoanPeriod;
    }

    [HarmonyPatch(nameof(ConfigData.SoulOfTentacleEgg), MethodType.Getter)]
    [HarmonyPostfix]
    public static void SoulOfTentacleEggPostfix(ref int __result)
    {
        __result = SoulOfTentacleEgg;
    }

    [HarmonyPatch(nameof(ConfigData.SoulForTentacleRoom), MethodType.Getter)]
    [HarmonyPostfix]
    public static void SoulForTentacleRoomPostfix(ref int __result)
    {
        __result = SoulForTentacleRoom;
    }

    [HarmonyPatch(nameof(ConfigData.EggForTentacleRoom), MethodType.Getter)]
    [HarmonyPostfix]
    public static void EggForTentacleRoomPostfix(ref int __result)
    {
        __result = EggForTentacleRoom;
    }

    [HarmonyPatch(nameof(ConfigData.MaxSoul), MethodType.Getter)]
    [HarmonyPostfix]
    public static void MaxSoulPostfix(ref int __result)
    {
        __result = MaxSoul;
    }

    [HarmonyPatch(nameof(ConfigData.PrivateEstateCost), MethodType.Getter)]
    [HarmonyPostfix]
    public static void PrivateEstateCostPostfix(ref int __result)
    {
        __result = PrivateEstateCost;
    }
}