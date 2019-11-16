using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collisionDetect : MonoBehaviour
{
    public Text ScoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("Main Menu");
        }
        else if (collision.CompareTag("Coin"))
        {
            score += 100;
            //Destroy(collision.gameObject);
        }
    }
}
