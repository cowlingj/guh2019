using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseMenu;
    private bool paused = false;
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (paused == false)
            {
                paused = true;
                Time.timeScale = 0.0f;
                PauseMenu.SetActive(true);
            }
            else if (paused == true)
            {
                paused = false;
                Time.timeScale = 1.0f;
                PauseMenu.SetActive(false);
            }
        }
    }
}
