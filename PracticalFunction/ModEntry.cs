using MBM.ModLoader.Core;
using MBM.ModLoader.Settings;
using PracticalFunction.Features;
using PracticalFunction.ModConfig;
using PracticalFunction.Patches;
using PracticalFunction.Properties;
using System.Collections.Generic;
using UnityEngine;

namespace PracticalFunction;

public class ModEntry
{
    internal const string ModName = "PracticalFunction";

    public static void Load()
    {
        ModSettingsRegister();
        ModSettingsInitialize();

        Loader.OnAllModsLoaded += ModSettingsVisible;

        GameManagerPatch.AfterDataInitialized += DataModifyInitialize;

        Localization.OnLanguageChanged += OnLanguageChanged;

        PracticalFunctionDeployer.Initialize();

        Log("PracticalFunction Mod loaded!");
    }

    private static void DataModifyInitialize()
    {
        ModSettingsDataRegisterEvents.RegisterEvents();

        ConfigDataUpdater.ApplyAll();
        EventDataUpdater.ApplyAll();
    }

    internal static void Log(string msg) => Debug.Log($"[PF] {msg}");

    internal static void LogError(string msg) => Debug.LogError($"[PF] {msg}");

    private static void ModSettingsRegister()
    {
        ModSettingsDataRegister.TitsModCompatibilityData.Register("TitsMod", "TitsMod");

        ModSettingsDataRegister.DragDuringPauseData.Register("Base");

        ModSettingsDataRegister.GameSpeedExtensionsData.Register("Base");

        ModSettingsDataRegister.OneClickSellData.Register("Base");


        ModSettingsDataRegister.DisableSlaveEscapeData.Register("Advance");

        ModSettingsDataRegister.DismantlingLimitData.Register("Advance");

        ModSettingsDataRegister.AllowDNAWithoutNiel.Register("Advance");


        ModSettingsDataRegister.StartGoldData.Register("Cost");

        ModSettingsDataRegister.PrivateEstateCostData.Register("Cost");

        ModSettingsDataRegister.CostOfDisposingCorpseData.Register("Cost", "TitsModCompatibility");

        ModSettingsDataRegister.CostOfDisposingInfertileMonsterData.Register("Cost", "TitsModCompatibility");


        ModSettingsDataRegister.PercentThatChangesToDrainData.Register("Multiplier");

        ModSettingsDataRegister.PixyMoveDurationMultiplierData.Register("Multiplier", "TitsModCompatibility");


        ModSettingsDataRegister.SecondsOfDayData.Register("Time", "TitsModCompatibility");

        ModSettingsDataRegister.RestTimeData.Register("Time");

        ModSettingsDataRegister.TimeBodyDecaysData.Register("Time", "TitsModCompatibility");

        ModSettingsDataRegister.TimeToDieFromVenerealDiseaseData.Register("Time", "TitsModCompatibility");

        ModSettingsDataRegister.LoanPeriodData.Register("Time");


        ModSettingsDataRegister.MaxSoulData.Register("Tentacle");

        ModSettingsDataRegister.PriceTentacleEggData.Register("Tentacle");

        ModSettingsDataRegister.SoulOfTentacleEggData.Register("Tentacle");

        ModSettingsDataRegister.SoulForTentacleRoomData.Register("Tentacle");

        ModSettingsDataRegister.EggForTentacleRoomData.Register("Tentacle");
    }

    private static void ModSettingsInitialize()
    {
        foreach (ModSettingsData modSetting in ModSettingsDataRegister.All)
        {
            modSetting.Initialize();
            modSetting.ModSettingsOnChanged();
        }
    }

    private static void OnLanguageChanged(string langCode)
    {
        Strings.Culture = Localization.CurrentCulture;

        foreach (ModSettingsData modSetting in ModSettingsDataRegister.All)
        {
            modSetting.OnLanguageChanged();
        }

        SeqLocalizationPatch.SetDefaultPrivateEstateCost();

        Log($"language changed: {langCode}");
    }

    private static void ModSettingsVisible()
    {
        if(Loader.IsModLoaded("TitsMod"))
        {
            ModSettings.SetVisibleWhen(ModName, ModSettingsDataRegister.TitsModCompatibilityData.Name,
            new Dictionary<string, string[]>
            {
                    { "False", new[] { "TitsModCompatibility" } }
            });
            return;
        }

        // Hidden
        ModSettings.Set(ModName, ModSettingsDataRegister.TitsModCompatibilityData.Name, false);
        ModSettings.SetVisibleWhen(ModName, ModSettingsDataRegister.TitsModCompatibilityData.Name,
            new Dictionary<string, string[]>
            {
                    { "True", new[] { "TitsMod" } }
            });
        Log("Hidden: Tits Mod Compatibility.");
    }
}