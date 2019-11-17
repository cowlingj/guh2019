using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider speed;
    public string speedLabel = "Speed";
    public float defaultSpeed = 1;

    public Toggle developerMode;
    public string developerModeLabel = "DeveloperMode";
    public bool defaultDeveloperMode = false;
    void OnEnable()
    {
        speed.value = PlayerPrefs.GetFloat(speedLabel, defaultSpeed);
        developerMode.isOn = PlayerPrefs.GetInt(developerModeLabel, defaultDeveloperMode ? 1 : 0) == 1;
    }

    public void Save() {

        PlayerPrefs.SetFloat(speedLabel, speed.value);
        PlayerPrefs.SetInt(developerModeLabel, developerMode.isOn ? 1 : 0);
    }

    public void ClearSavedData() {

        PlayerPrefs.DeleteAll();
    }
}
