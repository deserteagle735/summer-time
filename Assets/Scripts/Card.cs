using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static bool notFlip = false;
    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = true;

    public Sprite number;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject manager;

    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; }
    }

    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    private void Start()
    {
        _state = 0;
        manager = GameObject.FindGameObjectWithTag("ScriptObject");
        if (!manager) Debug.Log("Game Manager not found");
    }

    public void FlipCard()
    {
        if (_state == 0)
        {
            _state = 1;
            this.GetComponent<Card>().GetComponent<Image>().sprite = _cardFace;
        }
        else if (_state == 1)
        {
            _state = 0;
            this.GetComponent<Card>().GetComponent<Image>().sprite = _cardBack;
        }
    }

    public void SetupCards()
    {
        //_cardValue = manager.GetComponent<GameManagerScript>().GetCardValue();
        _cardBack = manager.GetComponent<GameManagerScript>().GetCardBack();
        _cardFace = manager.GetComponent<GameManagerScript>().GetCardFace(_cardValue);
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
        yield return new WaitForSeconds(0.5f);
        if (_state == 0)
        {
            GetComponent<Image>().sprite = _cardBack;
        }
        else if (_state == 1)
        {
            GetComponent<Image>().sprite = _cardFace;
        }
    }

    public void RevealAnim(float time)
    {
        StartCoroutine(reveal(time));
    }
    IEnumerator reveal(float time)
    {
        GetComponent<Image>().sprite = _cardFace;
        yield return new WaitForSeconds(time);
        GetComponent<Image>().sprite = _cardBack;
    }
}
