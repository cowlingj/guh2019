using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableDevTools : MonoBehaviour
{
    public int Enabled = 0;
    public Toggle EnableTools;

    void Update()
    {
        if (EnableTools.isOn == true)
        {
            Enabled = 1;
            PlayerPrefs.SetInt("HasTools", Enabled);
        }
        else
        {
            Enabled = 0;
            PlayerPrefs.SetInt("HasTools", Enabled);
        }
        Debug.Log(Enabled);
    }
}
