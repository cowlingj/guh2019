using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collisionDetect : MonoBehaviour
{
    private bool ignoreObstacles = false;
    private bool ignoreCoins = false;
    public Text ScoreText;
    private int score;
    public AudioSource coinSound;

    void Start()
    {
        coinSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("HasTools") == 1 && Input.GetKeyDown("s"))
        {            
                score += 100;            
        }
        ScoreText.text = "Score: " + score.ToString();

        if (PlayerPrefs.GetInt("HasTools") == 1 && Input.GetKey("k"))
        {
            GameOver();
        }

        if (PlayerPrefs.GetInt("HasTools") == 1 && Input.GetKey("o"))
        {
            if (ignoreObstacles == false)
            {
                Debug.Log("Obstacles ignored");
                ignoreObstacles = true;
            }
            else
            {
                ignoreObstacles = false;
            }
        }

        if (PlayerPrefs.GetInt("HasTools") == 1 && Input.GetKey("c"))
        {
            if (ignoreCoins == false)
            {
                Debug.Log("Coins being ignored");
                ignoreCoins = true;
            }
            else
            {
                ignoreCoins = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            if (ignoreObstacles == true)
            {
                return;
            }
            else
            {
                GameOver();
            }
            
        }
        else if (collision.CompareTag("Coin"))
        {
            if (ignoreCoins == true)
            {
                return;
            }
            else
            {
                score += 100;
                coinSound.Play();
                Destroy(collision.gameObject);
            }           
        }
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game Over");
    }
}
