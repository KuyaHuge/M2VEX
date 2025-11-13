using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileSettings : MonoBehaviour
{
    [Header("Android Settings")]
    [Tooltip("Lock orientation - Landscape for this game")]
    public ScreenOrientation targetOrientation = ScreenOrientation.LandscapeLeft;

    [Tooltip("Target frame rate (60 recommended)")]
    public int targetFrameRate = 60;

    [Header("Video Playback")]
    [Tooltip("Enable VSync to prevent tearing")]
    public bool enableVSync = true;

    void Awake()
    {
        ApplyMobileSettings();
    }

    void ApplyMobileSettings()
    {
        // Prevent screen from sleeping during gameplay
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        // Set screen orientation
        Screen.orientation = targetOrientation;

        // Set target frame rate
        Application.targetFrameRate = targetFrameRate;

        // Enable VSync for smooth video playback
        QualitySettings.vSyncCount = enableVSync ? 1 : 0;

        // Android-specific optimizations
#if UNITY_ANDROID
        // Force high performance mode if available
        Application.targetFrameRate = targetFrameRate;

        // Disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif

        Debug.Log($"Mobile Settings Applied: FPS={targetFrameRate}, VSync={enableVSync}, Orientation={targetOrientation}");
    }
}
