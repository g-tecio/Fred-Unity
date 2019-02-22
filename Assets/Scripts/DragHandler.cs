using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool isBeingDragged = false;
    public bool gameIsAboutToBegin = false;
    public bool gameIsAboutToEnd = false;
    private bool gameHasEnded = false;

    private bool gameHasBegun = false;
    public Slider mainSlider;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameHasEnded = GameObject.Find("GameManager").GetComponent<GameManager>().gameHasEnded;
        gameHasBegun = GameObject.Find("GameManager").GetComponent<GameManager>().gameHasBegun;
    }
    public void OnDrag(PointerEventData eventData)
    {

    }

    public bool IsBeingDragged()
    {
        return isBeingDragged;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (mainSlider.value >= 0.6f)
        {
            mainSlider.value = 1f;
            gameIsAboutToBegin = true;
            StartCoroutine(cancelGameIsAboutToBegin());
        }
        else if (gameHasBegun == false)
        {
            mainSlider.value = 0f;
            //   print("Juego no iniciado");
        }

        if (mainSlider.value >= 0.6f && gameHasEnded == true)
        {
            //  print("NO DEBE VOLVER A INICIAR");
            gameIsAboutToBegin = false;
            mainSlider.value = 1f;
        }

        if (mainSlider.value <= 0.6f && gameHasEnded == true)
        {
            //   print("CONDITION");
            mainSlider.value = 0f;
            gameIsAboutToEnd = true;
            StartCoroutine(cancelGameIsAboutToEnd());
        }
        else if (gameHasBegun == true)
        {
            mainSlider.value = 1f;
            //   print("Juego no iniciado");
        }
    }

    IEnumerator cancelGameIsAboutToBegin()
    {
        yield return new WaitForSeconds(0.001f);

        gameIsAboutToBegin = false;
        //mainSlider.value = 0f;
    }


    IEnumerator cancelGameIsAboutToEnd()
    {
        yield return new WaitForSeconds(0.001f);

        gameIsAboutToEnd = false;
        //mainSlider.value = 0f;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        //   Debug.Log("drag start");

        isBeingDragged = true;
    }
}
