using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public float timeToLevelUp = 5;

    public float initialSpawnerDelay = 10f;
    public float minSpawnerDelay = 0.1f;
    public float spawnerDelayDec = 0.1f;

    public float initialTimeScale = 1f;
    public float maxTimeScale = 5f;
    public float timeScaleInc = 0.05f;

    public SetPieceSpawner spawner;
    void Start() {
        // TODO: look for the fields in player prefs
        Time.timeScale = initialTimeScale;
        spawner.delay = initialSpawnerDelay;
        InvokeRepeating("IncreaseDifficulty", timeToLevelUp, timeToLevelUp);        
    }

    void IncreaseDifficulty() {

        if (Time.timeScale >= maxTimeScale && spawner.delay <= minSpawnerDelay) {
            Time.timeScale = maxTimeScale;
            spawner.delay = minSpawnerDelay;
            CancelInvoke();
        }

        // TODO: verify easier
        if (Time.timeScale <= maxTimeScale * PlayerPrefs.GetFloat("Speed", 1)) {
            Time.timeScale += timeScaleInc * PlayerPrefs.GetFloat("Speed", 1);
        }

        if (spawner && spawner.delay * PlayerPrefs.GetFloat("Speed", 1) > minSpawnerDelay) {
            spawner.delay -= spawnerDelayDec * PlayerPrefs.GetFloat("Speed", 1);
        }
    }
}
