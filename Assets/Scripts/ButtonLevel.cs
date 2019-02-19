using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonLevel : Button {

    public int unlocked;

    private string _thisLevel;

    public override void OnPointerClick(PointerEventData eventData)
    {
        AudioManagerScript.instance.Clicked();
        base.OnPointerClick(eventData);
        TKSceneManager.ChangeScene(thisLevel);
    }

    public string thisLevel
    {
        get { return _thisLevel; }
        set { _thisLevel = value; }
    }
}
