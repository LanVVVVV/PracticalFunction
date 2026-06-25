using HarmonyLib;
using MBMScripts;
using PracticalFunction;
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

    #region Game Speed Extensions
    [HarmonyPatch(typeof(GameManager), nameof(GameManager.GameResume))]
    [HarmonyPrefix]
    public static void GameResumePrefix(GameManager __instance, ref int ___m_GameSpeedIndex)
    {
        float[] speedArray = GameManager.ConfigData.GameSpeedArray;

        if (___m_GameSpeedIndex >= 0 && speedArray != null && ___m_GameSpeedIndex < speedArray.Length)
        {
            return;
        }

        ModEntry.LogWarning($"[GameResumePatch] GameManager.m_GameSpeedIndex ({___m_GameSpeedIndex}) is out of bounds or array is invalid! Auto-corrected.");

        if (speedArray != null && speedArray.Length > 0)
        {
            ___m_GameSpeedIndex = speedArray.Length - 1;
        }
        else
        {
            ___m_GameSpeedIndex = 0;
        }
    }

    [HarmonyPatch(nameof(GameManager.GamePlayAndPause))]
    [HarmonyPrefix]
    public static void GamePlayAndPausePrefix(GameManager __instance, ref int ___m_GameSpeedIndex)
    {
        float[] speedArray = GameManager.ConfigData.GameSpeedArray;

        if (___m_GameSpeedIndex >= 0 && speedArray != null && ___m_GameSpeedIndex < speedArray.Length)
            return;

        ModEntry.LogWarning($"[GamePlayAndPausePatch] GameManager.m_GameSpeedIndex ({___m_GameSpeedIndex}) is out of bounds or array is invalid! Auto-corrected.");
        if (speedArray != null && speedArray.Length > 0)
        {
            ___m_GameSpeedIndex = speedArray.Length - 1;
        }
        else
        {
            ___m_GameSpeedIndex = 0;
        }
    }
    #endregion
}
