using HarmonyLib;
using MBMScripts;

namespace PracticalFunction.Patches;

[HarmonyPatch(typeof(Unit))]
internal class UnitPatch
{
    internal static int priceTentacleEgg;

    [HarmonyPatch(nameof(Unit.Price), MethodType.Getter)]
    [HarmonyPostfix]
    public static void PricePostfix(Unit __instance, ref int __result)
    {
        if (__instance is Item item && item.ItemType == EItemType.Item_TentacleEgg)
            __result = priceTentacleEgg;
    }
}