using HarmonyLib;
using MBMScripts;
using UnityEngine;

namespace PracticalFunction.Fixes;

[HarmonyPatch(typeof(Room), nameof(Room.OnStart))]
public class RoomBuildPatch
{
    /// <summary>
    /// Refresh BoxCollider2D Component to synchronize its position with the rendering position.
    /// </summary>
    [HarmonyPostfix]
    public static void OnStartPostfix(Room __instance)
    {
        var colliderTransform = __instance.UnitComponent.transform.Find("Collider");
        if (colliderTransform is not null && colliderTransform.TryGetComponent(out BoxCollider2D collider))
        {
            collider.enabled = false;
            collider.enabled = true;
        }
    }
}