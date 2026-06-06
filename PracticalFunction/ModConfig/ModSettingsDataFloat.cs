using MBM.ModLoader.Settings;
using System;

namespace PracticalFunction.ModConfig;

public class ModSettingsDataFloat : ModSettingsData
{
    public float FloatValue { get; set; }

    public float GetValue => FloatValue;

    public event Action<ModSettingsDataFloat>? OnModSettingsChange;

    public override void Register()
    {
        ModSettings.RegisterFloat(ModEntry.ModName, Name, FloatValue, Description);
    }

    public override void Register(string group)
    {
        ModSettings.RegisterFloat(ModEntry.ModName, Name, FloatValue, Description, group);
    }

    public override void Register(string group, string visibleKey)
    {
        ModSettings.RegisterFloat(ModEntry.ModName, Name, FloatValue, Description, group, visibleKey);
    }

    public override void Initialize()
    {
        FloatValue = ModSettings.GetFloat(ModEntry.ModName, Name);
    }

    public override void ModSettingsOnChanged()
    {
        ModSettings.OnChanged(ModEntry.ModName, Name, v =>
        {
            if (FloatValue == (float)v) return;
            FloatValue = (float)v;
            ModEntry.Log($"{Name} = {FloatValue}");
            OnModSettingsChange?.Invoke(this);
        });
    }

    public ModSettingsDataFloat(string name, float defaultValue, string description) : base(name, description)
    {
        FloatValue = defaultValue;
    }
}