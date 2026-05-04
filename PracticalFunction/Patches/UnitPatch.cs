using HarmonyLib;
using MBMScripts;
using PracticalFunction.ModConfig;

namespace PracticalFunction.Patches;

[HarmonyPatch(typeof(Unit))]
public class UnitPatch
{
    private static int PriceTentacleEgg => ModSettingsDateRegister.PriceTentacleEggDate.GetValue;

    [HarmonyPatch(nameof(Unit.Price), MethodType.Getter)]
    [HarmonyPostfix]
    public static void PricePostfix(Unit __instance, ref int __result)
    {
        if (__instance is Item item && item.ItemType == EItemType.Item_TentacleEgg)
            __result = PriceTentacleEgg;
    }
}