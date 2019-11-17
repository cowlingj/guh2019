using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collisionDetect : MonoBehaviour
{
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            GameOver();
        }
        else if (collision.CompareTag("Coin"))
        {
            score += 100;
            coinSound.Play();
            Destroy(collision.gameObject);
        }
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game Over");
    }
}
