using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour {
    public GameObject panelStart;
    public GameObject panelSettings;
    public Button buttonPlay;
    public Button buttonSettings;

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

 
}
