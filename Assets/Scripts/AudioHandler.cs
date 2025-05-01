using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioClip;

    [SerializeField]
    private AudioSource audioSource;

    public static AudioHandler instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public void PlayAudio(int audioIndex) {
        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = audioClip[audioIndex];
        audioSource.Play();
    }
}
