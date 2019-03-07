using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animController : MonoBehaviour
{

    public GameObject blueButton, cyanButton, redButton, goldButton, yellowButton, purpleButton, dRedButton, pinkButton, dPinkButton,
    greenButton, lGreenButton, orangeButton, panelGrayButtons, panelGameOver, panelGrayRestart;

    private bool gameHasBegun, gameHasEnded;
    private Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameHasBegun = GameObject.Find("GameManager").GetComponent<GameManager>().gameHasBegun;
        gameHasEnded = GameObject.Find("GameManager").GetComponent<GameManager>().gameHasEnded;

        if (gameHasBegun == true)
        {
            // print("INICIANDO ANIMACION");
            anim.Play("StartAnimation");
            StartCoroutine(ExecuteOpening(1.6f));
        }

        else if (gameHasEnded == true)
        {
            //   print("FINALIZANDO ANIMACION");
            anim.Play("EndAnimation");
            StartCoroutine(ExecuteEnding(1.6f));
        }
    }

    IEnumerator ExecuteOpening(float time)
    {
        yield return new WaitForSeconds(time);
        blueButton.gameObject.SetActive(false);
        cyanButton.gameObject.SetActive(false);
        redButton.gameObject.SetActive(false);
        goldButton.gameObject.SetActive(false);
        yellowButton.gameObject.SetActive(false);
        purpleButton.gameObject.SetActive(false);
        pinkButton.gameObject.SetActive(false);
        dPinkButton.gameObject.SetActive(false);
        greenButton.gameObject.SetActive(false);
        lGreenButton.gameObject.SetActive(false);
        dRedButton.gameObject.SetActive(false);
        orangeButton.gameObject.SetActive(false);

        panelGrayButtons.gameObject.SetActive(false);
    }


    IEnumerator ExecuteEnding(float time)
    {
        yield return new WaitForSeconds(time);
        panelGameOver.gameObject.SetActive(true);
        // panelGrayButtons.gameObject.SetActive(true);
        // panelGrayRestart.gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
