using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("OtherButtons")]
    public GameObject[] buttons;

    [Header("Video Player")]
    public VideoPlayer videoPlayer;

    [Header("Video Clips")]
    public VideoClip[] clip;

    [Header("Preloading Images Script")]
    public BGI BGI;
    public string AreaName;
    public int LookIndex;
    public int IdleIndex;

    private bool finished = false;
    private bool isDisabled = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetButtonsActive(false);
        if (isDisabled == false)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
            videoPlayer.loopPointReached -= OnVideoStart;

            videoPlayer.clip = clip[0];
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoStart;
            isDisabled = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetButtonsActive(true);
        videoPlayer.loopPointReached -= OnVideoEnd;
        videoPlayer.loopPointReached -= OnVideoStart;

        if (finished == true || isDisabled == false)
        {
            BGI.CurrentImage(AreaName, LookIndex);
            videoPlayer.clip = clip[1];
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoEnd;
            isDisabled = true;
        }
        else
        {
            BGI.CurrentImage(AreaName,IdleIndex);
            videoPlayer.clip = clip[2];
            videoPlayer.Play();
            isDisabled = false;
        }

    }

    void OnVideoStart(VideoPlayer vp)
    {
        videoPlayer.loopPointReached -= OnVideoEnd;
        videoPlayer.loopPointReached -= OnVideoStart;

        videoPlayer.Pause();
        finished = true;
        isDisabled = false;
    }

    void OnVideoEnd(VideoPlayer vp) {

        BGI.CurrentImage(AreaName, IdleIndex);

        videoPlayer.loopPointReached -= OnVideoEnd;
        videoPlayer.loopPointReached -= OnVideoStart;


        videoPlayer.clip = clip[2];
        videoPlayer.Play();
        finished = false;
        isDisabled = false;
    }

    private void SetButtonsActive(bool active)
    {
        if (buttons != null)
        {
            foreach (GameObject button in buttons)
            {
                if (button != null)
                {
                    button.SetActive(active);
                }
            }
        }
    }

}
