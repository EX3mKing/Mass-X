using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Image vignette;
    private Color vignetteColor;

    public Transform santa;
    public Transform player;
    
    public float noiseVolume = 10f;
    
    public AudioSource AS_SFX;
    public AudioSource AS_Music;
    public AudioSource AS_Noise;
    public AudioSource AS_Santa;
    
    
    private void Awake()
    {
        Instance = this;
        vignetteColor = vignette.color;
    }
    
    private void Update()
    {
        AS_Noise.volume = Mathf.Clamp01(1 - Vector3.Distance(santa.position, player.position) / noiseVolume);
        AS_Music.volume = 1 - AS_Noise.volume;
        vignette.color = new Color(vignetteColor.r,  vignetteColor.g, vignetteColor.b, AS_Noise.volume);
    }

    public void PlaySFX(AudioClip clip)
    {
        AS_SFX.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        AS_Music.PlayOneShot(clip);
    }
    
    public void PlayNoise(AudioClip clip)
    {
        AS_Noise.PlayOneShot(clip);
    }
    
    public void PlayAtSanta(AudioClip clip)
    {
        AS_Santa.PlayOneShot(clip);
    }
    
    public void SetNoiseVolume(float volume)
    {
        noiseVolume = volume;
    }
}
