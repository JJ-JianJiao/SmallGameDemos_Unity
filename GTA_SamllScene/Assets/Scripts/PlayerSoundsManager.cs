using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSoundsManager : MonoBehaviour
{
    public static PlayerSoundsManager instance;

    [SerializeField]
    private AudioClip run, jump, fall;

    [SerializeField]
    private AudioSource audioSource;

    private void Start()
    {
        instance = this;
        //fallAudioSource.clip = fall;
    }

    public void Run()
    {
        audioSource.clip = run;
        if (!audioSource.isPlaying)
        {
            //audioSource.volume = .5f;
            audioSource.Play();

        }
    }

    public void Jump() {
        audioSource.clip = jump;
        if (!audioSource.isPlaying)
        {
            //audioSource.volume = .5f;
            audioSource.Play();

        }
    }

    public void Fall()
    {
        audioSource.clip = fall;
        if (!audioSource.isPlaying)
        {
            //audioSource.volume = .5f;
            audioSource.Play();
            //audioSource.

        }
    }

}
