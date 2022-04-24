using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSoundManager : MonoBehaviour
{
    public static WeaponSoundManager instance;
    [SerializeField]
    private AudioClip fire, changeWeapon;

    [SerializeField]
    private AudioSource weaponAudioSource;
    private void Start()
    {
        instance = this;
        //fallAudioSource.clip = fall;
    }

    public void Fire()
    {
        weaponAudioSource.clip = fire;
        //if (!weaponAudioSource.isPlaying)
        if (true)
        {
            weaponAudioSource.volume = .5f;
            weaponAudioSource.Play();
            //audioSource.

        }
    }

    public void ChangeWeapon()
    {
        weaponAudioSource.clip = changeWeapon;
        if (!weaponAudioSource.isPlaying)
        {
            weaponAudioSource.volume = .5f;
            weaponAudioSource.Play();
            //audioSource.

        }
    }
}
