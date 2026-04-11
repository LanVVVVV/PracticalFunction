using HarmonyLib;
using MBMScripts;

namespace PracticalFunction.Patches;

[HarmonyPatch(typeof(InteractionUnit), nameof(InteractionUnit.Drag))]
public class InteractionDragPatch
{
    internal static bool enabledDragDuringPause;

    /// <summary>
    /// Bypass GameSpeedIsZero and Record the original value.
    /// </summary>
    [HarmonyPrefix]
    public static void DragPrefix(out bool __state)
    {
        __state = GameManager.Instance.GameSpeedIsZero;
        if (!enabledDragDuringPause) return;
        GameManager.Instance.GameSpeedIsZero = false;
    }

    /// <summary>
    /// Recover GameSpeedIsZero original value.
    /// </summary>
    [HarmonyPostfix]
    public static void DragPostfix(bool __state)
    {
        if (!enabledDragDuringPause) return;
        if (__state) GameManager.Instance.GameSpeedIsZero = __state;
    }
}