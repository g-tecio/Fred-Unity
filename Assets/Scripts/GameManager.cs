using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    public GameObject blueButton, cyanButton, redButton, goldButton, yellowButton, purpleButton, dRedButton, pinkButton, dPinkButton, greenButton, lGreenButton, orangeButton;

    public GameObject blueButtonSelected, cyanButtonSelected, redButtonSelected, goldButtonSelected, yellowButtonSelected, purpleButtonSelected, dRedButtonSelected, pinkButtonSelected, dPinkButtonSelected, greenButtonSelected, lGreenButtonSelected, orangeButtonSelected;

    // Start is called before the first frame update
    void Start()
    {
        print("start");


    }

    // Update is called once per frame
    void Update()
    {



    }

    public void blueButtonclick()
    {

        blueButton.gameObject.SetActive(false);
        blueButtonSelected.gameObject.SetActive(true);
        StartCoroutine(blueButtonDuration());
    }
    IEnumerator blueButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        blueButton.gameObject.SetActive(true);
        blueButtonSelected.gameObject.SetActive(false);
    }

    public void pinkButtonclick()
    {

        pinkButton.gameObject.SetActive(false);
        pinkButtonSelected.gameObject.SetActive(true);
        StartCoroutine(pinkButtonDuration());
    }
    IEnumerator pinkButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        pinkButton.gameObject.SetActive(true);
        pinkButtonSelected.gameObject.SetActive(false);
    }


    public void yellowButtonclick()
    {

        yellowButton.gameObject.SetActive(false);
        yellowButtonSelected.gameObject.SetActive(true);
        StartCoroutine(yellowButtonDuration());
    }
    IEnumerator yellowButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        yellowButton.gameObject.SetActive(true);
        yellowButtonSelected.gameObject.SetActive(false);
    }

    public void dPinkButtonclick()
    {

        dPinkButton.gameObject.SetActive(false);
        dPinkButtonSelected.gameObject.SetActive(true);
        StartCoroutine(dPinkButtonDuration());
    }
    IEnumerator dPinkButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        dPinkButton.gameObject.SetActive(true);
        dPinkButtonSelected.gameObject.SetActive(false);
    }

    public void greenButtonclick()
    {

        greenButton.gameObject.SetActive(false);
        greenButtonSelected.gameObject.SetActive(true);
        StartCoroutine(greenButtonDuration());
    }
    IEnumerator greenButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        greenButton.gameObject.SetActive(true);
        greenButtonSelected.gameObject.SetActive(false);
    }
    public void redButtonclick()
    {

        redButton.gameObject.SetActive(false);
        redButtonSelected.gameObject.SetActive(true);
        StartCoroutine(redButtonDuration());
    }
    IEnumerator redButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        redButton.gameObject.SetActive(true);
        redButtonSelected.gameObject.SetActive(false);
    }

    public void lGreenButtonclick()
    {

        lGreenButton.gameObject.SetActive(false);
        lGreenButtonSelected.gameObject.SetActive(true);
        StartCoroutine(lGreenButtonDuration());
    }
    IEnumerator lGreenButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        lGreenButton.gameObject.SetActive(true);
        lGreenButtonSelected.gameObject.SetActive(false);
    }

    public void purpleButtonclick()
    {

        purpleButton.gameObject.SetActive(false);
        purpleButtonSelected.gameObject.SetActive(true);
        StartCoroutine(purpleButtonDuration());
    }
    IEnumerator purpleButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        purpleButton.gameObject.SetActive(true);
        purpleButtonSelected.gameObject.SetActive(false);
    }

    public void goldButtonclick()
    {

        goldButton.gameObject.SetActive(false);
        goldButtonSelected.gameObject.SetActive(true);
        StartCoroutine(goldButtonDuration());
    }
    IEnumerator goldButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        goldButton.gameObject.SetActive(true);
        goldButtonSelected.gameObject.SetActive(false);
    }
    public void dRedlueButtonclick()
    {

        dRedButton.gameObject.SetActive(false);
        dRedButtonSelected.gameObject.SetActive(true);
        StartCoroutine(dRedButtonDuration());
    }
    IEnumerator dRedButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        dRedButton.gameObject.SetActive(true);
        dRedButtonSelected.gameObject.SetActive(false);
    }

    public void orangeButtonclick()
    {

        orangeButton.gameObject.SetActive(false);
        orangeButtonSelected.gameObject.SetActive(true);
        StartCoroutine(orangeButtonDuration());
    }
    IEnumerator orangeButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        orangeButton.gameObject.SetActive(true);
        orangeButtonSelected.gameObject.SetActive(false);
    }

    public void cyanButtonclick()
    {

        cyanButton.gameObject.SetActive(false);
        cyanButtonSelected.gameObject.SetActive(true);
        StartCoroutine(cyanButtonDuration());
    }
    IEnumerator cyanButtonDuration()
    {
        yield return new WaitForSeconds(0.5f);

        cyanButton.gameObject.SetActive(true);
        cyanButtonSelected.gameObject.SetActive(false);
    }
}

