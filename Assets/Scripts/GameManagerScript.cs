using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    // Panel in game
    public GameObject panelPreLevel;
    public GameObject panelGamePlay;
    public GameObject panelGameWin;
    public GameObject panelGameOver;
    public GameObject panelPause;
    public GameObject panelSettings;

    // Pre Level Stars
    public GameObject starPreLevel1;
    public GameObject starPreLevel2;
    public GameObject starPreLevel3;

    // Game Win Stars
    public GameObject starGameWin1;
    public GameObject starGameWin2;
    public GameObject starGameWin3;

    public Text levelNameText;

    public GameObject[] cards;
    public Sprite[] cardFaces;
    public Sprite cardBack;
    private List<int> cardsValue;

    public static int score = 0;
    public float fullTime;
    private float timeLeft;
    public float showAllTime = 2f;
    private float _showAllTime;
    public float freezeTimeTime = 5f;
    private float _freezeTimeTime;
    public Text timeText;
    private static bool isFreezing = false;
    private static bool isShowingAll = false;
    public int showAllCount = 1;
    public int freezeTimeCount = 1;
    public Text showAllText;
    public Text freezeTimeText;

    public float threshold3Stars;
    public float threshold2Stars;
    private int starReached;
    private string stringToSaveStars;

    private int cardsDestroyed = 0;

    public int levelNumber;
    private int levelUnlocked;
    private int starMaxReached;

    private static bool isPlaying = false;

    public void ButtonBackInPreLevel()
    {
        TKSceneManager.ChangeScene("PathScene");
    }

    public void ButtonPlayInPreLevel()
    {
        panelPreLevel.SetActive(false);
        panelGamePlay.SetActive(true);
        Play();
    }

    public void ButtonPauseInGamePlay()
    {
        isPlaying = false;
        panelGamePlay.SetActive(false);
        panelPause.SetActive(true);
    }

    public void ButtonSettingsInGamePlay()
    {
        isPlaying = false;
        panelGamePlay.SetActive(false);
        panelSettings.SetActive(true);
    }

    public void ButtonRetryInGameOver()
    {
        Restart();
    }

    public void ButtonBackInGameOver()
    {
        ButtonBackInPreLevel();
    }

    public void ButtonNextInGameWin()
    {
        TKSceneManager.ChangeScene("Level" + levelUnlocked);
    }

    public void ButtonRetryInGameWin()
    {
        Restart();
    }

    public void ButtonBackInGameWin()
    {
        ButtonBackInPreLevel();
    }

    public void ButtonResumeInPause()
    {
        panelPause.SetActive(false);
        panelGamePlay.SetActive(true);
        isPlaying = true;
    }

    public void ButtonRestartInPause()
    {
        Restart();
    }

    public void ButtonBackInPause()
    {
        ButtonBackInPreLevel();
    }

    public void ButtonBackInSettings()
    {
        panelSettings.SetActive(false);
        panelGamePlay.SetActive(true);
        isPlaying = true;
    }

    public void Play()
    {
        panelPreLevel.SetActive(false);
        panelGamePlay.SetActive(true);
        panelGameWin.SetActive(false);
        panelGameOver.SetActive(false);
        panelPause.SetActive(false);
        panelSettings.SetActive(false);
        isPlaying = true;
    }

    public void Restart()
    {
        TKSceneManager.ChangeScene("Level" + levelNumber);
        score = 0;
    }

    private void Shuffle()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cardsValue.Add(i % cardFaces.Length);
        }

        //System.Random rand = new System.Random();

        //for (int i = 0; i < cardsValue.Count; i++)
        //{
        //    int r = i + rand.Next(cards.Length - i);

        //    int temp = cardsValue[r];
        //    cardsValue[r] = cardsValue[i];
        //    cardsValue[i] = temp;
        //}

        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<Card>().cardValue = cardsValue[i];
        }

        foreach (GameObject c in cards)
            c.GetComponent<Card>().SetupCards();
    }

    private void Start()
    {
        levelNameText.text = "Level " + levelNumber;
        levelUnlocked = levelNumber + 1;

        timeLeft = fullTime;
        _freezeTimeTime = freezeTimeTime;
        _showAllTime = showAllTime;

        stringToSaveStars = "starMaxReachedLevel" + levelNumber;
        starMaxReached = PlayerPrefs.GetInt(stringToSaveStars, 0);

        ShowPreLevelStar(starMaxReached);
        
        Shuffle();
    }

    private void Update()
    {
        if (isPlaying == true)
        {
            foreach (GameObject c in cards)
            {
                if (c.GetComponent<Card>().state == 2)
                {
                    cardsDestroyed++;
                    if (c.GetComponent<Card>().isActiveAndEnabled)
                    {
                        c.GetComponent<Card>().DestroyAnimation();

                    }
                }
            }

            if (cardsDestroyed == cards.Length)
            {
                GameWin();
            }
            cardsDestroyed = 0;

            if (!isFreezing)
            {
                timeLeft -= Time.deltaTime;
                timeText.text = "" + Mathf.Round(timeLeft);
                if (timeLeft <= 0f)
                {
                    timeLeft = 0f;
                    GameOver();
                }
            }

            if (isFreezing)
            {
                _freezeTimeTime -= Time.deltaTime;
                if (_freezeTimeTime <= 0f)
                {
                    _freezeTimeTime = freezeTimeTime;
                    isFreezing = false;
                    panelGamePlay.GetComponent<Image>().color = 
                        new Color(1.0f, 1.0f, 1.0f, 0.0f);
                }
            }

            if (isShowingAll)
            {
                _showAllTime -= Time.deltaTime;
                if (_showAllTime <= 0f)
                {
                    _showAllTime = showAllTime;
                    isShowingAll = false;
                    for (int i = 0; i < cards.Length; i++)
                    {
                        if (cards[i].GetComponent<Card>().state != 2)
                        {
                            cards[i].GetComponent<Card>().GetComponent<Image>().sprite = 
                                GetCardFace(cards[i].GetComponent<Card>().cardValue);
                        }
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                CheckCard();
            }
        }
    }

    public void ShowPreLevelStar(int star)
    {
        if (star > 1) starPreLevel1.SetActive(true);
        if (star > 2) starPreLevel2.SetActive(true);
        if (star > 3) starPreLevel3.SetActive(true);
    }

    public void GameOver()
    {
        isPlaying = false;

        panelGamePlay.SetActive(false);
        panelGameOver.SetActive(true);
    }

    public void GameWin()
    {
        panelGamePlay.SetActive(false);
        panelGameWin.SetActive(true);

        starReached = CalculateStars();
        ShowStars(starReached);
        if (starReached > starMaxReached) starMaxReached = starReached;
        PlayerPrefs.SetInt(stringToSaveStars, starMaxReached);
        if (PlayerPrefs.GetInt("levelReached", levelNumber) < levelUnlocked)
        {
            PlayerPrefs.SetInt("levelReached", levelUnlocked);
        }
    }

    int CalculateStars()
    {
        if (timeLeft > threshold3Stars * fullTime) return 3;
        else if (timeLeft > threshold2Stars * fullTime) return 2;
        else return 1;
    }

    void ShowStars(int stars)
    {
        if (stars > 0) starGameWin1.SetActive(true);
        if (stars > 1) starGameWin2.SetActive(true);
        if (stars > 2) starGameWin3.SetActive(true);
    }

    public void CheckCard()
    {
        List<int> c = new List<int>();
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().state == 1)
            {
                c.Add(i);
            }
        }

        if (c.Count == 2) CompareCards(c);
    }

    public void CompareCards(List<int> c)
    {
        if (cards[c[0]].GetComponent<Card>().cardValue ==
                cards[c[1]].GetComponent<Card>().cardValue)
        {
            for (int i = 0; i < 2; i++)
            {
                cards[c[i]].GetComponent<Card>().state = 2;
                cards[c[i]].GetComponent<Card>().DestroyAnimation();

            }
            Score.Scoring();
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                cards[c[i]].GetComponent<Card>().FalseCheck();
            }
        }
    }

    public void ShowAll()
    {
        if (showAllCount > 0)
        {
            isShowingAll = true;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].GetComponent<Card>().state != 2)
                {
                    cards[i].GetComponent<Image>().sprite =
                        GetCardFace(cards[i].GetComponent<Card>().cardValue);
                }
            }

            showAllCount--;
            showAllText.text = "x " + showAllCount;
        }
    }

    public void FreezeTime()
    {
        if (freezeTimeCount > 0)
        {
            isFreezing = true;
            panelGamePlay.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.4f);

            freezeTimeCount--;
            freezeTimeText.text = "x " + freezeTimeCount;
        }
    }

    //public int GetCardValue()
    //{
    //    return cardsValue[];
    //}

    public Sprite GetCardBack()
    {
        return cardBack;
    }

    public Sprite GetCardFace(int i)
    {
        return cardFaces[i];
    }
}
