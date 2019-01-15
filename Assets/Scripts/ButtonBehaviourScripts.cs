using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviourScripts : MonoBehaviour {

    private float resizeParameter = 0.3f;
    private Vector3 resizeVector;

    private void Start()
    {
        resizeVector = new Vector3(resizeParameter, resizeParameter, 0f);
    }

    public void OnPointerEnter()
    {
        if (transform.localScale.Equals(Vector3.one))
        {
            transform.localScale += resizeVector;
        }
    }

    public void OnPointerExit()
    {
        transform.localScale = Vector3.one;
    }
}
