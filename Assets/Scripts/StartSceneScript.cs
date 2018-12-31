using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour {
    private GameObject panelStart;
    private GameObject panelSettings;

    private void Start()
    {
        panelStart = GameObject.Find("PanelStart");
        panelSettings = GameObject.Find("PanelSettings");
    }

    public void ButtonSettings()
    {
        panelStart.SetActive(false);
        panelSettings.SetActive(true);
    }

    public void ButtonBack()
    {
        panelStart.SetActive(true);
        panelSettings.SetActive(false);
    }

    public void ButtonPlay() 
    {
        TKSceneManager.ChangeScene("PathScene");
    }
}
