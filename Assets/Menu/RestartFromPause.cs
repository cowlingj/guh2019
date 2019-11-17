using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartFromPause : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Main Game");
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1.0f;
    }
}
