using UnityEngine;
using UnityEngine.UI;

public class PanelSettingsScript : MonoBehaviour {

    public Slider backroundMusicSlider;
    public Slider soundEffectSlider;

    public Toggle backroundMusicToggle;
    public Toggle soundEffectSliderToggle;
    
    public void Start()
    {
        float backgroundMusicVolume = PlayerPrefs.GetFloat("backgroundMusicVolume", 1f);
        if (backgroundMusicVolume > 0)
        {
            backroundMusicToggle.isOn = true;
            backroundMusicSlider.value = PlayerPrefs.GetFloat("backgroundMusicSliderValue", -5f);
            backroundMusicSlider.interactable = true;
        }
        else
        {
            backroundMusicToggle.isOn = false;
            backroundMusicSlider.value = PlayerPrefs.GetFloat("backgroundMusicSliderValue", -5f);
            backroundMusicSlider.interactable = false;
        }

        float soundEffectVolume = PlayerPrefs.GetFloat("soundEffectVolume", 1f);
        if (soundEffectVolume > 0)
        {
            soundEffectSliderToggle.isOn = true;
            soundEffectSlider.value = PlayerPrefs.GetFloat("soundEffectSliderValue", -5f);
            soundEffectSlider.interactable = true;
        }
        else
        {
            soundEffectSliderToggle.isOn = false;
            soundEffectSlider.value = PlayerPrefs.GetFloat("soundEffectSliderValue", -5f);
            soundEffectSlider.interactable = false;
        }       
    }

    public void SliderBackgroundMusicOnValueChanged(float volume)
    {
        PlayerPrefs.SetFloat("backgroundMusicSliderValue", volume);
        AudioManagerScript.instance.Change();
    }

    public void SliderSoundEffectOnValueChanged(float volume)
    {
        PlayerPrefs.SetFloat("soundEffectSliderValue", volume);
        AudioManagerScript.instance.Change();
    }

    public void ToggleBackgroundMusicOnValueChanged(bool check)
    {
        if (check == true)
        {
            PlayerPrefs.SetFloat("backgroundMusicVolume", 1f);
            AudioManagerScript.instance.Change();
        }
        else
        {           
            PlayerPrefs.SetFloat("backgroundMusicVolume", 0f);
            AudioManagerScript.instance.Change();
        }
    }

    public void ToggleSoundEffectOnValueChanged(bool check)
    {
        if (check == true)
        {
            PlayerPrefs.SetFloat("soundEffectVolume", 1f);
            AudioManagerScript.instance.Change();
        }
        else
        {
            PlayerPrefs.SetFloat("soundEffectVolume", 0f);
            AudioManagerScript.instance.Change();
        }
    }
}
