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

        if (Time.timeScale <= maxTimeScale) {
            Time.timeScale += timeScaleInc;
        }

        if (spawner && spawner.delay > minSpawnerDelay) {
            spawner.delay -= spawnerDelayDec;
        }
    }
}
