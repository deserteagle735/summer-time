using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public Sound[] sounds;

    public AudioMixer audioMixer;

    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;

    public static SoundManagerScript instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Start()
    {
        Play("BackgroundMusic");

    }

    public void ButtonPointerEnter()
    {
        Play("ButtonPointerEnter");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play(); 
    }

    public void SliderBackgroundMusicOnValueChanged(float volume)
    {
        audioMixer.SetFloat("volumeBackgroundMusic", volume);
    }

    public void SliderSoundEffectOnValueChanged(float volume)
    {
        audioMixer.SetFloat("volumeSoundEffect", volume);
    }

    public void ToggleBackgroundMusicOnValueChanged(bool check)
    {
        if (check == true)
            backgroundMusicSource.volume = 1f;
        else
            backgroundMusicSource.volume = 0f;
    }

    public void ToggleSoundEffectOnValueChanged(bool check)
    {
        if (check == true)
            soundEffectSource.volume = 1f;
        else
            soundEffectSource.volume = 0f;
    }
}
