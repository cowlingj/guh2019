using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    private float timescale;
    public GameObject PauseMenu;
    private bool paused = false;
    void Update()
    {
        
        if (Input.GetKeyDown("p"))
        {            
            if (paused)
            {                
                paused = false;
                Time.timeScale = timescale;
                PauseMenu.SetActive(false);
            }
            else
            {
                timescale = Time.timeScale;
                paused = true;
                Time.timeScale = 0.0f;
                PauseMenu.SetActive(true);
            }
        }
    }
}
