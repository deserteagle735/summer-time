using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSceneScript : MonoBehaviour {

    public GameObject panelSettings;
    public GameObject panelReset;

	public void ButtonBackClicked()
    {
        TKSceneManager.ChangeScene("StartScene");
    }

    public void ButtonSettingsClicked()
    {
        panelSettings.gameObject.SetActive(true);
    }

    public void ButtonBackInSettingsClicked()
    {
        panelSettings.gameObject.SetActive(false);
    }

    public void ButtonResetAllClicked()
    {
        panelReset.SetActive(true);
    }

    public void ButtonYESClicked()
    {
        GetComponent<LevelManagerScript>().Reset();
        panelReset.SetActive(false);
    }

    public void ButtonNOClicked()
    {
        panelReset.SetActive(false);
    }
}
