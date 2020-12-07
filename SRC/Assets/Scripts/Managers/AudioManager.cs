using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioInstance;

    AudioSource musicSource;
    AudioSource sfxSource;

    void Awake()
    {
        if (audioInstance == null)
        {
            audioInstance = this;
            DontDestroyOnLoad(gameObject);
            SetupDependencies();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void SetupDependencies()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

        sfxSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySong(AudioClip newSong)
    {
        if (newSong != null)
        {
            StopSong();

            musicSource.clip = newSong;
            musicSource.Play();
        }
    }

    public void StopSong()
    {
        musicSource.Stop();
    }

    public void PlaySound(AudioClip sound)
    {
        sfxSource.PlayOneShot(sound);
    }

    public void AdjustMusicVolume(float adjustment)
    {
        musicSource.volume = adjustment;
    }

    public void AdjustSoundVolume(float adjustment)
    {
        sfxSource.volume = adjustment;
    }
}
