using HarmonyLib;
using MBMScripts;
using System;

namespace PracticalFunction.Accessors;

public static class ConfigDataAccessor
{
    public class Setter<T>
    {
        public Action<ConfigData, T> Set = null!;
    }

    public static readonly Setter<float[]> GameSpeedArray = new();
    public static readonly Setter<float> PercentThatChangesToDrain = new();
    public static readonly Setter<float> SecondsOfDay = new();
    public static readonly Setter<float> RestTime = new();
    public static readonly Setter<float> TimeBodyDecays = new();
    public static readonly Setter<int> StartGold = new();
    public static readonly Setter<float> TimeToDieFromVenerealDisease = new();
    public static readonly Setter<float> TimeToBeInfertileFromVenerealDisease = new();
    public static readonly Setter<float[]> ProbabilityOfEscapingArray = new();
    public static readonly Setter<int> CostOfDisposingCorpse = new();
    public static readonly Setter<int> CostOfDisposingInfertileMonster = new();
    public static readonly Setter<float> PixyMoveSpeed = new();
    public static readonly Setter<int> LoanPeriod = new();
    public static readonly Setter<int> SoulOfTentacleEgg = new();
    public static readonly Setter<int> SoulForTentacleRoom = new();
    public static readonly Setter<int> EggForTentacleRoom = new();
    public static readonly Setter<int> MaxSoul = new();
    public static readonly Setter<int> PrivateEstateCost = new();

    static ConfigDataAccessor()
    {
        BindField(GameSpeedArray, "m_GameSpeedArray");
        BindField(PercentThatChangesToDrain, "m_PercentThatChangesToDrain");
        BindField(SecondsOfDay, "m_SecondsOfDay");
        BindField(RestTime, "m_RestTime");
        BindField(TimeBodyDecays, "m_TimeBodyDecays");
        BindField(StartGold, "m_StartGold");
        BindField(TimeToDieFromVenerealDisease, "m_TimeToDieFromVenerealDisease");
        BindField(TimeToBeInfertileFromVenerealDisease, "m_TimeToBeInfertileFromVenerealDisease");
        BindField(ProbabilityOfEscapingArray, "m_ProbabilityOfEscapingArray");
        BindField(CostOfDisposingCorpse, "m_CostOfDisposingCorpse");
        BindField(CostOfDisposingInfertileMonster, "m_CostOfDisposingInfertileMonster");
        BindField(PixyMoveSpeed, "m_PixyMoveSpeed");
        BindField(LoanPeriod, "m_LoanPeriod");
        BindField(SoulOfTentacleEgg, "m_SoulOfTentacleEgg");
        BindField(SoulForTentacleRoom, "m_SoulForTentacleRoom");
        BindField(EggForTentacleRoom, "m_EggForTentacleRoom");
        BindField(MaxSoul, "m_MaxSoul");
        BindField(PrivateEstateCost, "m_PrivateEstateCost");
    }

    private static void BindField<T>(Setter<T> accessor, string fieldName)
    {
        var type = typeof(ConfigData);
        var field = AccessTools.Field(type, fieldName);
        if (field != null)
        {
            accessor.Set = (config, value) => field.SetValue(config, value);
        }
        else
        {
            UnityEngine.Debug.LogError($"Field {fieldName} not found in ConfigData");
        }
    }
}