using PracticalFunction.Features;

namespace PracticalFunction.ModConfig
{
    public static class ModSettingsDataRegisterEvents
    {
        public static void RegisterEvents()
        {
            RegisterConfigDataEvents();
            RegisterEventDataEvents();
        }

        private static void RegisterEventDataEvents()
        {
            ModSettingsDataRegister.DismantlingLimitData.OnModSettingsChange += data =>
            EventDataUpdater.UpdateDismantlingLimitData(data);
        }

        private static void RegisterConfigDataEvents()
        {
            ModSettingsDataRegister.GameSpeedExtensionsData.OnModSettingsChange += data =>
                ConfigDataUpdater.UpdateGameSpeedArray(data);

            ModSettingsDataRegister.DisableSlaveEscapeData.OnModSettingsChange += data =>
                ConfigDataUpdater.UpdateProbabilityOfEscapingArray(data);

            //TitsModCompatibility
            ModSettingsDataRegister.SecondsOfDayData.OnModSettingsChange += data =>
            ConfigDataUpdater.UpdateSecondsOfDay(data);

            ModSettingsDataRegister.TimeBodyDecaysData.OnModSettingsChange += data =>
            ConfigDataUpdater.UpdateTimeBodyDecays(data);

            ModSettingsDataRegister.TimeToDieFromVenerealDiseaseData.OnModSettingsChange += data =>
            {
                ConfigDataUpdater.UpdateTimeToDieFromVenerealDisease(data);
                ConfigDataUpdater.UpdateTimeToBeInfertileFromVenerealDisease(data);
            };

            ModSettingsDataRegister.CostOfDisposingCorpseData.OnModSettingsChange += data =>
            ConfigDataUpdater.UpdateCostOfDisposingCorpse(data);

            ModSettingsDataRegister.CostOfDisposingInfertileMonsterData.OnModSettingsChange += data =>
            ConfigDataUpdater.UpdateCostOfDisposingInfertileMonster(data);

            ModSettingsDataRegister.PixyMoveDurationMultiplierData.OnModSettingsChange += data =>
            ConfigDataUpdater.UpdatePixyMoveSpeed(data);

            //TitsModCompatibility.Apply
            ModSettingsDataRegister.TitsModCompatibilityData.OnModSettingsChange += data =>
            ConfigDataUpdater.UpdateOfTitsModCompatibility(data);
            ModEntry.Log("Tits Mod Compatibility Data Updater initialized");

            ModSettingsDataRegister.PercentThatChangesToDrainData.OnModSettingsChange += data =>
                ConfigDataUpdater.UpdatePercentThatChangesToDrain(data);

            ModSettingsDataRegister.RestTimeData.OnModSettingsChange += data =>
                ConfigDataUpdater.UpdateRestTime(data);

            ModSettingsDataRegister.StartGoldData.OnModSettingsChange += data =>
                ConfigDataUpdater.UpdateStartGold(data);

            ModSettingsDataRegister.LoanPeriodData.OnModSettingsChange += data =>
                ConfigDataUpdater.UpdateLoanPeriod(data);

            ModSettingsDataRegister.SoulOfTentacleEggData.OnModSettingsChange += data =>
                ConfigDataUpdater.UpdateSoulOfTentacleEgg(data);

            ModSettingsDataRegister.SoulForTentacleRoomData.OnModSettingsChange += data =>
                ConfigDataUpdater.UpdateSoulForTentacleRoom(data);

            ModSettingsDataRegister.EggForTentacleRoomData.OnModSettingsChange += data =>
                ConfigDataUpdater.UpdateEggForTentacleRoom(data);

            ModSettingsDataRegister.MaxSoulData.OnModSettingsChange += data =>
                ConfigDataUpdater.UpdateMaxSoul(data);

            ModSettingsDataRegister.PrivateEstateCostData.OnModSettingsChange += data =>
                ConfigDataUpdater.UpdatePrivateEstateCost(data);
        }
    }
}