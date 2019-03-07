using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.Advertisements;
using System;

public class GameManager : MonoBehaviour
{
    public float speed;

    public Image UIBackground;
    public AudioClip IntroSound;
    public AudioClip DeathSound;
    public AudioClip wrong;
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



    public SpriteRenderer[] colours;
    private int colourSelect, firstColor;
    public ScoreManager script;
    public float stayLit;
    private float stayLitCounter;
    public float waitBetweenLights;
    private float waitBetweenCounter;
    public bool gameHasBegun, gameHasEnded, gameIsAboutToEnd;
    private bool shouldBeDark, shouldBeLit, gameActive, turnOn, premium, TurnOnTrail, enableTrail;
    private bool isFirstColor, isTheNextRound, gameIsAboutToBegin, gameIsAboutToBeginHandler, activateFirstColor, gameIsAboutToEndHandler, makingSequence;

    public List<int> activeSequence;
    private int positionInSequence;
    private int inputInSequence;

    public GameObject blueButton, cyanButton, redButton, goldButton, yellowButton, purpleButton,
    dRedButton, pinkButton, dPinkButton, greenButton, lGreenButton, orangeButton;

    public Sprite blueButtonSelected, cyanButtonSelected, redButtonSelected, goldButtonSelected, yellowButtonSelected, purpleButtonSelected, dRedButtonSelected, pinkButtonSelected, dPinkButtonSelected, greenButtonSelected, lGreenButtonSelected, orangeButtonSelected;

    public GameObject blueButtonCopy, cyanButtonCopy, redButtonCopy, goldButtonCopy, yellowButtonCopy, purpleButtonCopy, dRedButtonCopy, pinkButtonCopy, dPinkButtonCopy, greenButtonCopy, lGreenButtonCopy, orangeButtonCopy;

    public GameObject SliderCircle;
    public GameObject PanelGameScene, PanelGameOver, panelGrayButtons, menuFredStore;
    public TextMeshProUGUI currentScore;
    public Slider mainSlider;
    AudioSource audioSource;
    public bool loginSuccessful;
    System.Action<bool> callback;
    public LeaderboardManager leaderboardManager;
    public int score;
    public Sprite trailOnSprite, trailOffSprite;
    public GameObject trailDot, trailPixel, trailObject, buyTrailButton, activateTrailButton, buttonRestorePurchase;

    //private GameObject rowFirst, rowSecond, rowThird, rowFourth;

    private GameObject[] rowFirst;
    private GameObject[] rowSecond;
    private GameObject[] rowThird;
    private GameObject[] rowFourth;

    private GameObject[] rowFirstGameOver;
    private GameObject[] rowSecondGameOver;
    private GameObject[] rowThirdGameOver;
    private GameObject[] rowFourthGameOver;

    bool state, disableMainMenuButton;

    public bool stateTrail;

    private float inputTimer;
    int NumGame;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        inputTimer = 0;
        stateTrail = Convert.ToBoolean(PlayerPrefs.GetInt("stateTrail"));
        NumGame = PlayerPrefs.GetInt("NumGame");
        premium = GameObject.Find("RemoveAds").GetComponent<PurchaserManager>().Adfree;
        enableTrail = GameObject.Find("RemoveAds").GetComponent<PurchaserManager>().EnableTrail;

        if (stateTrail == true && enableTrail == true)
        {
            trailPixel.gameObject.SetActive(true);
            trailOnSprite = Resources.Load<Sprite>("Icons/TrailTurnedOn");
            trailObject.GetComponent<SpriteRenderer>().sprite = trailOnSprite;

            PlayerPrefs.SetInt("stateTrail", Convert.ToInt32(stateTrail));

            // print("Se activo");
        }
        else
        {
            trailPixel.gameObject.SetActive(false);
            trailOnSprite = Resources.Load<Sprite>("Icons/TrailTurnedOff");
            trailObject.GetComponent<SpriteRenderer>().sprite = trailOnSprite;
            PlayerPrefs.SetInt("stateTrail", Convert.ToInt32(stateTrail));
        }
        if (NumGame % 3 == 0 && premium == false)
        {
            Advertisement.Show();

        }



#if UNITY_IOS
        SignIn(callback);
#endif

        audioSource = GetComponent<AudioSource>();

        blueButton.GetComponent<BoxCollider2D>().enabled = false;
        cyanButton.GetComponent<BoxCollider2D>().enabled = false;
        redButton.GetComponent<BoxCollider2D>().enabled = false;
        goldButton.GetComponent<BoxCollider2D>().enabled = false;
        yellowButton.GetComponent<BoxCollider2D>().enabled = false;
        purpleButton.GetComponent<BoxCollider2D>().enabled = false;
        dRedButton.GetComponent<BoxCollider2D>().enabled = false;
        pinkButton.GetComponent<BoxCollider2D>().enabled = false;
        dPinkButton.GetComponent<BoxCollider2D>().enabled = false;
        greenButton.GetComponent<BoxCollider2D>().enabled = false;
        lGreenButton.GetComponent<BoxCollider2D>().enabled = false;
        orangeButton.GetComponent<BoxCollider2D>().enabled = false;

