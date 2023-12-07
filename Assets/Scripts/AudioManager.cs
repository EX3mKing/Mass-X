using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Transform santa;
    public Transform player;
    
    public AudioSource AS_SFX;
    public AudioSource AS_Music;
    public AudioSource AS_Noise;
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Update()
    {
        AS_Noise.volume = Mathf.Clamp01(1 - Vector3.Distance(santa.position, player.position) / 10);
        AS_Music.volume = 1 - AS_Noise.volume;
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
