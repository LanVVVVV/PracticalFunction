using HarmonyLib;
using MBMScripts;
using System;
using System.Collections;

[HarmonyPatch(typeof(GameManager))]
public static class GameManagerPatch
{
    #region AfterDataInitialized
    public static event Action? AfterDataInitialized;

    [HarmonyPatch("InitializeData")]
    [HarmonyPostfix]
    static void InitializeDataPostfix()
    {
        AfterDataInitialized?.Invoke();
    }
    #endregion

    #region TutorialNielGettingDna
    [HarmonyPatch("TutorialNielGettingDna")]
    [HarmonyPostfix]
    static IEnumerator TutorialNielGettingDnaPostfix(IEnumerator __result)
    {
        return FinalizeTutorial(__result);
    }

    private static IEnumerator FinalizeTutorial(IEnumerator originalCoroutine)
    {
        while (originalCoroutine.MoveNext())
        {
            yield return originalCoroutine.Current;
        }

        if (GameManager.Instance != null &&
        !GameManager.Instance.PlayerData.GetUpgradeFlag(EUpgradeType.UpgradeNiel))
        {
            GameManager.Instance.CloseWindow(EGameWindow.Niel);
        }
    }
    #endregion
}