using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    SpriteRenderer theSprite;
    public int thisButtonNumber;
    private GameManager theGM;
    public GameObject blueButton, cyanButton, redButton, goldButton, yellowButton, purpleButton, dRedButton, pinkButton, dPinkButton, greenButton, lGreenButton, orangeButton;
    public Sprite blueButtonSelected, cyanButtonSelected, redButtonSelected, goldButtonSelected, yellowButtonSelected, purpleButtonSelected, dRedButtonSelected, pinkButtonSelected, dPinkButtonSelected, greenButtonSelected, lGreenButtonSelected, orangeButtonSelected;
    public GameObject blueButtonCopy, cyanButtonCopy, redButtonCopy, goldButtonCopy, yellowButtonCopy, purpleButtonCopy, dRedButtonCopy, pinkButtonCopy, dPinkButtonCopy, greenButtonCopy, lGreenButtonCopy, orangeButtonCopy;

    public AudioClip dBlue;
    public AudioClip pink;
    public AudioClip yellow;
    public AudioClip dPink;
    public AudioClip dGreen;
    public AudioClip red;
    public AudioClip LGreen;
    public AudioClip purple;
    public AudioClip gold;

    public AudioClip dRed;
    public AudioClip orange;
    public AudioClip cyan;
    // Use this for initialization
    void Start()
    {

        theSprite = GetComponent<SpriteRenderer>();
        theGM = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);
        //theGM.ColourPressed(thisButtonNumber);
        theGM.ColourPressed(thisButtonNumber);

        switch (thisButtonNumber)
        {
            case 0:
                blueButtonSelected = Resources.Load<Sprite>("Selected/selected_blueButton");
                blueButton.GetComponent<SpriteRenderer>().sprite = blueButtonSelected;
                blueButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(dBlue, new Vector3(5, 1, 2));

                blueButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                break;

            case 1:
                pinkButtonSelected = Resources.Load<Sprite>("Selected/selected_pinkButton");
                pinkButton.GetComponent<SpriteRenderer>().sprite = pinkButtonSelected;
                pinkButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(pink, new Vector3(5, 1, 2));

                pinkButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                break;

            case 2:
                yellowButtonSelected = Resources.Load<Sprite>("Selected/selected_yellowButton");
                yellowButton.GetComponent<SpriteRenderer>().sprite = yellowButtonSelected;
                yellowButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(yellow, new Vector3(5, 1, 2));

                yellowButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                break;

            case 3:
                dPinkButtonSelected = Resources.Load<Sprite>("Selected/selected_dPinkButton");
                dPinkButton.GetComponent<SpriteRenderer>().sprite = dPinkButtonSelected;
                dPinkButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(dPink, new Vector3(5, 1, 2));

                dPinkButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                break;

            case 4:
                greenButtonSelected = Resources.Load<Sprite>("Selected/selected_greenButton");
                greenButton.GetComponent<SpriteRenderer>().sprite = greenButtonSelected;
                greenButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(dGreen, new Vector3(5, 1, 2));

                greenButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                break;

            case 5:
                redButtonSelected = Resources.Load<Sprite>("Selected/selected_redButton");
                redButton.GetComponent<SpriteRenderer>().sprite = redButtonSelected;
                redButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(red, new Vector3(5, 1, 2));

                redButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                break;

            case 6:
                lGreenButtonSelected = Resources.Load<Sprite>("Selected/selected_lgreenButton");
                lGreenButton.GetComponent<SpriteRenderer>().sprite = lGreenButtonSelected;
                lGreenButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(dGreen, new Vector3(5, 1, 2));

                lGreenButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);

                break;

            case 7:
                purpleButtonSelected = Resources.Load<Sprite>("Selected/selected_purpleButton");
                purpleButton.GetComponent<SpriteRenderer>().sprite = purpleButtonSelected;
                purpleButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(purple, new Vector3(5, 1, 2));

                purpleButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                break;

            case 8:
                goldButtonSelected = Resources.Load<Sprite>("Selected/selected_goldButton");
                goldButton.GetComponent<SpriteRenderer>().sprite = goldButtonSelected;
                goldButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(gold, new Vector3(5, 1, 2));

                goldButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);

                break;

            case 9:
                dRedButtonSelected = Resources.Load<Sprite>("Selected/selected_dRedButton");
                dRedButton.GetComponent<SpriteRenderer>().sprite = dRedButtonSelected;
                dRedButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(dRed, new Vector3(5, 1, 2));

                dRedButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                break;

            case 10:
                orangeButtonSelected = Resources.Load<Sprite>("Selected/selected_orangeButton");
                orangeButton.GetComponent<SpriteRenderer>().sprite = orangeButtonSelected;
                orangeButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(orange, new Vector3(5, 1, 2));

                orangeButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                break;

            case 11:
                cyanButtonSelected = Resources.Load<Sprite>("Selected/selected_cyanButton");
                cyanButton.GetComponent<SpriteRenderer>().sprite = cyanButtonSelected;
                cyanButtonCopy.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(cyan, new Vector3(5, 1, 2));

                cyanButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                break;
        }
    }

    void OnMouseUp()
    {
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.8f);

        blueButtonSelected = Resources.Load<Sprite>("Normal/blueButton");
        blueButton.GetComponent<SpriteRenderer>().sprite = blueButtonSelected;

        pinkButtonSelected = Resources.Load<Sprite>("Normal/pinkButton");
        pinkButton.GetComponent<SpriteRenderer>().sprite = pinkButtonSelected;

        yellowButtonSelected = Resources.Load<Sprite>("Normal/yellowButton");
        yellowButton.GetComponent<SpriteRenderer>().sprite = yellowButtonSelected;

        dPinkButtonSelected = Resources.Load<Sprite>("Normal/dPinkButton");
        dPinkButton.GetComponent<SpriteRenderer>().sprite = dPinkButtonSelected;

        greenButtonSelected = Resources.Load<Sprite>("Normal/greenButton");
        greenButton.GetComponent<SpriteRenderer>().sprite = greenButtonSelected;

        redButtonSelected = Resources.Load<Sprite>("Normal/redButton");
        redButton.GetComponent<SpriteRenderer>().sprite = redButtonSelected;

        lGreenButtonSelected = Resources.Load<Sprite>("Normal/lgreenButton");
        lGreenButton.GetComponent<SpriteRenderer>().sprite = lGreenButtonSelected;

        purpleButtonSelected = Resources.Load<Sprite>("Normal/purpleButton");
        purpleButton.GetComponent<SpriteRenderer>().sprite = purpleButtonSelected;

        goldButtonSelected = Resources.Load<Sprite>("Normal/goldButton");
        goldButton.GetComponent<SpriteRenderer>().sprite = goldButtonSelected;

        dRedButtonSelected = Resources.Load<Sprite>("Normal/dRedButton");
        dRedButton.GetComponent<SpriteRenderer>().sprite = dRedButtonSelected;

        orangeButtonSelected = Resources.Load<Sprite>("Normal/orangeButton");
        orangeButton.GetComponent<SpriteRenderer>().sprite = orangeButtonSelected;

        cyanButtonSelected = Resources.Load<Sprite>("Normal/cyanButton");
        cyanButton.GetComponent<SpriteRenderer>().sprite = cyanButtonSelected;

        blueButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
        pinkButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
        yellowButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
        dPinkButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
        greenButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
        redButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
        lGreenButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
        purpleButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
        goldButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
        dRedButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
        orangeButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
        cyanButton.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.705f, 0.705f);
    }

}
