using HarmonyLib;
using MBMScripts;
using PracticalFunction.ModConfig;

namespace PracticalFunction.Patches;

[HarmonyPatch(typeof(EPlayEventTypeExtensions))]
public class EPlayEventTypeExtensionsPatch
{
    private static int DismantlingLimit => ModSettingsDateRegister.DismantlingLimitDate.GetValue;

    [HarmonyPatch(nameof(EPlayEventTypeExtensions.GetValue))]
    [HarmonyPostfix]
    public static void RestTimePostfix(ref float __result, EPlayEventType playEventType, int index)
    {
        if (playEventType == EPlayEventType.ThisIsBlackCompany && index == 0)
        {
            if(DismantlingLimit == -1)
            {  
                __result = 2147483583;
                return;
            }
            __result = DismantlingLimit;
        }
    }
}