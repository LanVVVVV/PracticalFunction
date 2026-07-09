using MBM.ModLoader.Settings;
using MBMScripts;
using PracticalFunction.Accessors;
using PracticalFunction.ModConfig;

namespace PracticalFunction.Features;

public static class ConfigDataUpdater
{
    public static void ApplyAll()
    {
        UpdateGameSpeedArray(ModSettingsDataRegister.GameSpeedExtensionsData);
        UpdateProbabilityOfEscapingArray(ModSettingsDataRegister.DisableSlaveEscapeData);
        
        UpdateSecondsOfDay(ModSettingsDataRegister.SecondsOfDayData);
        UpdateTimeBodyDecays(ModSettingsDataRegister.TimeBodyDecaysData);
        UpdateTimeToDieFromVenerealDisease(ModSettingsDataRegister.TimeToDieFromVenerealDiseaseData);
        UpdateTimeToBeInfertileFromVenerealDisease(ModSettingsDataRegister.TimeToDieFromVenerealDiseaseData);
        UpdateCostOfDisposingCorpse(ModSettingsDataRegister.CostOfDisposingCorpseData);
        UpdateCostOfDisposingInfertileMonster(ModSettingsDataRegister.CostOfDisposingInfertileMonsterData);
        UpdatePixyMoveSpeed(ModSettingsDataRegister.PixyMoveDurationMultiplierData);

        UpdatePercentThatChangesToDrain(ModSettingsDataRegister.PercentThatChangesToDrainData);
        UpdateRestTime(ModSettingsDataRegister.RestTimeData);
        UpdateStartGold(ModSettingsDataRegister.StartGoldData);
        UpdateLoanPeriod(ModSettingsDataRegister.LoanPeriodData);
        UpdateSoulOfTentacleEgg(ModSettingsDataRegister.SoulOfTentacleEggData);
        UpdateSoulForTentacleRoom(ModSettingsDataRegister.SoulForTentacleRoomData);
        UpdateEggForTentacleRoom(ModSettingsDataRegister.EggForTentacleRoomData);
        UpdateMaxSoul(ModSettingsDataRegister.MaxSoulData);
        UpdatePrivateEstateCost(ModSettingsDataRegister.PrivateEstateCostData);

        ModEntry.Log("All ConfigData Modify initialized");
    }

    public static void UpdateOfTitsModCompatibility(ModSettingsDataBool titsModCompatibilityData)
    {
        UpdateSecondsOfDay(ModSettingsDataRegister.SecondsOfDayData);
        UpdateTimeBodyDecays(ModSettingsDataRegister.TimeBodyDecaysData);
        UpdateTimeToDieFromVenerealDisease(ModSettingsDataRegister.TimeToDieFromVenerealDiseaseData);
        UpdateTimeToBeInfertileFromVenerealDisease(ModSettingsDataRegister.TimeToDieFromVenerealDiseaseData);
        UpdateCostOfDisposingCorpse(ModSettingsDataRegister.CostOfDisposingCorpseData);
        UpdateCostOfDisposingInfertileMonster(ModSettingsDataRegister.CostOfDisposingInfertileMonsterData);
        UpdatePixyMoveSpeed(ModSettingsDataRegister.PixyMoveDurationMultiplierData);

        ModEntry.Log("Data of Tits Mod Compatibility Updated");
    }


    #region Array

    private static readonly float[] VanillaGameSpeedArray = { 1f, 1.5f, 2f, 3f, 4f, 5f };
    private static readonly float[] ExtendedGameSpeedArray = { 1f, 1.5f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f };
    private static float[]? ResourcesGameSpeedArray;

    public static void UpdateGameSpeedArray(ModSettingsDataDropdown gameSpeedExtensionsData)
    {
        ResourcesGameSpeedArray ??= GameManager.ConfigData.GameSpeedArray;

        ConfigDataAccessor.GameSpeedArray.Set(GameManager.ConfigData,
            gameSpeedExtensionsData.Index switch
            {
                0 => VanillaGameSpeedArray,
                1 => ExtendedGameSpeedArray,
                2 => ResourcesGameSpeedArray,
                _ => ExtendedGameSpeedArray
            }
            );
    }

    private static readonly float[] DefaultProbabilityOfEscapingArray = { 75f, 50f, 25f, 15f, 5f, 0f };
    private static readonly float[] DisabledProbabilityOfEscapingArray = { 0f, 0f, 0f, 0f, 0f, 0f };
    public static void UpdateProbabilityOfEscapingArray(ModSettingsDataBool disableSlaveEscapeData)
    {
        ConfigDataAccessor.ProbabilityOfEscapingArray.Set(GameManager.ConfigData,
            disableSlaveEscapeData.GetValue ? DisabledProbabilityOfEscapingArray : DefaultProbabilityOfEscapingArray);
    }
    #endregion

