using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreHolder;

    private void Update()
    {
        scoreHolder.text = GameManagerScript.score.ToString();
    }
    public static void Scoring()
    {
        GameManagerScript.score += 20;
    }
}
