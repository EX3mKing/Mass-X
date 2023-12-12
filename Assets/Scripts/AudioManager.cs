using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public AudioSource AS_SFX;
    public AudioSource AS_Music;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySFX(AudioClip clip)
    {
        AS_SFX.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        AS_Music.PlayOneShot(clip);
    }
}
