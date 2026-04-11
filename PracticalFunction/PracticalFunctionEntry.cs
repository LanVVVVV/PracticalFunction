using MBM.ModLoader.Core;
using MBM.ModLoader.Settings;
using PracticalFunction.Patches;
using PracticalFunction.Properties;
using UnityEngine;

namespace PracticalFunction;

public class PracticalFunctionEntry
{
    internal const string ModName = "PracticalFunction";
    public static void Load()
    {
        ModSettingsRegister();
        ModSettingsInitialize();
        ModSettingsOnChanged();
        Localization.OnLanguageChanged += OnLanguageChanged;

        Log("PracticalFunction Mod loaded!");
    }
    internal static void Log(string msg) => Debug.Log($"[PF] {msg}");

    private static void ModSettingsRegister()
    {
        ModSettings.RegisterBool(ModName, "Drag During Pause", true, Strings.Config_DragDuringPause, "Base");
        
        ModSettings.RegisterBool(ModName, "Game Speed Extensions", true, Strings.Config_GameSpeedExtensions, "Base");
        

        ModSettings.RegisterBool(ModName, "Disable Slave Escape", false, Strings.Config_DisableSlaveEscape, "Advance");

        // Dismantling Limit default value is 15(-1)
        ModSettings.RegisterInt(ModName, "Dismantling Limit", 15, Strings.Config_DismantlingLimit, "Advance");


        ModSettings.RegisterInt(ModName, "Start Gold", 1000, Strings.Config_StartGold, "Cost");

        ModSettings.RegisterInt(ModName, "Private Estate Cost", 50000, Strings.Config_PrivateEstateCost, "Cost");

        ModSettings.RegisterInt(ModName, "Cost Of Disposing Corpse", 200, Strings.Config_CostOfDisposingCorpse, "Cost");

        ModSettings.RegisterInt(ModName, "Cost Of Disposing Infertile Monster", 200, Strings.Config_CostOfDisposingInfertileMonster, "Cost");


        ModSettings.RegisterFloat(ModName, "Percent That Changes To Drain", 0.3f, Strings.Config_PercentThatChangesToDrain, "Multiplier");

        ModSettings.RegisterFloat(ModName, "Pixy Move Duration Multiplier", 1f, Strings.Config_PixyMoveDurationMultiplier, "Multiplier");


        ModSettings.RegisterFloat(ModName, "Game day length", 300f, Strings.Config_Gamedaylength, "Time");
        
        // Rest Time default value is 20(+2)
        ModSettings.RegisterFloat(ModName, "Rest Time", 20f, Strings.Config_RestTime, "Time");
        
        ModSettings.RegisterFloat(ModName, "Body Decays Time", 180f, Strings.Config_BodyDecaysTime, "Time");
        
        ModSettings.RegisterFloat(ModName, "Time To Die/Infertile From Venereal Disease", 300f, Strings.Config_TimeToDieFromVenerealDisease, "Time");
        
        ModSettings.RegisterInt(ModName, "Loan Period", 5, Strings.Config_LoanPeriod, "Time");


        ModSettings.RegisterInt(ModName, "Max Essence", 666, Strings.Config_MaxEssence, "Tentacle");

        // UnitPatch
        ModSettings.RegisterInt(ModName, "Price Of Tentacle Egg", 5000, Strings.Config_PriceOfTentacleEgg, "Tentacle");
        
        ModSettings.RegisterInt(ModName, "Essence Of Tentacle Egg", 50, Strings.Config_EssenceOfTentacleEgg, "Tentacle");
        
        ModSettings.RegisterInt(ModName, "Essence For Tentacle Room", 100, Strings.Config_EssenceForTentacleRoom, "Tentacle");
        
        ModSettings.RegisterInt(ModName, "Egg For Tentacle Room", 3, Strings.Config_EggForTentacleRoom, "Tentacle");
    }

