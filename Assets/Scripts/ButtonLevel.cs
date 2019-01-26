using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonLevel : Button {

    public Text textLevel;
    public int unlocked;
    public GameObject imageStar1;
    public GameObject imageStar2;
    public GameObject imageStar3;

    private string _thisLevel;

    public override void OnPointerClick(PointerEventData eventData)
    {
        //PlayClickSound();
        base.OnPointerClick(eventData);
        TKSceneManager.ChangeScene(thisLevel);
    }
    public void PlayClickSound()
    {
        GameObject.FindGameObjectWithTag("PanelSettings")
                .GetComponent<PanelSettingsScript>().Clicked();
    }

    public string thisLevel
    {
        get { return _thisLevel; }
        set { _thisLevel = value; }
    }
}
