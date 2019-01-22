using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class PanelSettingsScript : MonoBehaviour {

    public static PanelSettingsScript instance;
    
    public Sound[] sounds;

    public AudioMixer audioMixer;

    private AudioSource backgroundMusicSource;
    private AudioSource soundEffectSource;

    public Slider backroundMusicSlider;
    public Slider soundEffectSlider;

    public Toggle backroundMusicToggle;
    public Toggle soundEffectSliderToggle;

    private void Awake()
    {
        backgroundMusicSource = GameObject.FindGameObjectWithTag("BackgroundMusicSource")
            .GetComponent<AudioSource>();
        soundEffectSource = GameObject.FindGameObjectWithTag("SoundEffectSource")
            .GetComponent<AudioSource>();
    }
    
    public void Start()
    {
        float backgroundMusicVolume = PlayerPrefs.GetFloat("backgroundMusicVolume");
        if (backgroundMusicVolume > 0)
        {
            backroundMusicToggle.isOn = true;
            backroundMusicSlider.value = PlayerPrefs.GetFloat("backgroundMusicSliderValue");
            backroundMusicSlider.interactable = true;
        }
        else
        {
            backroundMusicToggle.isOn = false;
            backroundMusicSlider.value = PlayerPrefs.GetFloat("backgroundMusicSliderValue");
            backroundMusicSlider.interactable = false;
        }

        float soundEffectVolume = PlayerPrefs.GetFloat("soundEffectVolume");
        if (soundEffectVolume > 0)
        {
            soundEffectSliderToggle.isOn = true;
            soundEffectSlider.value = PlayerPrefs.GetFloat("soundEffectVolume");
            soundEffectSlider.interactable = true;
        }
        else
        {
            soundEffectSliderToggle.isOn = false;
            soundEffectSlider.value = PlayerPrefs.GetFloat("soundEffectVolume");
            soundEffectSlider.interactable = false;
        }

        Play("BackgroundMusic");
    }
    
    public void ButtonOnPointerEnter()
    {
        Play("ButtonOnPointerEnter");
    }

    public void Clicked()
    {
        Play("Clicked");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            return;
        }

        s.source.clip = s.clip;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.loop = s.loop;
        s.source.Play();
    }

    public void SliderBackgroundMusicOnValueChanged(float volume)
    {
        audioMixer.SetFloat("volumeBackgroundMusic", volume);
        PlayerPrefs.SetFloat("backgroundMusicSliderValue", volume);

    }

    public void SliderSoundEffectOnValueChanged(float volume)
    {
        audioMixer.SetFloat("volumeSoundEffect", volume);
        PlayerPrefs.SetFloat("soundEffectSliderValue", volume);

    }

    public void ToggleBackgroundMusicOnValueChanged(bool check)
    {
        if (check == true)
        {
            backgroundMusicSource.volume = 1f;
            PlayerPrefs.SetFloat("backgroundMusicVolume", 1f);
        }
        else
        {
            backgroundMusicSource.volume = 0f;
            PlayerPrefs.SetFloat("backgroundMusicVolume", 0f);
        }
    }

    public void ToggleSoundEffectOnValueChanged(bool check)
    {
        if (check == true)
        {
            soundEffectSource.volume = 1f;
            PlayerPrefs.SetFloat("soundEffectVolume", 1f);

        }
        else
        {
            soundEffectSource.volume = 0f;
            PlayerPrefs.SetFloat("soundEffectVolume", 0f);

        }
    }
}
