using MBMScripts;
using UnityEngine;
using PracticalFunction.Properties;
using PracticalFunction.ModConfig;

namespace PracticalFunction.Features;

public static class OneClickSell
{
    private static bool Enabled { get => ModSettingsDateRegister.OneClickSellDate.GetValue; }

    public static void OnKeyPress()
    {
        if (!Enabled) return;
        if (Input.GetKeyDown(KeyCode.Delete)) Sell();
    }

    public static void Sell()
    {
        GameManager instance = GameManager.Instance;
        PlayData playerData = instance.PlayerData;

        if (playerData.MultiSelectedUnitSeqList.Count > 0)
        {
            foreach (Unit unit0 in playerData.MultiSelectedUnitSeqList)
            {
                SellCharacter(unit0);
            }
            playerData.ClearMultiSelect();
            return;
        }

        Unit unit = playerData.SelectedUnit;
        if (unit == null) unit = playerData.DraggingUnit;
        if (unit == null) unit = playerData.HighlightedUnit;
        if (unit == null || unit.IsDisabled) return;
        if (unit is Character) SellCharacter(unit);
    }

    public static void SellCharacter(Unit unit)
    {
        GameManager instance = GameManager.Instance;

        if (unit is Female female)
        {
            if (female.IsNpc || female.IsNpc2) return;
            EState state = female.State;
            if (state == EState.Birth || state == EState.BirthDrained)
            {
                instance.AddSystemMessage(Strings.Message_NoSellBirth);
                return;
            }
        }
        if (unit.IsNotDraggable) return;
        if (unit.Sector == ESector.Market) return;
        if (unit is Player)
        {
            instance.AddSystemMessage("#No_Sell_Player");
            return;
        }
        if (instance.Tutorial)
        {
            instance.AddSystemMessage("#CannotInTutorial");
            return;
        }

        unit.Sell(false, true, -1, true);
    }
}

