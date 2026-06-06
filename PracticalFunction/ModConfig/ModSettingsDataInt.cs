using MBM.ModLoader.Settings;
using System;

namespace PracticalFunction.ModConfig;

public class ModSettingsDataInt : ModSettingsData
{
    public int IntValue { get; set; }

    public int GetValue => IntValue;

    public event Action<ModSettingsDataInt>? OnModSettingsChange;

    public override void Register()
    {
        ModSettings.RegisterInt(ModEntry.ModName, Name, IntValue, Description);
    }

    public override void Register(string group)
    {
        ModSettings.RegisterInt(ModEntry.ModName, Name, IntValue, Description, group);
    }
    public override void Register(string group, string visibleKey)
    {
        ModSettings.RegisterInt(ModEntry.ModName, Name, IntValue, Description, group, visibleKey);
    }
    public override void Initialize()
    {
        IntValue = ModSettings.GetInt(ModEntry.ModName, Name);
    }

    public override void ModSettingsOnChanged()
    {
        ModSettings.OnChanged(ModEntry.ModName, Name, v =>
        {
            if(IntValue == (int)v) return;
            IntValue = (int)v;
            ModEntry.Log($"{Name} = {IntValue}");
            OnModSettingsChange?.Invoke(this);
        });
    }

    public ModSettingsDataInt(string name, int defaultValue, string description) : base(name, description)
    {
        IntValue = defaultValue;
    }
}