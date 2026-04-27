using MBM.ModLoader.Settings;

namespace PracticalFunction.ModConfig;

public class ModSettingsDateInt : ModSettingsDate
{
    public int IntValue { get; set; }

    public int GetValue { get => IntValue; }

    public override void Register()
    {
        ModSettings.RegisterInt(ModEntry.ModName, Name, IntValue, Description);
    }

    public override void Register(string group)
    {
        ModSettings.RegisterInt(ModEntry.ModName, Name, IntValue, Description, group);
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
        });
    }

    public ModSettingsDateInt(string name, int defaultValue, string description) : base(name, description)
    {
        IntValue = defaultValue;
    }
}