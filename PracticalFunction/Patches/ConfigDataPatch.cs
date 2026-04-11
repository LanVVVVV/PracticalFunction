using HarmonyLib;
using MBMScripts;

namespace PracticalFunction.Patches;

[HarmonyPatch(typeof(ConfigData))]
internal class ConfigDataPatch
{
    internal static bool enabledGameSpeedExtensions;

    internal static bool enabledDisableSlaveEscape;

    internal static float percentThatChangesToDrain;

    internal static float secondsOfDay;

    internal static float restTime;

    internal static float timeBodyDecays;

    internal static int startGold;

    internal static float timeToDieFromVenerealDisease;

    internal static int costOfDisposingCorpse;

    internal static int costOfDisposingInfertileMonster;

    internal static float pixyMoveDurationMultiplier;

    internal static int loanPeriod;

    internal static int soulOfTentacleEgg;

    internal static int soulForTentacleRoom;

    internal static int eggForTentacleRoom;

    internal static int maxSoul;

    internal static int privateEstateCost;

    [HarmonyPatch(nameof(ConfigData.GameSpeedArray), MethodType.Getter)]
    [HarmonyPostfix]
    public static void GameSpeedArrayPostfix(ref float[] __result)
    {
        if (!enabledGameSpeedExtensions) return;
        __result = [1f, 1.5f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f];
    }

    [HarmonyPatch(nameof(ConfigData.ProbabilityOfEscapingArray), MethodType.Getter)]
    [HarmonyPostfix]
    public static void ProbabilityOfEscapingArrayPostfix(ref float[] __result)
    {
        if (!enabledDisableSlaveEscape) return;
        __result = [0, 0, 0, 0, 0, 0];
    }

    [HarmonyPatch(nameof(ConfigData.PercentThatChangesToDrain), MethodType.Getter)]
    [HarmonyPostfix]
    public static void PercentThatChangesToDrainPostfix(ref float __result)
    {
        __result = percentThatChangesToDrain;
    }

    [HarmonyPatch(nameof(ConfigData.SecondsOfDay), MethodType.Getter)]
    [HarmonyPostfix]
    public static void SecondsOfDayPostfix(ref float __result)
    {
        __result = secondsOfDay;
    }

    [HarmonyPatch(nameof(ConfigData.RestTime), MethodType.Getter)]
    [HarmonyPostfix]
    public static void RestTimePostfix(ref float __result)
    {
        __result = restTime;
    }

    [HarmonyPatch(nameof(ConfigData.TimeBodyDecays), MethodType.Getter)]
    [HarmonyPostfix]
    public static void TimeBodyDecaysPostfix(ref float __result)
    {
        __result = timeBodyDecays;
    }

    [HarmonyPatch(nameof(ConfigData.StartGold), MethodType.Getter)]
    [HarmonyPostfix]
    public static void StartGoldPostfix(ref int __result)
    {
        __result = startGold;
    }

    [HarmonyPatch(nameof(ConfigData.TimeToDieFromVenerealDisease), MethodType.Getter)]
    [HarmonyPostfix]
    public static void TimeToDieFromVenerealDiseasePostfix(ref float __result)
    {
        __result = timeToDieFromVenerealDisease;
    }

    [HarmonyPatch(nameof(ConfigData.CostOfDisposingCorpse), MethodType.Getter)]
    [HarmonyPostfix]
    public static void CostOfDisposingCorpsePostfix(ref int __result)
    {
        __result = -costOfDisposingCorpse;
    }

    [HarmonyPatch(nameof(ConfigData.CostOfDisposingInfertileMonster), MethodType.Getter)]
    [HarmonyPostfix]
    public static void CostOfDisposingInfertileMonsterPostfix(ref int __result)
    {
        __result = -costOfDisposingInfertileMonster;
    }

    [HarmonyPatch(nameof(ConfigData.PixyMoveSpeed), MethodType.Getter)]
    [HarmonyPostfix]
    public static void PixyMoveSpeedPostfix(ref float __result)
    {
        __result = pixyMoveDurationMultiplier;
    }

    [HarmonyPatch(nameof(ConfigData.LoanPeriod), MethodType.Getter)]
    [HarmonyPostfix]
    public static void LoanPeriodPostfix(ref int __result)
    {
        __result = loanPeriod;
    }

    [HarmonyPatch(nameof(ConfigData.SoulOfTentacleEgg), MethodType.Getter)]
    [HarmonyPostfix]
    public static void SoulOfTentacleEggPostfix(ref int __result)
    {
        __result = soulOfTentacleEgg;
    }

    [HarmonyPatch(nameof(ConfigData.SoulForTentacleRoom), MethodType.Getter)]
    [HarmonyPostfix]
    public static void SoulForTentacleRoomPostfix(ref int __result)
    {
        __result = soulForTentacleRoom;
    }

    [HarmonyPatch(nameof(ConfigData.EggForTentacleRoom), MethodType.Getter)]
    [HarmonyPostfix]
    public static void EggForTentacleRoomPostfix(ref int __result)
    {
        __result = eggForTentacleRoom;
    }

    [HarmonyPatch(nameof(ConfigData.MaxSoul), MethodType.Getter)]
    [HarmonyPostfix]
    public static void MaxSoulPostfix(ref int __result)
    {
        __result = maxSoul;
    }

    [HarmonyPatch(nameof(ConfigData.PrivateEstateCost), MethodType.Getter)]
    [HarmonyPostfix]
    public static void PrivateEstateCostPostfix(ref int __result)
    {
        __result = privateEstateCost;
    }
}