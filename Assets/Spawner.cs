using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<GameObject> instances = new List<GameObject>();
    public GameObject template;

    public float x1 = 0;
    public float y1 = 0;

    public float x2 = 0;

    public float y2 = 0;

    private void Start() {
      InvokeRepeating("Spawn", 0, 1);  
    }

    void Spawn() {
        GameObject spawned = Instantiate(template, gameObject.transform);
        spawned.transform.position = new Vector3(
            Mathf.Lerp(x1, x2, Random.Range(0, 1)),
            Mathf.Lerp(y1, y2, Random.Range(0, 1)),
            0);
        instances.Add(spawned);
    }

    void Clean() {        
        foreach (GameObject item in instances.FindAll(
            (item) => !item.GetComponent<Renderer>().isVisible)
        ) {
            Destroy(item);
            instances.Remove(item);
        }
    }
}
