using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerController : MonoBehaviour
{
    public static AudioManagerController instance;

    [SerializeField] private AudioSource firstMusicSource;
    [SerializeField] private AudioSource secondMusicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource backgroundSounds;

    public float musicVolume = 0.2f;

    private bool firstMusicSourceIsPlaying = false;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

    }

 
    public void PlayMusicWithFade(AudioClip musicClip, float transistionTimer = 1.0f)
    {
        AudioSource currentSource = (firstMusicSourceIsPlaying) ? firstMusicSource : secondMusicSource;

        StartCoroutine(UpdateMusicWithFade(currentSource, musicClip, transistionTimer));
    }

    IEnumerator UpdateMusicWithFade(AudioSource currentSource, AudioClip musicClip, float transistionTimer)
    {
        if(!currentSource.isPlaying)
        {
            currentSource.Play();
        }

        float t = 0.0f;

       
        for(t = 0.0f; t <= transistionTimer; t += Time.deltaTime)
        {
            currentSource.volume = (musicVolume - ((t / transistionTimer) * musicVolume));
            yield return null;
        }

        currentSource.Stop();
        currentSource.clip = musicClip;
        currentSource.Play();

        
        for(t = 0.0f; t <= transistionTimer; t += Time.deltaTime)
        {
            currentSource.volume = (t / transistionTimer) * musicVolume;
            yield return null;
        }

        currentSource.volume = musicVolume;

    }

    public void PlaySFX(AudioClip clip, float volume = 1.0f)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    public void PlayBackgroundSounds(AudioClip incomingClip, float volume = 1.0f)
    {
        backgroundSounds.clip = incomingClip;
        backgroundSounds.Play();
    }

    public void StopBackgroundSounds()
    {
        backgroundSounds.Stop();
    }

}
