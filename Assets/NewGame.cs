using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    //public UnityEvent Event;
    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
        Debug.Log("I am clicked");
    }

}
