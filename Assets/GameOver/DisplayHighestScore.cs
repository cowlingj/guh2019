using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighestScore : MonoBehaviour
{
  public Text scoreText;
  private int maximumScore=0;
    // Start is called before the first frame update
    void Start()
    {
      int playerScore = PlayerPrefs.GetInt("score");
      if (playerScore> maximumScore)
      {
          maximumScore= playerScore;
          scoreText.text = "Highest score! Congrats!";
      }
      else
      {
         scoreText.text = "Highest score is: " + maximumScore.ToString();
      }
    }
  }

    // Update is called once per frame