    private static void ModSettingsInitialize()
    {
        InteractionDragPatch.enabledDragDuringPause = ModSettings.GetBool(ModName, "Drag During Pause");
        ConfigDataPatch.enabledGameSpeedExtensions = ModSettings.GetBool(ModName, "Game Speed Extensions");
        ConfigDataPatch.enabledDisableSlaveEscape = ModSettings.GetBool(ModName, "Disable Slave Escape");

        ConfigDataPatch.percentThatChangesToDrain = ModSettings.GetFloat(ModName, "Percent That Changes To Drain");
        ConfigDataPatch.secondsOfDay = ModSettings.GetFloat(ModName, "Game day length");
        ConfigDataPatch.restTime = ModSettings.GetFloat(ModName, "Rest Time");
        ConfigDataPatch.timeBodyDecays = ModSettings.GetFloat(ModName, "Body Decays Time");
        ConfigDataPatch.startGold = ModSettings.GetInt(ModName, "Start Gold");
        ConfigDataPatch.timeToDieFromVenerealDisease = ModSettings.GetFloat(ModName, "Time To Die/Infertile From Venereal Disease");
        ConfigDataPatch.costOfDisposingCorpse = ModSettings.GetInt(ModName, "Cost Of Disposing Corpse");
        ConfigDataPatch.costOfDisposingInfertileMonster = ModSettings.GetInt(ModName, "Cost Of Disposing Infertile Monster");
        ConfigDataPatch.pixyMoveDurationMultiplier = ModSettings.GetFloat(ModName, "Pixy Move Duration Multiplier");
        ConfigDataPatch.loanPeriod = ModSettings.GetInt(ModName, "Loan Period");
        UnitPatch.priceTentacleEgg = ModSettings.GetInt(ModName, "Price Of Tentacle Egg");
        ConfigDataPatch.soulOfTentacleEgg = ModSettings.GetInt(ModName, "Essence Of Tentacle Egg");
        ConfigDataPatch.soulForTentacleRoom = ModSettings.GetInt(ModName, "Essence For Tentacle Room");
        ConfigDataPatch.eggForTentacleRoom = ModSettings.GetInt(ModName, "Egg For Tentacle Room");
        ConfigDataPatch.maxSoul = ModSettings.GetInt(ModName, "Max Essence");
        ConfigDataPatch.privateEstateCost = ModSettings.GetInt(ModName, "Private Estate Cost");

        EPlayEventTypeExtensionsPatch.dismantlingLimit = ModSettings.GetInt(ModName, "Dismantling Limit");
    }

    private static void ModSettingsOnChanged()
    {
        ModSettings.OnChanged(ModName, "Drag During Pause", v =>
        {
            InteractionDragPatch.enabledDragDuringPause = (bool)v;
            Log($"Drag During Pause = {InteractionDragPatch.enabledDragDuringPause}");
        });
        ModSettings.OnChanged(ModName, "Game Speed Extensions", v =>
        {
            ConfigDataPatch.enabledGameSpeedExtensions = (bool)v;
            Log($"Game Speed Extensions = {ConfigDataPatch.enabledGameSpeedExtensions}");
        });
        ModSettings.OnChanged(ModName, "Disable Slave Escape", v =>
        {
            ConfigDataPatch.enabledDisableSlaveEscape = (bool)v;
            Log($"Disable Slave Escape = {ConfigDataPatch.enabledDisableSlaveEscape}");
        });

        ModSettings.OnChanged(ModName, "Percent That Changes To Drain", v =>
        {
            ConfigDataPatch.percentThatChangesToDrain = (float)v;
            Log($"Percent That Changes To Drain = {ConfigDataPatch.percentThatChangesToDrain}");
        });
        ModSettings.OnChanged(ModName, "Game day length", v =>
        {
            ConfigDataPatch.secondsOfDay = (float)v;
            Log($"Game day length = {ConfigDataPatch.secondsOfDay}");
        });
        ModSettings.OnChanged(ModName, "Rest Time", v =>
        {
            ConfigDataPatch.restTime = (float)v;
            Log($"Rest Time = {ConfigDataPatch.restTime}");
        });
        ModSettings.OnChanged(ModName, "Body Decays Time", v =>
        {
            ConfigDataPatch.timeBodyDecays = (float)v;
            Log($"Body Decays Time = {ConfigDataPatch.timeBodyDecays}");
        });
        ModSettings.OnChanged(ModName, "Start Gold", v =>
        {
            ConfigDataPatch.startGold = (int)v;
            Log($"Start Gold = {ConfigDataPatch.startGold}");
        });
        ModSettings.OnChanged(ModName, "Time To Die/Infertile From Venereal Disease", v =>
        {
            ConfigDataPatch.timeToDieFromVenerealDisease = (float)v;
            Log($"Time To Die/Infertile From Venereal Disease = {ConfigDataPatch.pixyMoveDurationMultiplier}");
        });
        ModSettings.OnChanged(ModName, "Cost Of Disposing Corpse", v =>
        {
            ConfigDataPatch.costOfDisposingCorpse = (int)v;
            Log($"Cost Of Disposing Corpse = {ConfigDataPatch.costOfDisposingCorpse}");
        });
        ModSettings.OnChanged(ModName, "Cost Of Disposing Infertile Monster", v =>
        {
            ConfigDataPatch.costOfDisposingInfertileMonster = (int)v;
            Log($"Cost Of Disposing Infertile Monster = {ConfigDataPatch.costOfDisposingInfertileMonster}");
        });
        ModSettings.OnChanged(ModName, "Pixy Move Duration Multiplier", v =>
        {
            ConfigDataPatch.pixyMoveDurationMultiplier = (float)v;
            Log($"Pixy Move Duration Multiplier = {ConfigDataPatch.pixyMoveDurationMultiplier}");
        });
        ModSettings.OnChanged(ModName, "Loan Period", v =>
        {
            ConfigDataPatch.loanPeriod = (int)v;
            Log($"Loan Period = {ConfigDataPatch.loanPeriod}");
        });
        ModSettings.OnChanged(ModName, "Price Of Tentacle Egg", v =>
        {
            UnitPatch.priceTentacleEgg = (int)v;
            Log($"Price Of Tentacle Egg = {UnitPatch.priceTentacleEgg}");
        });
        ModSettings.OnChanged(ModName, "Essence Of Tentacle Egg", v =>
        {
            ConfigDataPatch.soulOfTentacleEgg = (int)v;
            Log($"Essence Of Tentacle Egg = {ConfigDataPatch.soulOfTentacleEgg}");
        });
        ModSettings.OnChanged(ModName, "Essence For Tentacle Room", v =>
        {
            ConfigDataPatch.soulForTentacleRoom = (int)v;
            Log($"Essence For Tentacle Room = {ConfigDataPatch.soulForTentacleRoom}");
        });
        ModSettings.OnChanged(ModName, "Egg For Tentacle Room", v =>
        {
            ConfigDataPatch.eggForTentacleRoom = (int)v;
            Log($"Egg For Tentacle Room = {ConfigDataPatch.eggForTentacleRoom}");
        });
        ModSettings.OnChanged(ModName, "Max Essence", v =>
        {
            ConfigDataPatch.maxSoul = (int)v;
            Log($"Max Essence = {ConfigDataPatch.maxSoul}");
        });
        ModSettings.OnChanged(ModName, "Private Estate Cost", v =>
        {
            ConfigDataPatch.privateEstateCost = (int)v;
            Log($"Private Estate Cost = {ConfigDataPatch.privateEstateCost}");
        });

        ModSettings.OnChanged(ModName, "Dismantling Limit", v =>
        {
            EPlayEventTypeExtensionsPatch.dismantlingLimit = (int)v;
            Log($"Dismantling Limit = {EPlayEventTypeExtensionsPatch.dismantlingLimit}");
        });
    }

