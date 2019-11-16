using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Restart() {
        SceneManager.LoadScene("Main Game");
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
