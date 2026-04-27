using MBM.ModLoader.Core;
using PracticalFunction.ModConfig;
using PracticalFunction.Properties;
using UnityEngine;

namespace PracticalFunction;

public class ModEntry
{
    internal const string ModName = "PracticalFunction";
    public static void Load()
    {
        ModSettingsRegister();
        ModSettingsInitialize();
        Localization.OnLanguageChanged += OnLanguageChanged;

        PracticalFunctionDeployer.Initialize();

        Log("PracticalFunction Mod loaded!");
    }
    internal static void Log(string msg) => Debug.Log($"[PF] {msg}");

    private static void ModSettingsRegister()
    {
        ModSettingsDateRegister.DragDuringPauseDate.Register("Base");

        ModSettingsDateRegister.GameSpeedExtensionsDate.Register("Base");

        ModSettingsDateRegister.OneClickSellDate.Register("Base");


        ModSettingsDateRegister.DisableSlaveEscapeDate.Register("Advance");

        ModSettingsDateRegister.DismantlingLimitDate.Register("Advance");
        

        ModSettingsDateRegister.StartGoldDate.Register("Cost");

        ModSettingsDateRegister.PrivateEstateCostDate.Register("Cost");

        ModSettingsDateRegister.CostOfDisposingCorpseDate.Register("Cost");

        ModSettingsDateRegister.CostOfDisposingInfertileMonsterDate.Register("Cost");


        ModSettingsDateRegister.PercentThatChangesToDrainDate.Register("Multiplier");

        ModSettingsDateRegister.PixyMoveDurationMultiplierDate.Register("Multiplier");


        ModSettingsDateRegister.SecondsOfDayDate.Register("Time");

        ModSettingsDateRegister.RestTimeDate.Register("Time");

        ModSettingsDateRegister.TimeBodyDecaysDate.Register("Time");

        ModSettingsDateRegister.TimeToDieFromVenerealDiseaseDate.Register("Time");

        ModSettingsDateRegister.LoanPeriodDate.Register("Time");


        ModSettingsDateRegister.MaxSoulDate.Register("Tentacle");

        ModSettingsDateRegister.PriceTentacleEggDate.Register("Tentacle");

        ModSettingsDateRegister.SoulOfTentacleEggDate.Register("Tentacle");

        ModSettingsDateRegister.SoulForTentacleRoomDate.Register("Tentacle");

        ModSettingsDateRegister.EggForTentacleRoomDate.Register("Tentacle");
    }

    private static void ModSettingsInitialize()
    {
        foreach (ModSettingsDate modSetting in ModSettingsDateRegister.All)
        {
            modSetting.Initialize();
            modSetting.ModSettingsOnChanged();
        }
    }

    private static void OnLanguageChanged(string langCode)
    {
        Strings.Culture = Localization.CurrentCulture;

        foreach (ModSettingsDate modSetting in ModSettingsDateRegister.All)
        {
            modSetting.OnLanguageChanged();
        }

        Log($"language changed: {langCode}");
    }
}