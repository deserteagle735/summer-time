using UnityEngine;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour {

    public bool reset = false;
    public GameObject panelLevel;
    public ButtonLevel[] buttonLevels;
    public Text textStarCounter;
    public Sprite enabledSprite;

    private bool setting = false;
    private bool level = false;

    private int levelReached;
    private int totalStars = 0;

    void Start()
    {
        setting = false;
        level = true;
        if (reset) PlayerPrefs.DeleteAll();

        for (int i = 0; i < buttonLevels.Length; i++)
        {
            int level = i + 1;
            buttonLevels[i].thisLevel = "Level" + level.ToString();
        }

        PlayerPrefs.SetInt("isChangingScene", 0);

        levelReached = PlayerPrefs.GetInt("levelReached", 1);

        int totalStarOutLoop = 0;

        for (int i = 0; i < buttonLevels.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                buttonLevels[i].enabled = false;
            }

            if (buttonLevels[i].enabled)
            {
                buttonLevels[i].image.sprite = enabledSprite;

                int levelButton = i + 1;
                string stringToLoadStars;
                stringToLoadStars = "starMaxReachedLevel" + levelButton;
                int starReached = PlayerPrefs.GetInt(stringToLoadStars, 0);

                totalStarOutLoop += starReached;
                ShowStars(starReached, buttonLevels[i]);
            }
            if (totalStarOutLoop > totalStars) totalStars = totalStarOutLoop;
        }
        textStarCounter.text = "" + totalStars;
    }

    void ShowStars(int stars, ButtonLevel buttonLevel)
    {
        if (stars > 0) buttonLevel.imageStar1.SetActive(true);
        if (stars > 1) buttonLevel.imageStar2.SetActive(true);
        if (stars > 2) buttonLevel.imageStar3.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
