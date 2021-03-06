﻿using UnityEngine;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour {

    public GameObject panelLevel;
    public GameObject[] buttonLevels;
    public Text textStarCounter;

    void Start()
    {
        for (int i = 0; i < buttonLevels.Length; i++)
        {
            int level = i + 1;
            buttonLevels[i].GetComponent<ButtonLevel>().thisLevel = "Level" + level.ToString();
        }
        LoadLevel();
    }

    public void LoadLevel()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        int totalStarsCounter = 0;

        for (int i = 0; i < buttonLevels.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                buttonLevels[i].GetComponent<ButtonLevel>().enabled = false;
            }
            else
            {
                buttonLevels[i].GetComponent<ButtonLevel>().enabled = true;
                buttonLevels[i].GetComponent<ButtonLevelScript>().LoadButton();

                int level = i + 1;
                string stringToLoadStars = "starMaxReachedLevel" + level;
                int starReached = PlayerPrefs.GetInt(stringToLoadStars, 0);

                totalStarsCounter += starReached;
            }
        }
        int totalStars = PlayerPrefs.GetInt("totalStars", 0);

        if (totalStarsCounter > totalStars) totalStars = totalStarsCounter;
        PlayerPrefs.SetInt("totalStars", totalStars);
        textStarCounter.text = totalStars.ToString();
    }

    public void Reset()
    {
        for (int i = 0; i < buttonLevels.Length; i++)
        {            
            buttonLevels[i].GetComponent<ButtonLevelScript>().ResetButton();
            int level = i + 1;
            string stringToLoadStars = "starMaxReachedLevel" + level;
            PlayerPrefs.SetInt(stringToLoadStars, 0);
            buttonLevels[i].GetComponent<ButtonLevel>().enabled = false;
        }
        PlayerPrefs.SetInt("levelReached", 1);
        PlayerPrefs.SetInt("totalStars", 0);
        LoadLevel();
    }
}
