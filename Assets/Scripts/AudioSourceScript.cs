using UnityEngine;
using System;

public class AudioSourceScript : MonoBehaviour {

    public static AudioSourceScript instance;

    public float backgroundMusicVolume = 1f;
    public float soundEffectVolume = 1f;
    public float backgroundMusicSliderValue = 0f;
    public float soundEffectSliderValue = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            PlayerPrefs.SetFloat("backgroundMusicVolume", backgroundMusicVolume);
            PlayerPrefs.SetFloat("backgroundMusicSliderValue", backgroundMusicSliderValue);

            PlayerPrefs.SetFloat("soundEffectVolume", soundEffectVolume);
            PlayerPrefs.SetFloat("soundEffectSliderValue", soundEffectSliderValue);
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
