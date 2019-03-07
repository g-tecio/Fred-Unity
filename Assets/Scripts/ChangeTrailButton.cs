using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTrailButton : MonoBehaviour
{

    public Button trailButton;

    private bool selectedTrail;

    public Sprite trailOn;
    public Sprite trailOff;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        selectedTrail = false;
        if (selectedTrail == true)
        {
            trailButton.GetComponent<Image>().sprite = trailOn;

        }
        else
        {
            trailButton.GetComponent<Image>().sprite = trailOff;
        }

    }
}
