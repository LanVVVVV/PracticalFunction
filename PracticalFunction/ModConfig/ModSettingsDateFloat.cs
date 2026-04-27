using MBM.ModLoader.Settings;

namespace PracticalFunction.ModConfig;

public class ModSettingsDateFloat : ModSettingsDate
{
    public float FloatValue { get; set; }

    public float GetValue { get => FloatValue; }

    public override void Register()
    {
        ModSettings.RegisterFloat(ModEntry.ModName, Name, FloatValue, Description);
    }

    public override void Register(string group)
    {
        ModSettings.RegisterFloat(ModEntry.ModName, Name, FloatValue, Description, group);
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
        });
    }

    public ModSettingsDateFloat(string name, float defaultValue, string description) : base(name, description)
    {
        FloatValue = defaultValue;
    }
}