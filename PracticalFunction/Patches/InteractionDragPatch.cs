using HarmonyLib;
using MBMScripts;
using PracticalFunction.ModConfig;

namespace PracticalFunction.Patches;

[HarmonyPatch(typeof(InteractionUnit), nameof(InteractionUnit.Drag))]
public class InteractionDragPatch
{
    private static bool EnabledDragDuringPause { get => ModSettingsDateRegister.DragDuringPauseDate.GetValue; }

    /// <summary>
    /// Bypass GameSpeedIsZero and Record the original value.
    /// </summary>
    [HarmonyPrefix]
    public static void DragPrefix(out bool __state)
    {
        __state = GameManager.Instance.GameSpeedIsZero;
        if (!EnabledDragDuringPause) return;
        GameManager.Instance.GameSpeedIsZero = false;
    }

    /// <summary>
    /// Recover GameSpeedIsZero original value.
    /// </summary>
    [HarmonyPostfix]
    public static void DragPostfix(bool __state)
    {
        if (!EnabledDragDuringPause) return;
        if (__state) GameManager.Instance.GameSpeedIsZero = __state;
    }
}