    #region TitsModCompatibility
    private static bool EnabledTitsModCompatibility => 
        ModSettingsDataRegister.TitsModCompatibilityData.GetValue &&
        !ModSettings.IsHidden(ModEntry.ModName, ModSettingsDataRegister.TitsModCompatibilityData.Name);

    public static void UpdateSecondsOfDay(ModSettingsDataFloat secondsOfDayData)
    {
        ConfigDataAccessor.SecondsOfDay.Set(GameManager.ConfigData,
            EnabledTitsModCompatibility ? TitsModConfigData.TitsModSecondsOfDay : secondsOfDayData.GetValue);
    }

    public static void UpdateTimeBodyDecays(ModSettingsDataFloat timeBodyDecaysData)
    {
        ConfigDataAccessor.TimeBodyDecays.Set(GameManager.ConfigData,
            EnabledTitsModCompatibility ? TitsModConfigData.TitsModTimeBodyDecays : timeBodyDecaysData.GetValue);
    }

    public static void UpdateTimeToDieFromVenerealDisease(ModSettingsDataFloat timeToDieData)
    {
        ConfigDataAccessor.TimeToDieFromVenerealDisease.Set(GameManager.ConfigData,
            EnabledTitsModCompatibility ? TitsModConfigData.TitsModTimeToDieFromVenerealDisease : timeToDieData.GetValue);
    }

    public static void UpdateTimeToBeInfertileFromVenerealDisease(ModSettingsDataFloat timeToBeInfertileData)
    {
        ConfigDataAccessor.TimeToBeInfertileFromVenerealDisease.Set(GameManager.ConfigData,
            EnabledTitsModCompatibility ? TitsModConfigData.TitsModTimeToBeInfertileFromVenerealDisease : timeToBeInfertileData.GetValue);
    }

    public static void UpdateCostOfDisposingCorpse(ModSettingsDataInt costCorpseData)
    {
        ConfigDataAccessor.CostOfDisposingCorpse.Set(GameManager.ConfigData,
            EnabledTitsModCompatibility ? TitsModConfigData.TitsModCostOfDisposingCorpse : -costCorpseData.GetValue);
    }

    public static void UpdateCostOfDisposingInfertileMonster(ModSettingsDataInt costInfertileData)
    {
        ConfigDataAccessor.CostOfDisposingInfertileMonster.Set(GameManager.ConfigData,
            EnabledTitsModCompatibility ? TitsModConfigData.TitsModCostOfDisposingInfertileMonster : -costInfertileData.GetValue);
    }

    public static void UpdatePixyMoveSpeed(ModSettingsDataFloat pixyMoveSpeedData)
    {
        ConfigDataAccessor.PixyMoveSpeed.Set(GameManager.ConfigData,
            EnabledTitsModCompatibility ? TitsModConfigData.TitsModPixyMoveSpeed : pixyMoveSpeedData.GetValue);
    }
    #endregion

    public static void UpdatePercentThatChangesToDrain(ModSettingsDataFloat percentThatChangesToDrainData)
    {
        ConfigDataAccessor.PercentThatChangesToDrain.Set(GameManager.ConfigData,
            percentThatChangesToDrainData.GetValue);
    }

    public static void UpdateRestTime(ModSettingsDataFloat restTimeData)
    {
        ConfigDataAccessor.RestTime.Set(GameManager.ConfigData,
            restTimeData.GetValue);
    }

    public static void UpdateStartGold(ModSettingsDataInt startGoldData)
    {
        ConfigDataAccessor.StartGold.Set(GameManager.ConfigData,
            startGoldData.GetValue);
    }

    public static void UpdateLoanPeriod(ModSettingsDataInt loanPeriodData)
    {
        ConfigDataAccessor.LoanPeriod.Set(GameManager.ConfigData,
            loanPeriodData.GetValue);
    }

    public static void UpdateSoulOfTentacleEgg(ModSettingsDataInt soulEggData)
    {
        ConfigDataAccessor.SoulOfTentacleEgg.Set(GameManager.ConfigData,
            soulEggData.GetValue);
    }

    public static void UpdateSoulForTentacleRoom(ModSettingsDataInt soulRoomData)
    {
        ConfigDataAccessor.SoulForTentacleRoom.Set(GameManager.ConfigData,
            soulRoomData.GetValue);
    }

    public static void UpdateEggForTentacleRoom(ModSettingsDataInt eggRoomData)
    {
        ConfigDataAccessor.EggForTentacleRoom.Set(GameManager.ConfigData,
            eggRoomData.GetValue);
    }

    public static void UpdateMaxSoul(ModSettingsDataInt maxSoulData)
    {
        ConfigDataAccessor.MaxSoul.Set(GameManager.ConfigData,
            maxSoulData.GetValue);
    }

    public static void UpdatePrivateEstateCost(ModSettingsDataInt privateEstateCostData)
    {
        ConfigDataAccessor.PrivateEstateCost.Set(GameManager.ConfigData,
            privateEstateCostData.GetValue);
    }
}