using MBM.ModLoader.Settings;
using PracticalFunction.Properties;

namespace PracticalFunction.ModConfig;

public abstract class ModSettingsDate
{
    public string Name { get; set; }

    public string Description
    {
        get => Strings.Get(description);
        set => description = value;
    }
    public abstract void Register();

    public abstract void Register(string group);

    public abstract void Register(string group, string visibleKey);

    public abstract void Initialize();

    public abstract void ModSettingsOnChanged();

    public virtual void OnLanguageChanged()
    {
        ModSettings.SetDescription(ModEntry.ModName, Name, Description);
    }

    public ModSettingsDate(string name, string description)
    {
        Name = name;
        Description = description;
        ModSettingsDateRegister.All.Add(this);
    }

    private string description = null!;
}