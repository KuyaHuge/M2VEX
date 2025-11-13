using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [Header("Music Settings")]
    [SerializeField] AudioSource audioSource;     // Assign an AudioSource in Inspector
    public AudioClip[] musicTracks;     // Assign 3 or more music clips

    private AudioClip currentTrack;

    void Start()
    {
        if (musicTracks.Length > 0)
        {
            PlayRandomTrack();
        }
        else
        {
            Debug.LogWarning("No music tracks assigned!");
        }
    }

    void Update()
    {
        // When the track ends, pick a new random one
        if (!audioSource.isPlaying)
        {
            PlayRandomTrack();
        }
    }

    void PlayRandomTrack()
    {
        if (musicTracks.Length == 0) return;

        AudioClip newTrack;
        do
        {
            newTrack = musicTracks[Random.Range(0, musicTracks.Length)];
        }
        while (newTrack == currentTrack && musicTracks.Length > 1);

        currentTrack = newTrack;
        audioSource.clip = currentTrack;
        audioSource.Play();
    }
}
