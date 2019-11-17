using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text scoreText;
    void Update()
    {
        int playerScore = PlayerPrefs.GetInt("score");
        scoreText.text = "Your score is: " + playerScore.ToString();
        Debug.Log(playerScore);
    }
    
    
}
