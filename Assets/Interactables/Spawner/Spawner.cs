using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  private List<EnableObject> instances = new List<EnableObject>();
  public GameObject template;

  public float x1 = 0;
  public float y1 = 0;
  public float x2 = 0;
  public float y2 = 0;

  public float initialDelay = 0;
  public float maxDelay = 1;
  public float minDelay = 1;

  private void Start()
  {
    Invoke("RunSpawn", initialDelay);
    InvokeRepeating("Clean", 0, 1);
  }

  private void RunSpawn() {
      StartCoroutine("Spawn");
  }

  private IEnumerator Spawn()
  {
      while (true) {
        GameObject spawned = Instantiate(template, gameObject.transform);
        spawned.transform.position = new Vector3(
            Mathf.Lerp(x1, x2, Random.Range(0f, 1f)),
            Mathf.Lerp(y1, y2, Random.Range(0f, 1f)),
            0);
        instances.Add(new EnableObject(false, spawned));
          yield return new WaitForSeconds(Mathf.Lerp(minDelay, maxDelay, Random.Range(0f, 1f)));
      }
  }

  void Clean()
  {
    Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

    List<EnableObject> toRemove = new List<EnableObject>();

    foreach (EnableObject instance in instances)
    {

      bool visible = GeometryUtility.TestPlanesAABB(
          planes,
          instance.gameObject.GetComponent<Renderer>().bounds
      );

      if (visible && !instance.enabled)
      {
        instance.enabled = true;
      }
      else if (!visible && instance.enabled)
      {
        Destroy(instance.gameObject);
        toRemove.Add(instance);
      }
    }

    foreach (EnableObject item in toRemove)
    {
      instances.Remove(item);
    }

  }

  private class EnableObject
  {

    public bool enabled;
    public GameObject gameObject;

    public EnableObject(bool enabled, GameObject gameObject)
    {
      this.enabled = enabled;
      this.gameObject = gameObject;
    }
  }
}
