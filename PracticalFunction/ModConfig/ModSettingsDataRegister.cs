using System.Collections.Generic;

namespace PracticalFunction.ModConfig;

public sealed class ModSettingsDataRegister
{
    public static List<ModSettingsData> All = [];

    public static readonly ModSettingsDataBool DragDuringPauseData = new (
        "Drag During Pause",
        true,
        "Config_DragDuringPause"
);

    public static readonly ModSettingsDataBool GameSpeedExtensionsData = new (
        "Game Speed Extensions",
        true,
        "Config_GameSpeedExtensions"
    );

    public static readonly ModSettingsDataBool DisableSlaveEscapeData = new (
        "Disable Slave Escape",
        false,
        "Config_DisableSlaveEscape"
    );

    public static readonly ModSettingsDataBool TitsModCompatibilityData = new (
        "Tits Mod Compatibility",
        false,
        "Config_TitsModCompatibility"
    );

    public static readonly ModSettingsDataBool OneClickSellData = new(
        "One-Click Sell",
        true,
        "Config_OneClickSell"
    );

    public static readonly ModSettingsDataFloat PercentThatChangesToDrainData = new (
        "Percent That Changes To Drain",
        0.3f,
        "Config_PercentThatChangesToDrain"
    );

    public static readonly ModSettingsDataFloat SecondsOfDayData = new (
        "Game Day Length",
        300f,
        "Config_Gamedaylength"
    );

    // Rest Time default value is 20(+2)
    public static readonly ModSettingsDataFloat RestTimeData = new (
        "Rest Time",
        20f,
        "Config_RestTime"
    );

    public static readonly ModSettingsDataFloat TimeBodyDecaysData = new (
        "Body Decays Time",
        180f,
        "Config_BodyDecaysTime"
    );

    public static readonly ModSettingsDataFloat TimeToDieFromVenerealDiseaseData = new (
        "Time To Die/Infertile From Venereal Disease",
        300f,
        "Config_TimeToDieFromVenerealDisease"
    );

    public static readonly ModSettingsDataFloat PixyMoveDurationMultiplierData = new (
        "Pixy Move Duration Multiplier",
        1f,
        "Config_PixyMoveDurationMultiplier"
    );

    public static readonly ModSettingsDataInt StartGoldData = new (
        "Start Gold",
        1000,
        "Config_StartGold"
    );

    public static readonly ModSettingsDataInt CostOfDisposingCorpseData = new (
        "Cost Of Disposing Corpse",
        200,
        "Config_CostOfDisposingCorpse"
    );

    public static readonly ModSettingsDataInt CostOfDisposingInfertileMonsterData = new (
        "Cost Of Disposing Infertile Monster",
        200,
        "Config_CostOfDisposingInfertileMonster"
    );

    public static readonly ModSettingsDataInt LoanPeriodData = new (
        "Loan Period",
        5,
        "Config_LoanPeriod"
    );

    // UnitPatch
    public static readonly ModSettingsDataInt PriceTentacleEggData = new (
        "Price Of Tentacle Egg",
        5000,
        "Config_PriceOfTentacleEgg"
    );

    public static readonly ModSettingsDataInt SoulOfTentacleEggData = new (
        "Essence Of Tentacle Egg",
        50,
        "Config_EssenceOfTentacleEgg"
    );

    public static readonly ModSettingsDataInt SoulForTentacleRoomData = new (
        "Essence For Tentacle Room",
        100,
        "Config_EssenceForTentacleRoom"
    );

    public static readonly ModSettingsDataInt EggForTentacleRoomData = new (
        "Egg For Tentacle Room",
        3,
        "Config_EggForTentacleRoom"
    );

    public static readonly ModSettingsDataInt MaxSoulData = new (
        "Max Essence",
        666,
        "Config_MaxEssence"
    );

    public static readonly ModSettingsDataInt PrivateEstateCostData = new (
        "Private Estate Cost",
        50000,
        "Config_PrivateEstateCost"
    );

    // Dismantling Limit default value is 15(-1)
    public static readonly ModSettingsDataInt DismantlingLimitData = new (
        "Dismantling Limit",
        15,
        "Config_DismantlingLimit"
    );
}
