using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoSingleton<AudioHandler>
{
    [SerializeField]
    private AudioClip[] audioClip;

    [SerializeField]
    private AudioSource audioSource;

    public void PlayAudio(int audioIndex) {
        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = audioClip[audioIndex];
        audioSource.Play();
    }
}
