using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSceneScript : MonoBehaviour {

    public GameObject panelSettings;

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
}
