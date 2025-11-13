using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class Transition : MonoBehaviour, IPointerClickHandler
{
    public VideoPlayer vidplayer;

    public VideoClip[] clips;

    public TravelManager TravelManager;

    public BGI BGI;

    public int Travelnumber;

    public string AreaName;
    public int LookIndex;

    public bool goback;


    [Header("Video Speed Settings")]
    [SerializeField] private KeyCode speedUpKey = KeyCode.Space;
    [SerializeField] private float normalSpeed = 1.0f;
    [SerializeField] private float fastSpeed = 2.0f;

    private bool isVideoPlaying = false;
    private bool isSpeedingUp = false;


    [Header("Cursor Settings")]
    [SerializeField] private bool hideCursorDuringTransition = true;
    private bool wasCursorVisible = true;


    public void OnPointerClick(PointerEventData eventData)
    {
       if (goback == false)
        {
            wasCursorVisible = Cursor.visible;
            
            vidplayer.clip = clips[0];
            vidplayer.playbackSpeed = normalSpeed;
            vidplayer.Play();
            vidplayer.loopPointReached += OnVideoEnd;

            isVideoPlaying = true;
            isSpeedingUp = false;

            if (hideCursorDuringTransition)
            {
                Cursor.visible = false;
                Debug.Log("Cursor hidden during video transition");
            }
            
        }
    }

    private void Update()
    {
        if (isVideoPlaying && vidplayer.isPlaying) {
            HandleSpeedInput();
        }
    }
    
private void HandleSpeedInput()
{
    // Check if speed up key is being held down
    if (Input.GetKey(speedUpKey))
    {
        if (!isSpeedingUp)
        {
            SetVideoSpeed(fastSpeed);
            isSpeedingUp = true;
            Debug.Log($"Video speed: {fastSpeed} x (Hold {speedUpKey} to maintain)");
        }
    }
    // Check if speed up key was released
    else if (isSpeedingUp)
    {
        SetVideoSpeed(normalSpeed);
        isSpeedingUp = false;
        Debug.Log($"Video speed: {normalSpeed}x (Normal)");
    }
}

private void SetVideoSpeed(float speed)
{
    if (vidplayer.canSetPlaybackSpeed)
    {
        vidplayer.playbackSpeed = speed;
    }
    else
    {
        Debug.LogWarning($"Cannot set playback speed for video: {vidplayer.clip?.name}");
    }
}


public void OnVideoEnd(VideoPlayer vp)
    {
        vidplayer.loopPointReached -= OnVideoEnd;

        isVideoPlaying = false;
        isSpeedingUp = false;

        if (vidplayer.canSetPlaybackSpeed)
        {
            vidplayer.playbackSpeed = normalSpeed;
        }
        
        BGI.CurrentImage(AreaName,LookIndex);


        TravelManager.ActivateOnlyOneArea(Travelnumber);
        TravelManager.ActivateIdleArea(Travelnumber);

        RestoreCursor();
    }

    private void RestoreCursor()
    {
        if (hideCursorDuringTransition)
        {
            Cursor.visible = wasCursorVisible;
            Debug.Log("Cursor restored after video transition");
        }
    }

    private void OnDisable()
    {
        if (isVideoPlaying)
        {
            RestoreCursor();
            isVideoPlaying = false;
            isSpeedingUp = false;
        }
    }
}
