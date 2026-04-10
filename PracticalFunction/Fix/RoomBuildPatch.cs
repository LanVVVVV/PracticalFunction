using HarmonyLib;
using MBMScripts;
using UnityEngine;

namespace PracticalFunction.Fix;

[HarmonyPatch(typeof(Room), nameof(Room.OnStart))]
public class RoomBuildPatch
{
    /// <summary>
    /// Refresh BoxCollider2D Component to synchronize its position with the rendering position.
    /// </summary>
    [HarmonyPostfix]
    public static void OnStartPostfix(Room __instance)
    {
        BoxCollider2D collider = __instance.UnitComponent.transform.Find("Collider").GetComponent<BoxCollider2D>();
        collider.enabled = false;
        collider.enabled = true;
    }
}