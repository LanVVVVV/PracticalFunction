using HarmonyLib;
using MBMScripts;
using PracticalFunction.ModConfig;

namespace PracticalFunction.Patches;

[HarmonyPatch(typeof(Unit), nameof(Unit.Price), MethodType.Getter)]
public static class UnitPatch
{
    private static int PriceTentacleEgg => ModSettingsDataRegister.PriceTentacleEggData.GetValue;

    [HarmonyPrefix]
    public static bool PricePrefix(Unit __instance, ref int __result)
    {
        if(__instance is Item item && item.ItemType == EItemType.Item_TentacleEgg)
        {
            SeqDataBinding.Instance.RegisterFlag(__instance, "Price");
            __result = PriceTentacleEgg;
            return false;
        }
        return true;
    }
}