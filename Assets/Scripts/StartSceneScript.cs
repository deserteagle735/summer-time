using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour {
    public GameObject panelStart;
    public GameObject panelSettings;
    public GameObject panelQuit;
    public Button buttonPlay;
    public Button buttonSettings;

    private void Start()
    {
        AudioManagerScript.instance.Play("BackgroundMusic");
    }

    public void ButtonSettingsOnClick()
    {
        panelStart.SetActive(false);
        panelSettings.SetActive(true);
    }

    public void ButtonBackOnClick()
    {
        
        panelStart.SetActive(true);
    }

    public void ButtonPlayOnClick() 
    {
        TKSceneManager.ChangeScene("PathScene");
    }

    public void ButtonQuit()
    {
        panelQuit.SetActive(true);
    }

    public void ButtonQuitYes()
    {
        Application.Quit();
    }

    public void ButtonQuitNo()
    {
        panelQuit.SetActive(false);
    }
}
