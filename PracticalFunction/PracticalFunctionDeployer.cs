using PracticalFunction.Features;
using UnityEngine;

namespace PracticalFunction;

internal class PracticalFunctionDeployer : MonoBehaviour
{
    internal static void Initialize()
    {
        var go = new GameObject("PracticalFunction_Deployer");
        DontDestroyOnLoad(go);
        go.hideFlags = HideFlags.HideAndDontSave;
        go.AddComponent<PracticalFunctionDeployer>();

        ModEntry.Log("Deployer loaded!");
    }

    private void Update()
    {
        OneClickSell.OnKeyPress();
    }
}
