using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManagerScript : MonoBehaviour {

    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;
    public AudioMixer audioMixer;
    public static AudioManagerScript instance;
    public Sound[] sounds;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            if (s.type == 0)
                s.source = backgroundMusicSource;
            else if (s.type == 1)
                s.source = soundEffectSource;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            return;
        }
        s.source.clip = s.clip;
        s.source.loop = s.loop;
        s.source.Play();
    }

    public void Change()
    {
        bool check = PlayerPrefs.GetFloat("backgroundMusicVolume", 1f) > 0.5f;
        if (check)
        {
            backgroundMusicSource.volume = 1f;
            audioMixer.SetFloat("volumeBackgroundMusic",
                                PlayerPrefs.GetFloat("backgroundMusicSliderValue", -5f));
        }
        else
        {
            backgroundMusicSource.volume = 0f;
            audioMixer.SetFloat("volumeBackgroundMusic",
                                PlayerPrefs.GetFloat("backgroundMusicSliderValue", -5f));
        }

        check = PlayerPrefs.GetFloat("soundEffectVolume", 1f) > 0.5f;
        if (check)
        {
            soundEffectSource.volume = 1f;
            audioMixer.SetFloat("volumeSoundEffect",
                                PlayerPrefs.GetFloat("soundEffectSliderValue", -5f));
        }
        else
        {
            soundEffectSource.volume = 0f;
            audioMixer.SetFloat("volumeSoundEffect",
                                PlayerPrefs.GetFloat("soundEffectSliderValue", -5f));
        }
    }

    public void ButtonOnPointerEnter()
    {
        Play("ButtonOnPointerEnter");
    }

    public void Clicked()
    {
        Play("Clicked");
    }
}
