using HarmonyLib;
using MBMScripts;

namespace PracticalFunction.Patches;

[HarmonyPatch(typeof(EPlayEventTypeExtensions))]
internal class EPlayEventTypeExtensionsPatch
{
    internal static int dismantlingLimit; 

    [HarmonyPatch(nameof(EPlayEventTypeExtensions.GetValue))]
    [HarmonyPostfix]
    public static void RestTimePostfix(ref float __result, EPlayEventType playEventType, int index)
    {
        if (playEventType == EPlayEventType.ThisIsBlackCompany && index == 0)
        {
            if(dismantlingLimit == -1)
            {  
                __result = 2147483583;
                return;
            }
            __result = dismantlingLimit;
        }
    }
}