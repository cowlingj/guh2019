using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayScore : MonoBehaviour
{ //
    public Text scoreText;
    void Start()
    {
        int playerScore = PlayerPrefs.GetInt("score");
        scoreText.text = "Your score is: " + playerScore.ToString();

    //   /  if (playerScore> maximumScore)
    //       {maximumScore= playerScore;
    //       scoreText.text = "Highest score! Congrats!";}
    //     else scoreText.text = "Highest score is: " + maximumScore.ToString();
    //     Debug.Log(maximumScore);
    //     Debug.Log(playerScore);
     }


}
