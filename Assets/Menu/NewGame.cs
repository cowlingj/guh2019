using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void Settings() {
        // TODO
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
