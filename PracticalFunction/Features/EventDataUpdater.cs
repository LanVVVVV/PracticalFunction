using MBMScripts;
using PracticalFunction.ModConfig;

namespace PracticalFunction.Features;

public class EventDataUpdater
{
    public static void ApplyAll()
    {
        UpdateDismantlingLimitData(ModSettingsDataRegister.DismantlingLimitData);

        ModEntry.Log("All EventData Modify initialized");
    }
    public static void UpdateDismantlingLimitData(ModSettingsDataInt dismantlingLimitData)
    {
        var dismantlingLimit = dismantlingLimitData.GetValue;
        if (dismantlingLimit == -1)
        {
            dismantlingLimit = 2147483583;
        }

        SetEventValue(EPlayEventType.ThisIsBlackCompany, 0, (float)dismantlingLimit);
    }

    public static void SetEventValue(EPlayEventType type, int index, float value)
    {
        var data = Database<EventData>.GetDataByDataId((int)type);
        if (data == null) return;

        var values = data.ValueList;
        if (values == null || index < 0 || index >= values.Length) return;

        values[index] = value;
    }
}