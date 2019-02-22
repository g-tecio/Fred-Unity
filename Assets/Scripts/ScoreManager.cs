using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI currentScoreText;

    public int currentScore = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        currentScoreText.text = currentScore.ToString();

    }

    public void addScore()
    {
        currentScore++;
        // print(currentScore);
    }
}
