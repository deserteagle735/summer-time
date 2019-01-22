using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;


public class ButtonBehaviourScripts : EventTrigger
{

    private float resizeParameter = 0.3f;
    private Vector3 resizeVector;

    private void Start()
    {
        resizeVector = new Vector3(resizeParameter, resizeParameter, 0f);
    }

    public override void OnPointerEnter(PointerEventData data)
    {
        if (transform.localScale.Equals(Vector3.one))
        {
            transform.localScale += resizeVector;
        }
    }

    public override void OnPointerExit(PointerEventData data)
    {
        transform.localScale = Vector3.one;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        GameObject.FindGameObjectWithTag("PanelSettings")
                .GetComponent<PanelSettingsScript>().Clicked();
    }
}
