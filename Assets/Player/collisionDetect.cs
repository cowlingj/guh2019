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
        ScoreText.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Game Over");
        }
        else if (collision.CompareTag("Coin"))
        {
            score += 100;
            coinSound.Play();
            Destroy(collision.gameObject);
        }
    }
}