        makingSequence = true;

    }

    void Update()
    {

        if (Input.touchCount == 0 && gameActive)
        {
            inputTimer += Time.deltaTime;
            // print("entró");
        }
        else
        {
            inputTimer = 0;
        }
        // print("TIMER " + inputTimer);
        if (inputTimer >= 10f && !isTheNextRound)
        {
            print("marchaste men");
            activeSequence.Clear();
            gameActive = false;
            gameHasEnded = true;
            SliderCircle.gameObject.SetActive(true);
            gameHasBegun = false;

#if UNITY_ANDROID
            if (PlayGamesPlatform.Instance.IsAuthenticated())
            {
                // Note: make sure to add 'using GooglePlayGames'
                PlayGamesPlatform.Instance.ReportScore(score,
                    GPGSIds.leaderboard_top_players,
                    (bool success) =>
                    {
                        Debug.Log("(Lollygagger) Leaderboard update success: " + success);
                        Debug.Log("Score mandado " + score);
                    });
            }
#endif

#if UNITY_IOS
   PostScoreOnLeaderBoard(score);
#endif

            blueButton.GetComponent<BoxCollider2D>().enabled = false;
            cyanButton.GetComponent<BoxCollider2D>().enabled = false;
            redButton.GetComponent<BoxCollider2D>().enabled = false;
            goldButton.GetComponent<BoxCollider2D>().enabled = false;
            yellowButton.GetComponent<BoxCollider2D>().enabled = false;
            purpleButton.GetComponent<BoxCollider2D>().enabled = false;
            dRedButton.GetComponent<BoxCollider2D>().enabled = false;
            pinkButton.GetComponent<BoxCollider2D>().enabled = false;
            dPinkButton.GetComponent<BoxCollider2D>().enabled = false;
            greenButton.GetComponent<BoxCollider2D>().enabled = false;
            lGreenButton.GetComponent<BoxCollider2D>().enabled = false;
            orangeButton.GetComponent<BoxCollider2D>().enabled = false;
        }

        premium = GameObject.Find("RemoveAds").GetComponent<PurchaserManager>().Adfree;
        enableTrail = GameObject.Find("RemoveAds").GetComponent<PurchaserManager>().EnableTrail;


        if (enableTrail == true)
        {
            buyTrailButton.gameObject.SetActive(false);
            activateTrailButton.gameObject.SetActive(true);
        }
        else
        {
            buyTrailButton.gameObject.SetActive(true);
            activateTrailButton.gameObject.SetActive(false);
        }

        if (premium)
        {
            AdMob.bannerView.Destroy();
        }

        if (premium == false)
        {
            //  GameObject.FindGameObjectsWithTag("RowFirst").localPosition = new Vector3(0, 0, 0);
            rowFirst = GameObject.FindGameObjectsWithTag("RowFirst");
            foreach (GameObject a in rowFirst)
                a.transform.localPosition = new Vector3(a.transform.localPosition.x, 470, a.transform.localPosition.z);

            rowSecond = GameObject.FindGameObjectsWithTag("RowSecond");
            foreach (GameObject b in rowSecond)
                b.transform.localPosition = new Vector3(b.transform.localPosition.x, 120, b.transform.localPosition.z);

            rowThird = GameObject.FindGameObjectsWithTag("RowThird");
            foreach (GameObject c in rowThird)
                c.transform.localPosition = new Vector3(c.transform.localPosition.x, -239, c.transform.localPosition.z);

            rowFourth = GameObject.FindGameObjectsWithTag("RowFourth");
            foreach (GameObject d in rowFourth)
                d.transform.localPosition = new Vector3(d.transform.localPosition.x, -600, d.transform.localPosition.z);



            //Panel game over objects

            rowFirstGameOver = GameObject.FindGameObjectsWithTag("RowFirstGameOver");
            foreach (GameObject e in rowFirstGameOver)
                e.transform.localPosition = new Vector3(e.transform.localPosition.x, 654, e.transform.localPosition.z);

            rowSecondGameOver = GameObject.FindGameObjectsWithTag("RowSecondGameOver");
            foreach (GameObject f in rowSecondGameOver)
                f.transform.localPosition = new Vector3(f.transform.localPosition.x, 304, f.transform.localPosition.z);

            rowThirdGameOver = GameObject.FindGameObjectsWithTag("RowThirdGameOver");
            foreach (GameObject g in rowThirdGameOver)
                g.transform.localPosition = new Vector3(g.transform.localPosition.x, -54.5f, g.transform.localPosition.z);

            rowFourthGameOver = GameObject.FindGameObjectsWithTag("RowFourthGameOver");
            foreach (GameObject h in rowFourthGameOver)
                h.transform.localPosition = new Vector3(h.transform.localPosition.x, -416, h.transform.localPosition.z);

            UIBackground = GameObject.Find("PanelBackground").GetComponent<Image>();
            UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/BackgroundAds");

        }
        else
        {

        }

        score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;

        gameIsAboutToBeginHandler = GameObject.Find("Slider").GetComponent<DragHandler>().gameIsAboutToBegin;
        gameIsAboutToEnd = GameObject.Find("Slider").GetComponent<DragHandler>().gameIsAboutToEnd;

        if (gameIsAboutToBegin == true && gameIsAboutToBeginHandler)
        {
            StartGame();
        }

        if (shouldBeLit)
        {
            colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f);

            if (turnOn == true)
            {
                audioSource = GetComponent<AudioSource>();

                switch (activeSequence[0])
                {
                    case 0:
                        AudioSource.PlayClipAtPoint(dBlue, transform.position, 1f);
                        StartCoroutine(MoveDot(blueButton));
                        break;

                    case 1:
                        AudioSource.PlayClipAtPoint(pink, transform.position, 1f);
                        StartCoroutine(MoveDot(pinkButton));
                        break;

                    case 2:
                        AudioSource.PlayClipAtPoint(yellow, transform.position, 1f);
                        StartCoroutine(MoveDot(yellowButton));
                        break;

                    case 3:
                        AudioSource.PlayClipAtPoint(dPink, transform.position, 1f);
                        StartCoroutine(MoveDot(dPinkButton));
                        break;

                    case 4:
                        AudioSource.PlayClipAtPoint(dGreen, transform.position, 1f);
                        StartCoroutine(MoveDot(greenButton));
                        break;

                    case 5:
                        AudioSource.PlayClipAtPoint(red, transform.position, 1f);
                        StartCoroutine(MoveDot(redButton));
                        break;

                    case 6:
                        AudioSource.PlayClipAtPoint(LGreen, transform.position, 1f);
                        StartCoroutine(MoveDot(lGreenButton));
                        break;

                    case 7:
                        AudioSource.PlayClipAtPoint(purple, transform.position, 1f);
                        StartCoroutine(MoveDot(purpleButton));
                        break;

                    case 8:
                        AudioSource.PlayClipAtPoint(gold, transform.position, 1f);
                        StartCoroutine(MoveDot(goldButton));
                        break;

                    case 9:
                        AudioSource.PlayClipAtPoint(dRed, transform.position, 1f);
                        StartCoroutine(MoveDot(dRedButton));
                        break;

                    case 10:
                        AudioSource.PlayClipAtPoint(orange, transform.position, 1f);
                        StartCoroutine(MoveDot(orangeButton));
                        break;

                    case 11:
                        AudioSource.PlayClipAtPoint(cyan, transform.position, 1f);
                        StartCoroutine(MoveDot(cyanButton));
                        break;
                }
                turnOn = false;
            }



            if (isTheNextRound == true)
            {

                switch (activeSequence[0])
                {
                    case 0:
                        blueButtonSelected = Resources.Load<Sprite>("Selected/selected_blueButton");
                        blueButton.GetComponent<SpriteRenderer>().sprite = blueButtonSelected;


                        blueButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;

                    case 1:
                        pinkButtonSelected = Resources.Load<Sprite>("Selected/selected_pinkButton");
                        pinkButton.GetComponent<SpriteRenderer>().sprite = pinkButtonSelected;


                        pinkButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;

                    case 2:
                        yellowButtonSelected = Resources.Load<Sprite>("Selected/selected_yellowButton");
                        yellowButton.GetComponent<SpriteRenderer>().sprite = yellowButtonSelected;


                        yellowButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;

                    case 3:
                        dPinkButtonSelected = Resources.Load<Sprite>("Selected/selected_dPinkButton");
                        dPinkButton.GetComponent<SpriteRenderer>().sprite = dPinkButtonSelected;


                        dPinkButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;

                    case 4:
                        greenButtonSelected = Resources.Load<Sprite>("Selected/selected_greenButton");
                        greenButton.GetComponent<SpriteRenderer>().sprite = greenButtonSelected;


                        greenButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;

                    case 5:
                        redButtonSelected = Resources.Load<Sprite>("Selected/selected_redButton");
                        redButton.GetComponent<SpriteRenderer>().sprite = redButtonSelected;


                        redButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;

                    case 6:
                        lGreenButtonSelected = Resources.Load<Sprite>("Selected/selected_lgreenButton");
                        lGreenButton.GetComponent<SpriteRenderer>().sprite = lGreenButtonSelected;


                        lGreenButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;

                    case 7:
                        purpleButtonSelected = Resources.Load<Sprite>("Selected/selected_purpleButton");
                        purpleButton.GetComponent<SpriteRenderer>().sprite = purpleButtonSelected;


                        purpleButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;

                    case 8:
                        goldButtonSelected = Resources.Load<Sprite>("Selected/selected_goldButton");
                        goldButton.GetComponent<SpriteRenderer>().sprite = goldButtonSelected;


                        goldButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;

                    case 9:
                        dRedButtonSelected = Resources.Load<Sprite>("Selected/selected_dRedButton");
                        dRedButton.GetComponent<SpriteRenderer>().sprite = dRedButtonSelected;


                        dRedButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;

                    case 10:
                        orangeButtonSelected = Resources.Load<Sprite>("Selected/selected_orangeButton");
                        orangeButton.GetComponent<SpriteRenderer>().sprite = orangeButtonSelected;


                        orangeButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;

                    case 11:
                        cyanButtonSelected = Resources.Load<Sprite>("Selected/selected_cyanButton");
                        cyanButton.GetComponent<SpriteRenderer>().sprite = cyanButtonSelected;


                        cyanButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                        break;
                }
            }


            stayLitCounter -= Time.deltaTime;
            //  print("STAY LIT COUNTER" + stayLitCounter);

            if (stayLitCounter < 0)
            {
                colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 0.8f);

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

                shouldBeLit = false;
                shouldBeDark = true;
                isTheNextRound = false;


                waitBetweenCounter = waitBetweenLights;
                positionInSequence++;
                // print("Should be Lit " + shouldBeLit);


            }
        }

        if (shouldBeDark)
        {
            waitBetweenCounter -= Time.deltaTime;

            if (positionInSequence >= activeSequence.Count)
            {
                shouldBeDark = false;
                gameActive = true;
                turnOn = true;

                blueButton.GetComponent<BoxCollider2D>().enabled = true;
                cyanButton.GetComponent<BoxCollider2D>().enabled = true;
                redButton.GetComponent<BoxCollider2D>().enabled = true;
                goldButton.GetComponent<BoxCollider2D>().enabled = true;
                yellowButton.GetComponent<BoxCollider2D>().enabled = true;
                purpleButton.GetComponent<BoxCollider2D>().enabled = true;
                dRedButton.GetComponent<BoxCollider2D>().enabled = true;
                pinkButton.GetComponent<BoxCollider2D>().enabled = true;
                dPinkButton.GetComponent<BoxCollider2D>().enabled = true;
                greenButton.GetComponent<BoxCollider2D>().enabled = true;
                lGreenButton.GetComponent<BoxCollider2D>().enabled = true;
                orangeButton.GetComponent<BoxCollider2D>().enabled = true;
                // print("PUEDES DAR CLICK");

                if (activateFirstColor == true)
                {
                    colours[activeSequence[0]].gameObject.SetActive(true);

                }

            }
            else
            {
                if (waitBetweenCounter < 0)
                {

                    colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f);
                    //  print("COLORSIN: " + activeSequence[positionInSequence]);

                    // print("PRIMER POSICIÓN:" + colours[activeSequence[0]]);


                    activateFirstColor = true;

                    if (activateFirstColor == true)
                    {
                        colours[activeSequence[0]].gameObject.SetActive(true);
                    }

                    switch (firstColor)
                    {
                        case 0:
                            blueButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            blueButtonCopy.gameObject.SetActive(true);
                            print("COPY 0");

                            break;

                        case 1:
                            pinkButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            pinkButtonCopy.gameObject.SetActive(true);
                            print("COPY 1");
                            break;

                        case 2:
                            yellowButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            yellowButtonCopy.gameObject.SetActive(true);
                            print("COPY 2");
                            break;

                        case 3:
                            dPinkButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            dPinkButtonCopy.gameObject.SetActive(true);
                            print("COPY 3");
                            break;

                        case 4:
                            greenButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            greenButtonCopy.gameObject.SetActive(true);
                            print("COPY 4");
                            break;

                        case 5:
                            redButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            redButtonCopy.gameObject.SetActive(true);
                            print("COPY 5");
                            break;

                        case 6:
                            lGreenButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            lGreenButtonCopy.gameObject.SetActive(true);
                            print("COPY 6");
                            break;

                        case 7:
                            purpleButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            purpleButtonCopy.gameObject.SetActive(true);
                            print("COPY 7");
                            break;

                        case 8:
                            goldButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            goldButtonCopy.gameObject.SetActive(true);
                            print("COPY 8");
                            break;

                        case 9:
                            dRedButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            dRedButtonCopy.gameObject.SetActive(true);
                            print("COPY 9");
                            break;

                        case 10:
                            orangeButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            orangeButtonCopy.gameObject.SetActive(true);
                            print("COPY 10");
                            break;

                        case 11:
                            cyanButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                            cyanButtonCopy.gameObject.SetActive(true);
                            print("COPY 11");
                            break;
                    }


                    switch (activeSequence[positionInSequence])
                    {

                        case 0:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                blueButtonSelected = Resources.Load<Sprite>("Selected/selected_blueButton");
                                blueButton.GetComponent<SpriteRenderer>().sprite = blueButtonSelected;
                                blueButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(dBlue, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                blueButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(blueButton));
                            }
                            else
                            {
                                blueButtonSelected = Resources.Load<Sprite>("Selected/selected_blueButton");
                                blueButton.GetComponent<SpriteRenderer>().sprite = blueButtonSelected;
                                blueButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(dBlue, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                blueButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 0");
                                StartCoroutine(MoveDot(blueButton));
                            }

                            break;

                        case 1:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                pinkButtonSelected = Resources.Load<Sprite>("Selected/selected_pinkButton");
                                pinkButton.GetComponent<SpriteRenderer>().sprite = pinkButtonSelected;
                                pinkButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(pink, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                pinkButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(pinkButton));

                            }
                            else
                            {
                                pinkButtonSelected = Resources.Load<Sprite>("Selected/selected_pinkButton");
                                pinkButton.GetComponent<SpriteRenderer>().sprite = pinkButtonSelected;
                                pinkButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(pink, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                pinkButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 1");
                                StartCoroutine(MoveDot(pinkButton));
                            }

                            break;

                        case 2:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                yellowButtonSelected = Resources.Load<Sprite>("Selected/selected_yellowButton");
                                yellowButton.GetComponent<SpriteRenderer>().sprite = yellowButtonSelected;
                                yellowButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(yellow, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                yellowButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(yellowButton));
                            }
                            else
                            {
                                yellowButtonSelected = Resources.Load<Sprite>("Selected/selected_yellowButton");
                                yellowButton.GetComponent<SpriteRenderer>().sprite = yellowButtonSelected;
                                yellowButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(yellow, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                yellowButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 2");
                                StartCoroutine(MoveDot(yellowButton));
                            }

                            break;

                        case 3:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                dPinkButtonSelected = Resources.Load<Sprite>("Selected/selected_dPinkButton");
                                dPinkButton.GetComponent<SpriteRenderer>().sprite = dPinkButtonSelected;
                                dPinkButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(dPink, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                dPinkButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(dPinkButton));
                            }
                            else
                            {
                                dPinkButtonSelected = Resources.Load<Sprite>("Selected/selected_dPinkButton");
                                dPinkButton.GetComponent<SpriteRenderer>().sprite = dPinkButtonSelected;
                                dPinkButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(dPink, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                dPinkButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 3");
                                StartCoroutine(MoveDot(dPinkButton));
                            }

                            break;

                        case 4:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                greenButtonSelected = Resources.Load<Sprite>("Selected/selected_greenButton");
                                greenButton.GetComponent<SpriteRenderer>().sprite = greenButtonSelected;
                                greenButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(dGreen, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                greenButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(greenButton));
                            }
                            else
                            {
                                greenButtonSelected = Resources.Load<Sprite>("Selected/selected_greenButton");
                                greenButton.GetComponent<SpriteRenderer>().sprite = greenButtonSelected;
                                greenButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(dGreen, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                greenButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 4");
                                StartCoroutine(MoveDot(greenButton));
                            }

                            break;

                        case 5:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                redButtonSelected = Resources.Load<Sprite>("Selected/selected_redButton");
                                redButton.GetComponent<SpriteRenderer>().sprite = redButtonSelected;
                                redButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(red, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                redButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(redButton));
                            }
                            else
                            {
                                redButtonSelected = Resources.Load<Sprite>("Selected/selected_redButton");
                                redButton.GetComponent<SpriteRenderer>().sprite = redButtonSelected;
                                redButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(red, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                redButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 5");
                                StartCoroutine(MoveDot(redButton));
                            }

                            break;

                        case 6:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                lGreenButtonSelected = Resources.Load<Sprite>("Selected/selected_lgreenButton");
                                lGreenButton.GetComponent<SpriteRenderer>().sprite = lGreenButtonSelected;
                                lGreenButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(dGreen, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                lGreenButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(lGreenButton));
                            }
                            else
                            {
                                lGreenButtonSelected = Resources.Load<Sprite>("Selected/selected_lgreenButton");
                                lGreenButton.GetComponent<SpriteRenderer>().sprite = lGreenButtonSelected;
                                lGreenButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(dGreen, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                lGreenButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 6");
                                StartCoroutine(MoveDot(lGreenButton));
                            }


                            break;

                        case 7:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                purpleButtonSelected = Resources.Load<Sprite>("Selected/selected_purpleButton");
                                purpleButton.GetComponent<SpriteRenderer>().sprite = purpleButtonSelected;
                                purpleButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(purple, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                purpleButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(purpleButton));
                            }
                            else
                            {
                                purpleButtonSelected = Resources.Load<Sprite>("Selected/selected_purpleButton");
                                purpleButton.GetComponent<SpriteRenderer>().sprite = purpleButtonSelected;
                                purpleButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(purple, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                purpleButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 7");
                                StartCoroutine(MoveDot(purpleButton));
                            }

                            break;

                        case 8:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                goldButtonSelected = Resources.Load<Sprite>("Selected/selected_goldButton");
                                goldButton.GetComponent<SpriteRenderer>().sprite = goldButtonSelected;
                                goldButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(gold, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                goldButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(goldButton));
                            }
                            else
                            {
                                goldButtonSelected = Resources.Load<Sprite>("Selected/selected_goldButton");
                                goldButton.GetComponent<SpriteRenderer>().sprite = goldButtonSelected;
                                goldButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(gold, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                goldButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 8");
                                StartCoroutine(MoveDot(goldButton));
                            }


                            break;

                        case 9:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                dRedButtonSelected = Resources.Load<Sprite>("Selected/selected_dRedButton");
                                dRedButton.GetComponent<SpriteRenderer>().sprite = dRedButtonSelected;
                                dRedButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(dRed, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                dRedButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(dRedButton));
                            }
                            else
                            {
                                dRedButtonSelected = Resources.Load<Sprite>("Selected/selected_dRedButton");
                                dRedButton.GetComponent<SpriteRenderer>().sprite = dRedButtonSelected;
                                dRedButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(dRed, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                dRedButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 9");
                                StartCoroutine(MoveDot(dRedButton));
                            }

                            break;

                        case 10:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                orangeButtonSelected = Resources.Load<Sprite>("Selected/selected_orangeButton");
                                orangeButton.GetComponent<SpriteRenderer>().sprite = orangeButtonSelected;
                                orangeButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(orange, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                orangeButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(orangeButton));
                            }
                            else
                            {
                                orangeButtonSelected = Resources.Load<Sprite>("Selected/selected_orangeButton");
                                orangeButton.GetComponent<SpriteRenderer>().sprite = orangeButtonSelected;
                                orangeButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(orange, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                orangeButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 10");
                                StartCoroutine(MoveDot(orangeButton));
                            }

                            break;

                        case 11:
                            if (activeSequence[positionInSequence] == firstColor)
                            {
                                cyanButtonSelected = Resources.Load<Sprite>("Selected/selected_cyanButton");
                                cyanButton.GetComponent<SpriteRenderer>().sprite = cyanButtonSelected;
                                cyanButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(cyan, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(true);
                                cyanButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                StartCoroutine(MoveDot(cyanButton));
                            }
                            else
                            {
                                cyanButtonSelected = Resources.Load<Sprite>("Selected/selected_cyanButton");
                                cyanButton.GetComponent<SpriteRenderer>().sprite = cyanButtonSelected;
                                cyanButtonCopy.gameObject.SetActive(false);
                                AudioSource.PlayClipAtPoint(cyan, transform.position, 1f);
                                colours[activeSequence[0]].gameObject.SetActive(false);
                                cyanButton.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                                print("BRIGHT 11");
                                StartCoroutine(MoveDot(cyanButton));
                            }

                            break;

                    }


                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    shouldBeDark = false;
                    isTheNextRound = true;
                    activateFirstColor = true;

                }
            }
        }
    }


    IEnumerator MoveDot(GameObject newPostion)
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            trailPixel.transform.position = Vector3.Lerp(trailPixel.transform.position, newPostion.gameObject.transform.position, timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (trailPixel.transform.position == newPostion.gameObject.transform.position)
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }

    public void StartGame()
    {
        gameHasBegun = true;

        currentScore.gameObject.SetActive(true);
        AudioSource.PlayClipAtPoint(IntroSound, transform.position, 150f);
        StartCoroutine(ExecuteAfterTime(1.6f));
        gameIsAboutToBegin = false;

        if (premium == false)
        {
            //  GameObject.FindGameObjectsWithTag("RowFirst").localPosition = new Vector3(0, 0, 0);
            rowFirst = GameObject.FindGameObjectsWithTag("RowFirst");
            foreach (GameObject a in rowFirst)
                a.transform.localPosition = new Vector3(a.transform.localPosition.x, 470, a.transform.localPosition.z);

            rowSecond = GameObject.FindGameObjectsWithTag("RowSecond");
            foreach (GameObject b in rowSecond)
                b.transform.localPosition = new Vector3(b.transform.localPosition.x, 120, b.transform.localPosition.z);

            rowThird = GameObject.FindGameObjectsWithTag("RowThird");
            foreach (GameObject c in rowThird)
                c.transform.localPosition = new Vector3(c.transform.localPosition.x, -239, c.transform.localPosition.z);

            rowFourth = GameObject.FindGameObjectsWithTag("RowFourth");
            foreach (GameObject d in rowFourth)
                d.transform.localPosition = new Vector3(d.transform.localPosition.x, -600, d.transform.localPosition.z);



        }

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        //print("The Game Has Begun");
        GameObject buttonMainMenu = GameObject.Find("ButtonMainMenu");
        buttonMainMenu.GetComponent<Button>().enabled = false;
        SliderCircle.gameObject.SetActive(false);
        //activeSequence.Clear();
        blueButton.GetComponent<BoxCollider2D>().enabled = true;
        cyanButton.GetComponent<BoxCollider2D>().enabled = true;
        redButton.GetComponent<BoxCollider2D>().enabled = true;
        goldButton.GetComponent<BoxCollider2D>().enabled = true;
        yellowButton.GetComponent<BoxCollider2D>().enabled = true;
        purpleButton.GetComponent<BoxCollider2D>().enabled = true;
        dRedButton.GetComponent<BoxCollider2D>().enabled = true;
        pinkButton.GetComponent<BoxCollider2D>().enabled = true;
        dPinkButton.GetComponent<BoxCollider2D>().enabled = true;
        greenButton.GetComponent<BoxCollider2D>().enabled = true;
        lGreenButton.GetComponent<BoxCollider2D>().enabled = true;
        orangeButton.GetComponent<BoxCollider2D>().enabled = true;
        positionInSequence = 0;
        inputInSequence = 0;

        colourSelect = UnityEngine.Random.Range(0, colours.Length);

        activeSequence.Add(colourSelect);

        colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f);
        //print("FIRST COLOR: " + activeSequence[positionInSequence]);

        firstColor = activeSequence[positionInSequence];
        switch (activeSequence[positionInSequence])
        {
            case 0:
                blueButtonSelected = Resources.Load<Sprite>("Selected/selected_blueButton");
                blueButton.GetComponent<SpriteRenderer>().sprite = blueButtonSelected;
                AudioSource.PlayClipAtPoint(dBlue, new Vector3(5, 1, 2));
                blueButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(blueButton));
                break;

            case 1:
                pinkButtonSelected = Resources.Load<Sprite>("Selected/selected_pinkButton");
                pinkButton.GetComponent<SpriteRenderer>().sprite = pinkButtonSelected;
                AudioSource.PlayClipAtPoint(pink, new Vector3(5, 1, 2));
                pinkButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(pinkButton));
                break;

            case 2:
                yellowButtonSelected = Resources.Load<Sprite>("Selected/selected_yellowButton");
                yellowButton.GetComponent<SpriteRenderer>().sprite = yellowButtonSelected;
                AudioSource.PlayClipAtPoint(yellow, new Vector3(5, 1, 2));
                yellowButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(yellowButton));
                break;

            case 3:
                dPinkButtonSelected = Resources.Load<Sprite>("Selected/selected_dPinkButton");
                dPinkButton.GetComponent<SpriteRenderer>().sprite = dPinkButtonSelected;
                AudioSource.PlayClipAtPoint(dPink, new Vector3(5, 1, 2));
                dPinkButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(dPinkButton));
                break;

            case 4:
                greenButtonSelected = Resources.Load<Sprite>("Selected/selected_greenButton");
                greenButton.GetComponent<SpriteRenderer>().sprite = greenButtonSelected;
                AudioSource.PlayClipAtPoint(dGreen, new Vector3(5, 1, 2));
                greenButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(greenButton));
                break;

            case 5:
                redButtonSelected = Resources.Load<Sprite>("Selected/selected_redButton");
                redButton.GetComponent<SpriteRenderer>().sprite = redButtonSelected;
                AudioSource.PlayClipAtPoint(red, new Vector3(5, 1, 2));
                redButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(redButton));
                break;

            case 6:
                lGreenButtonSelected = Resources.Load<Sprite>("Selected/selected_lgreenButton");
                lGreenButton.GetComponent<SpriteRenderer>().sprite = lGreenButtonSelected;
                AudioSource.PlayClipAtPoint(LGreen, new Vector3(5, 1, 2));
                lGreenButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(lGreenButton));
                break;

            case 7:
                purpleButtonSelected = Resources.Load<Sprite>("Selected/selected_purpleButton");
                purpleButton.GetComponent<SpriteRenderer>().sprite = purpleButtonSelected;
                AudioSource.PlayClipAtPoint(purple, new Vector3(5, 1, 2));
                purpleButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(purpleButton));
                break;

            case 8:
                goldButtonSelected = Resources.Load<Sprite>("Selected/selected_goldButton");
                goldButton.GetComponent<SpriteRenderer>().sprite = goldButtonSelected;
                AudioSource.PlayClipAtPoint(gold, new Vector3(5, 1, 2));
                goldButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(goldButton));
                break;

            case 9:
                dRedButtonSelected = Resources.Load<Sprite>("Selected/selected_dRedButton");
                dRedButton.GetComponent<SpriteRenderer>().sprite = dRedButtonSelected;
                AudioSource.PlayClipAtPoint(dRed, new Vector3(5, 1, 2));
                dRedButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(dRedButton));
                break;

            case 10:
                orangeButtonSelected = Resources.Load<Sprite>("Selected/selected_orangeButton");
                orangeButton.GetComponent<SpriteRenderer>().sprite = orangeButtonSelected;
                AudioSource.PlayClipAtPoint(orange, new Vector3(5, 1, 2));
                orangeButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(orangeButton));
                break;

            case 11:
                cyanButtonSelected = Resources.Load<Sprite>("Selected/selected_cyanButton");
                cyanButton.GetComponent<SpriteRenderer>().sprite = cyanButtonSelected;
                AudioSource.PlayClipAtPoint(cyan, new Vector3(5, 1, 2));
                cyanButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                StartCoroutine(MoveDot(cyanButton));
                break;
        }

        stayLitCounter = stayLit;
        shouldBeLit = true;
        isTheNextRound = false;



    }

    public void ColourPressed(int whichButton)
    {

        if (gameActive)
        {
            if (activeSequence[inputInSequence] == whichButton)
            {
                //   print("NOMBRE DEL BOTON" + colours[activeSequence[0]]);

                //  StartCoroutine(MoveDot(redButton));

                trailPixel.gameObject.SetActive(false);
                trailPixel.transform.position = new Vector3(0f, -6.43f, 60.88171f);

                Debug.Log("Correct");
                script.addScore();
                inputInSequence++;

                if (inputInSequence >= activeSequence.Count)
                {
                    positionInSequence = 0;
                    inputInSequence = 0;

                    colourSelect = UnityEngine.Random.Range(0, colours.Length);

                    activeSequence.Add(colourSelect);
                    StartCoroutine(waitBeforeNewSequence());

                }
            }
            else
            {
                activeSequence.Clear();
                Debug.Log("Wrong");

                NumGame = NumGame + 1;
                PlayerPrefs.SetInt("NumGame", NumGame);

                GameObject buttonMainMenu = GameObject.Find("ButtonMainMenu");
                buttonMainMenu.GetComponent<Button>().enabled = true;

#if UNITY_ANDROID
                if (PlayGamesPlatform.Instance.IsAuthenticated())
                {
                    // Note: make sure to add 'using GooglePlayGames'
                    PlayGamesPlatform.Instance.ReportScore(score,
                        GPGSIds.leaderboard_top_players,
                        (bool success) =>
                        {
                            Debug.Log("(Lollygagger) Leaderboard update success: " + success);
                            Debug.Log("Score mandado " + score);
                        });
                }
#endif

#if UNITY_IOS
   PostScoreOnLeaderBoard(score);
#endif

                gameActive = false;
                // SliderCircle2.gameObject.SetActive(true);
                SliderCircle.gameObject.SetActive(true);
                StartCoroutine(playDeathSound());

                gameHasEnded = true;
                gameHasBegun = false;


                blueButton.GetComponent<BoxCollider2D>().enabled = false;
                cyanButton.GetComponent<BoxCollider2D>().enabled = false;
                redButton.GetComponent<BoxCollider2D>().enabled = false;
                goldButton.GetComponent<BoxCollider2D>().enabled = false;
                yellowButton.GetComponent<BoxCollider2D>().enabled = false;
                purpleButton.GetComponent<BoxCollider2D>().enabled = false;
                dRedButton.GetComponent<BoxCollider2D>().enabled = false;
                pinkButton.GetComponent<BoxCollider2D>().enabled = false;
                dPinkButton.GetComponent<BoxCollider2D>().enabled = false;
                greenButton.GetComponent<BoxCollider2D>().enabled = false;
                lGreenButton.GetComponent<BoxCollider2D>().enabled = false;
                orangeButton.GetComponent<BoxCollider2D>().enabled = false;

                blueButtonCopy.gameObject.SetActive(false);
                pinkButtonCopy.gameObject.SetActive(false);
                yellowButtonCopy.gameObject.SetActive(false);
                dPinkButtonCopy.gameObject.SetActive(false);
                greenButtonCopy.gameObject.SetActive(false);
                redButtonCopy.gameObject.SetActive(false);
                lGreenButtonCopy.gameObject.SetActive(false);
                purpleButtonCopy.gameObject.SetActive(false);
                goldButtonCopy.gameObject.SetActive(false);
                dRedButtonCopy.gameObject.SetActive(false);
                orangeButtonCopy.gameObject.SetActive(false);
                cyanButtonCopy.gameObject.SetActive(false);

            }
        }
    }

    IEnumerator waitBeforeNewSequence()
    {
        yield return new WaitForSeconds(.6f);

        colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f);
        // trailPixel.gameObject.SetActive(true);

        if (stateTrail == true && enableTrail == true)
        {
            trailPixel.gameObject.SetActive(true);
        }

        isFirstColor = true;

        stayLitCounter = stayLit;
        shouldBeLit = true;

        isTheNextRound = true;
        gameActive = false;

        blueButton.GetComponent<BoxCollider2D>().enabled = false;
        cyanButton.GetComponent<BoxCollider2D>().enabled = false;
        redButton.GetComponent<BoxCollider2D>().enabled = false;
        goldButton.GetComponent<BoxCollider2D>().enabled = false;
        yellowButton.GetComponent<BoxCollider2D>().enabled = false;
        purpleButton.GetComponent<BoxCollider2D>().enabled = false;
        dRedButton.GetComponent<BoxCollider2D>().enabled = false;
        pinkButton.GetComponent<BoxCollider2D>().enabled = false;
        dPinkButton.GetComponent<BoxCollider2D>().enabled = false;
        greenButton.GetComponent<BoxCollider2D>().enabled = false;
        lGreenButton.GetComponent<BoxCollider2D>().enabled = false;
        orangeButton.GetComponent<BoxCollider2D>().enabled = false;

        // print("POSICIÓN DE LA SECUENCIA" + activeSequence[0]);


    }

    public void ChangeSliderPosition(Slider slider)
    {

        if (slider.value >= 1)
        {
            mainSlider.value = 1f;
        }

        if (mainSlider.value == 1)
        {
            gameIsAboutToBegin = true;
        }

        if (mainSlider.value <= 0.08 && gameHasEnded)
        {
            gameIsAboutToEnd = true;
            // print("Game is about to End: " + gameIsAboutToEnd);
            PanelGameOver.gameObject.SetActive(true);
        }
    }
    IEnumerator playDeathSound()
    {
        yield return new WaitForSeconds(0.3f);
        AudioSource.PlayClipAtPoint(wrong, new Vector3(5, 1, 2));
    }


    public void ShowFredStore()
    {

#if UNITY_ANDROID
        buttonRestorePurchase.gameObject.SetActive(false);
#elif UNITY_IPHONE
 buttonRestorePurchase.gameObject.SetActive(true);
#endif


        state = !state;
        print("ESTADO" + state);

        if (state == true)
        {
            GameObject sliderActive = GameObject.Find("Slider");
            sliderActive.GetComponent<Slider>().enabled = false;
            PanelGameScene.gameObject.SetActive(false);
        }
        else
        {
            GameObject sliderActive = GameObject.Find("Slider");
            sliderActive.GetComponent<Slider>().enabled = true;
            PanelGameScene.gameObject.SetActive(true);
        }
        menuFredStore.gameObject.SetActive(state);

    }

    public void ActivateTrail()
    {
        // enableTrail = true;
        stateTrail = !stateTrail;

        if (stateTrail == true)
        {
            trailPixel.gameObject.SetActive(true);
            trailOnSprite = Resources.Load<Sprite>("Icons/TrailTurnedOn");
            trailObject.GetComponent<SpriteRenderer>().sprite = trailOnSprite;

            PlayerPrefs.SetInt("stateTrail", Convert.ToInt32(stateTrail));

            print("Se prendio");
        }
        else
        {
            trailPixel.gameObject.SetActive(false);
            trailOnSprite = Resources.Load<Sprite>("Icons/TrailTurnedOff");
            trailObject.GetComponent<SpriteRenderer>().sprite = trailOnSprite;
            PlayerPrefs.SetInt("stateTrail", Convert.ToInt32(stateTrail));
            print("Se apago");
        }
    }

    //METODOS PARA LOGIN
    public void SignInCallback(bool success)
    {

        if (success)
        {
            Debug.Log("(Lollygagger) Signed in!");

            // Change sign-in button text
            print("Sign out");

            // Show the user's name
            print("Signed in as: " + Social.localUser.userName);
        }
        else
        {
            Debug.Log("(Lollygagger) Sign-in failed...");
#if UNITY_ANDROID
            LoginAndroid();
#endif
#if UNITY_IPHONE

#endif
            // Show failure message
            print("Sign in");
            print("Sign-in failed");
        }

    }
    public void LoginAndroid()
    {
#if UNITY_ANDROID
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            // Sign out of play games
            PlayGamesPlatform.Instance.SignOut();

            // Reset UI
            print("Sign In");

        }
