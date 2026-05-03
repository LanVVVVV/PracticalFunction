using MBM.ModLoader.Core;
using MBM.ModLoader.Mods;
using MBM.ModLoader.Settings;
using MBMScripts;
using PracticalFunction.ModConfig;
using PracticalFunction.Patches;
using PracticalFunction.Properties;
using System.Collections.Generic;
using UnityEngine;

namespace PracticalFunction;

public class ModEntry
{
    internal const string ModName = "PracticalFunction";

    internal static float TitsModSecondsOfDay {  get; } = 600;

    public static void Load()
    {
        ModSettingsRegister();
        ModSettingsInitialize();
        ModSettingsVisible();
        Localization.OnLanguageChanged += OnLanguageChanged;

        PracticalFunctionDeployer.Initialize();

        Log("PracticalFunction Mod loaded!");
    }
    internal static void Log(string msg) => Debug.Log($"[PF] {msg}");

    private static void ModSettingsRegister()
    {
        ModSettingsDateRegister.TitsModCompatibilityDate.Register();

        ModSettingsDateRegister.DragDuringPauseDate.Register("Base");

        ModSettingsDateRegister.GameSpeedExtensionsDate.Register("Base");

        ModSettingsDateRegister.OneClickSellDate.Register("Base");


        ModSettingsDateRegister.DisableSlaveEscapeDate.Register("Advance");

        ModSettingsDateRegister.DismantlingLimitDate.Register("Advance");


        ModSettingsDateRegister.StartGoldDate.Register("Cost");

        ModSettingsDateRegister.PrivateEstateCostDate.Register("Cost");

        ModSettingsDateRegister.CostOfDisposingCorpseDate.Register("Cost", "TitsModCompatibility");

        ModSettingsDateRegister.CostOfDisposingInfertileMonsterDate.Register("Cost", "TitsModCompatibility");


        ModSettingsDateRegister.PercentThatChangesToDrainDate.Register("Multiplier");

        ModSettingsDateRegister.PixyMoveDurationMultiplierDate.Register("Multiplier", "TitsModCompatibility");


        ModSettingsDateRegister.SecondsOfDayDate.Register("Time", "TitsModCompatibility");

        ModSettingsDateRegister.RestTimeDate.Register("Time");

        ModSettingsDateRegister.TimeBodyDecaysDate.Register("Time", "TitsModCompatibility");

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

    private static void ModSettingsVisible()
    {
        ModSettings.SetVisibleWhen(ModName, ModSettingsDateRegister.TitsModCompatibilityDate.Name,
            new Dictionary<string, string[]>
            {
                    { "False", new[] { "TitsModCompatibility" } }
            });
    }

    private static void OnLanguageChanged(string langCode)
    {
        Strings.Culture = Localization.CurrentCulture;

        foreach (ModSettingsDate modSetting in ModSettingsDateRegister.All)
        {
            modSetting.OnLanguageChanged();
        }

        SeqLocalizationPatch.SetDefaultPrivateEstateCost();

        Log($"language changed: {langCode}");
    }
}