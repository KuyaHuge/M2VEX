using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TravelManager : MonoBehaviour
{
    public static TravelManager instance;
    public VideoPlayer videoPlayer;
    public GameObject[] Areas;
    public VideoClip[] IdleVideos;

    private void Awake()
    {
        instance = this;
    }

    public void ActivateOnlyOneArea(int index)
    {
        for (int i = 0; i < Areas.Length; i++)
        {
            if (Areas[i] != null)
            {
                Areas[i].SetActive(i == index);
            }
        }
    }

    public void ActivateIdleArea(int index)
    {
        videoPlayer.clip = IdleVideos[index];
        videoPlayer.Play();
    }

    

}
