using MBM.ModLoader.Settings;

namespace PracticalFunction.ModConfig;

public class ModSettingsDateBool : ModSettingsDate
{
    public bool BoolValue { get; set; }

    public bool GetValue { get => BoolValue; }

    public override void Register()
    {
        ModSettings.RegisterBool(ModEntry.ModName, Name, BoolValue, Description);
    }

    public override void Register(string group)
    {
        ModSettings.RegisterBool(ModEntry.ModName, Name, BoolValue, Description, group);
    }

    public override void Register(string group, string visibleKey)
    {
        ModSettings.RegisterBool(ModEntry.ModName, Name, BoolValue, Description, group, visibleKey);
    }

    public override void Initialize()
    {
        BoolValue = ModSettings.GetBool(ModEntry.ModName, Name);
    }

    public override void ModSettingsOnChanged()
    {
        ModSettings.OnChanged(ModEntry.ModName, Name, v =>
        {
            if (BoolValue == (bool)v) return;
            BoolValue = (bool)v;
            ModEntry.Log($"{Name} = {BoolValue}");
        });
    }

    public ModSettingsDateBool(string name, bool defaultValue, string description) : base(name, description)
    {
        BoolValue = defaultValue;
    }
}