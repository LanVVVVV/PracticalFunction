using System.Collections.Generic;

namespace PracticalFunction.ModConfig;

public sealed class ModSettingsDateRegister
{
    public static List<ModSettingsDate> All = [];

    public static readonly ModSettingsDateBool DragDuringPauseDate = new ModSettingsDateBool(
    "Drag During Pause",
    true,
    "Config_DragDuringPause"
);

    public static readonly ModSettingsDateBool GameSpeedExtensionsDate = new ModSettingsDateBool(
        "Game Speed Extensions",
        true,
        "Config_GameSpeedExtensions"
    );

    public static readonly ModSettingsDateBool DisableSlaveEscapeDate = new ModSettingsDateBool(
        "Disable Slave Escape",
        false,
        "Config_DisableSlaveEscape"
    );

    public static readonly ModSettingsDateBool OneClickSellDate = new(
        "One-Click Sell",
        true,
        "Config_OneClickSell"
    );

    public static readonly ModSettingsDateFloat PercentThatChangesToDrainDate = new ModSettingsDateFloat(
        "Percent That Changes To Drain",
        0.3f,
        "Config_PercentThatChangesToDrain"
    );

    public static readonly ModSettingsDateFloat SecondsOfDayDate = new ModSettingsDateFloat(
        "Game Day Length",
        300f,
        "Config_Gamedaylength"
    );

    // Rest Time default value is 20(+2)
    public static readonly ModSettingsDateFloat RestTimeDate = new ModSettingsDateFloat(
        "Rest Time",
        20f,
        "Config_RestTime"
    );

    public static readonly ModSettingsDateFloat TimeBodyDecaysDate = new ModSettingsDateFloat(
        "Body Decays Time",
        180f,
        "Config_BodyDecaysTime"
    );

    public static readonly ModSettingsDateFloat TimeToDieFromVenerealDiseaseDate = new ModSettingsDateFloat(
        "Time To Die/Infertile From Venereal Disease",
        300f,
        "Config_TimeToDieFromVenerealDisease"
    );

    public static readonly ModSettingsDateFloat PixyMoveDurationMultiplierDate = new ModSettingsDateFloat(
        "Pixy Move Duration Multiplier",
        1f,
        "Config_PixyMoveDurationMultiplier"
    );

    public static readonly ModSettingsDateInt StartGoldDate = new ModSettingsDateInt(
        "Start Gold",
        1000,
        "Config_StartGold"
    );

    public static readonly ModSettingsDateInt CostOfDisposingCorpseDate = new ModSettingsDateInt(
        "Cost Of Disposing Corpse",
        200,
        "Config_CostOfDisposingCorpse"
    );

    public static readonly ModSettingsDateInt CostOfDisposingInfertileMonsterDate = new ModSettingsDateInt(
        "Cost Of Disposing Infertile Monster",
        200,
        "Config_CostOfDisposingInfertileMonster"
    );

    public static readonly ModSettingsDateInt LoanPeriodDate = new ModSettingsDateInt(
        "Loan Period",
        5,
        "Config_LoanPeriod"
    );

    // UnitPatch
    public static readonly ModSettingsDateInt PriceTentacleEggDate = new ModSettingsDateInt(
        "Price Of Tentacle Egg",
        5000,
        "Config_PriceOfTentacleEgg"
    );

    public static readonly ModSettingsDateInt SoulOfTentacleEggDate = new ModSettingsDateInt(
        "Essence Of Tentacle Egg",
        50,
        "Config_EssenceOfTentacleEgg"
    );

    public static readonly ModSettingsDateInt SoulForTentacleRoomDate = new ModSettingsDateInt(
        "Essence For Tentacle Room",
        100,
        "Config_EssenceForTentacleRoom"
    );

    public static readonly ModSettingsDateInt EggForTentacleRoomDate = new ModSettingsDateInt(
        "Egg For Tentacle Room",
        3,
        "Config_EggForTentacleRoom"
    );

    public static readonly ModSettingsDateInt MaxSoulDate = new ModSettingsDateInt(
        "Max Essence",
        666,
        "Config_MaxEssence"
    );

    public static readonly ModSettingsDateInt PrivateEstateCostDate = new ModSettingsDateInt(
        "Private Estate Cost",
        50000,
        "Config_PrivateEstateCost"
    );

    // Dismantling Limit default value is 15(-1)
    public static readonly ModSettingsDateInt DismantlingLimitDate = new ModSettingsDateInt(
        "Dismantling Limit",
        15,
        "Config_DismantlingLimit"
    );
}