#endif

    }
    //METODOS PARA LEADERBOARDS
    void ReportScore(long score, string leaderboardID)
    {
        Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
        Social.ReportScore(score, leaderboardID, success =>
        {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
    }

    public static bool IsGCUseLoggedIn
    {
        get
        {
            Debug.Log("LOGGEDIN " + Social.localUser.authenticated);
            return Social.localUser.authenticated;

        }
    }
    public static string GCUsername
    {
        get
        {
            return Social.Active.localUser.userName;
        }
    }
    public static void SignIn(System.Action<bool> callback)
    {
        Social.localUser.Authenticate(callback);
        Debug.Log("CALLBACK " + callback);
    }


    public static void UpdateLeaderboard(string id, long score)
    {
        if (IsGCUseLoggedIn)
        {
            Social.ReportScore(score, id, null);
        }

    }


    public void PostScoreOnLeaderBoard()

    {


        if (loginSuccessful)

        {

            Debug.Log("si entro al login");

            Social.ReportScore(score, "LeaderboardFredMemory", (bool success) =>
            {

                if (success)

                    Debug.Log("Successfully uploaded");


                // handle success or failure

            });

        }

        else

        {

            Social.localUser.Authenticate((bool success) =>
            {

                if (success)

                {

                    loginSuccessful = true;

                    Debug.Log("Si se arma");

                    Social.ReportScore(score, "LeaderboardFredMemory", (bool successful) =>
                    {

                        // handle success or failure

                        Debug.Log("Si se arma2");
                    });

                }

                else

                {

                    Debug.Log("unsuccessful");

                }

                // handle success or failure

            });

        }

    }
}