    private static void OnLanguageChanged(string langCode)
    {
        Strings.Culture = Localization.CurrentCulture;
        ModSettings.SetDescription(ModName, "Drag During Pause", Strings.Config_DragDuringPause);
        ModSettings.SetDescription(ModName, "Game Speed Extensions", Strings.Config_GameSpeedExtensions);
        ModSettings.SetDescription(ModName, "Disable Slave Escape", Strings.Config_DisableSlaveEscape);

        ModSettings.SetDescription(ModName, "Percent That Changes To Drain", Strings.Config_PercentThatChangesToDrain);
        ModSettings.SetDescription(ModName, "Game day length", Strings.Config_Gamedaylength);
        ModSettings.SetDescription(ModName, "Rest Time", Strings.Config_RestTime);
        ModSettings.SetDescription(ModName, "Body Decays Time", Strings.Config_BodyDecaysTime);
        ModSettings.SetDescription(ModName, "Start Gold", Strings.Config_StartGold);
        ModSettings.SetDescription(ModName, "Time To Die/Infertile From Venereal Disease", Strings.Config_TimeToDieFromVenerealDisease);
        ModSettings.SetDescription(ModName, "Cost Of Disposing Corpse", Strings.Config_CostOfDisposingCorpse);
        ModSettings.SetDescription(ModName, "Cost Of Disposing Infertile Monster", Strings.Config_CostOfDisposingInfertileMonster);
        ModSettings.SetDescription(ModName, "Pixy Move Duration Multiplier", Strings.Config_PixyMoveDurationMultiplier);
        ModSettings.SetDescription(ModName, "Loan Period", Strings.Config_LoanPeriod);
        ModSettings.SetDescription(ModName, "Price Of Tentacle Egg", Strings.Config_PriceOfTentacleEgg);
        ModSettings.SetDescription(ModName, "Essence Of Tentacle Egg", Strings.Config_EssenceOfTentacleEgg);
        ModSettings.SetDescription(ModName, "Essence For Tentacle Room", Strings.Config_EssenceForTentacleRoom);
        ModSettings.SetDescription(ModName, "Egg For Tentacle Room", Strings.Config_EggForTentacleRoom);
        ModSettings.SetDescription(ModName, "Max Essence", Strings.Config_MaxEssence);
        ModSettings.SetDescription(ModName, "Private Estate Cost", Strings.Config_PrivateEstateCost);

        ModSettings.SetDescription(ModName, "Dismantling Limit", Strings.Config_DismantlingLimit);
        Log($"language changed: {langCode}");
    }
}