using MBM.ModLoader.Settings;
using PracticalFunction.Properties;
using System;

namespace PracticalFunction.ModConfig;

public sealed class ModSettingsDataDropdown : ModSettingsData
{

    public event Action<ModSettingsDataDropdown>? OnModSettingsChange;

    public string[] Options
    {
        get
        {
            string[] options = new string[keyOptions.Length];

            keyOptions.CopyTo(options, 0);
            for (int i = 0; i < options.Length; i++)
            {
                options[i] = StringsHelper.Get(options[i]);
            }
            return options;
        }
        set
        {
            keyOptions = value;
        }
    }

    public int Index { get; set; } = 0;

    public string? Group { get; set; }

    public string? VisibleKey { get; set; }

    public override void Register()
    {
        ModSettings.RegisterDropdown(ModEntry.ModName, Name, Options, Index, Description);
    }

    public override void Register(string group)
    {
        ModSettings.RegisterDropdown(ModEntry.ModName, Name, Options, Index, Description, group);
        Group = group;
    }
    public override void Register(string group, string visibleKey)
    {
        ModSettings.RegisterDropdown(ModEntry.ModName, Name, Options, Index, Description, group, visibleKey);
        Group = group;
        VisibleKey = visibleKey;
    }
    public override void Initialize()
    {
        Index = ModSettings.GetDropdown(ModEntry.ModName, Name);
    }

    public override void ModSettingsOnChanged()
    {
        ModSettings.OnChanged(ModEntry.ModName, Name, v =>
        {
            if(Index == (int)v) return;
            Index = (int)v;
            ModEntry.Log($"{Name} = {Index}");
            OnModSettingsChange?.Invoke(this);
        });
    }

    public override void OnLanguageChanged()
    {
        ModSettings.SetDescription(ModEntry.ModName, Name, Description);

        ModSettings.RegisterDropdown(ModEntry.ModName, Name, Options, Index, Description, Group!, VisibleKey!);
    }

    public ModSettingsDataDropdown(string name, string[] options, string description) : base(name, description)
    {
        Options = options;
    }

    public string[] keyOptions = null!;
}