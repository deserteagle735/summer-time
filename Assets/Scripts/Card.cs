using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Sprite number;     

    private GameManagerScript manager;
    private Sprite cardBack;
    private Sprite cardFace;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private int _state;
    
    public int state { get { return _state; } set { _state = value; } }        
    public int cardValue { get { return _cardValue; } set { _cardValue = value; } }

    private void Start()
    {
        _state = 0;
    }

    public void SetupCard()
    {
        //cardBack = manager.GetComponent<GameManagerScript>().GetCardBack();
        cardBack = GameObject.FindGameObjectWithTag("ScriptObject")
                        .GetComponent<GameManagerScript>().GetCardBack();
        //cardFace = manager.GetComponent<GameManagerScript>().GetCardFace(_cardValue);
        cardFace = GameObject.FindGameObjectWithTag("ScriptObject")
                        .GetComponent<GameManagerScript>().GetCardFace(_cardValue);
        _state = 0;
    }

    public void FlipCard()
    {
        if (_state == 0)
        {
            _state = 1;
            GetComponent<Image>().sprite = cardFace;
        }
        else if (_state == 1 || _state == 3)
        {
            _state = 0;
            GetComponent<Image>().sprite = cardBack;
        }
    }

    public void DestroyAnimation()
    {
        StartCoroutine(DestroyCard());
    }

    IEnumerator DestroyCard()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        gameObject.GetComponent<Image>().sprite = number;
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);

    }

    public void FalseCheck()
    {
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        _state = 3;
        yield return new WaitForSeconds(0.3f);
        FlipCard();
    }

    public void RevealAnim(float time)
    {
        StartCoroutine(reveal(time));
    }
    IEnumerator reveal(float time)
    {
        GetComponent<Image>().sprite = cardFace;
        yield return new WaitForSeconds(time);
        GetComponent<Image>().sprite = cardBack;
        GetComponent<Image>().sprite = cardBack;
    }
}
