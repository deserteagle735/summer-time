using UnityEngine.UI;
using UnityEngine;

public class ButtonLevelScript : MonoBehaviour {

    public GameObject imageLock;
    public GameObject imageStar;

    public Sprite imageStar0;
    public Sprite imageStar1;
    public Sprite imageStar2;
    public Sprite imageStar3;


    public void LoadButton()
    {
        imageLock.SetActive(false);
        imageStar.SetActive(true);
        int starMaxReached = PlayerPrefs.GetInt("starMaxReached" + 
            this.GetComponent<ButtonLevel>().thisLevel.ToString(), 0);
        if (starMaxReached == 0)
        {
            imageStar.GetComponent<Image>().sprite = imageStar0;
        }
        else if (starMaxReached == 1)
        {
            imageStar.GetComponent<Image>().sprite = imageStar1;
        }
        else if (starMaxReached == 2)
        {
            imageStar.GetComponent<Image>().sprite = imageStar2;
        }
        else if (starMaxReached == 3)
        {
            imageStar.GetComponent<Image>().sprite = imageStar3;
        }
    }

    public void ResetButton()
    {
        imageLock.SetActive(true);
        imageStar.GetComponent<Image>().sprite = imageStar0;
        imageStar.SetActive(false);
    }
}
