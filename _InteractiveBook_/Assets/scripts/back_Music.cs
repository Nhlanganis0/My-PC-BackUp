using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_Music : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip backkround;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backkround;
        audioSource.Play(0);
    }
}
