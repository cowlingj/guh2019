using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighestScore : MonoBehaviour
{

  public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
      highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
      int HighScore = PlayerPrefs.GetInt("HighScore", 0);
      int playerScore = PlayerPrefs.GetInt("score");
      if (playerScore> HighScore)
      {
          HighScore= playerScore;
          highScore.text = "Highest score! Congrats!";
          PlayerPrefs.SetInt("HighScore", HighScore);
          PlayerPrefs.Save();
      }
      else
      {
         highScore.text = "Highest score is: " + HighScore.ToString();
      }

    }
  }

    // Update is called once per frame
