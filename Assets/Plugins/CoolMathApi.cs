using System.Runtime.InteropServices;
using UnityEngine;

public class CoolMathApi : MonoBehaviour
{
    // Import the javascript function that redirects to another URL
    [DllImport("__Internal")]
    private static extern void RedirectTo();
    // Import the javascript function that redirects to another URL
    [DllImport("__Internal")]
    private static extern void StartGameEvent();
    // Import the javascript function that redirects to another URL
    [DllImport("__Internal")]
    private static extern void StartLevelEvent(int level);
    // Import the javascript function that redirects to another URL
    [DllImport("__Internal")]
    private static extern void ReplayEvent();
}
