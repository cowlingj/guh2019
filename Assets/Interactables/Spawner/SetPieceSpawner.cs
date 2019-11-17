using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetPieceSpawner : MonoBehaviour
{
  private List<EnablableObject> instances = new List<EnablableObject>();

  public PriorityObject[] templates = { };

  private List<GameObject> unrolledTemplates = new List<GameObject>();

  public float tickLength = 1f;

  public float tickVariance = 1f;

  public float minTickLength = 0.1f;

  public float initialDelay = 0f;

  private void Start()
  {
    foreach (PriorityObject obj in templates)
    {
      for (int i = 0; i < obj.priority; i++)
      {
        unrolledTemplates.Add(obj.gameObject);
      }
    }

    Invoke("RunSpawn", initialDelay);
    InvokeRepeating("Clean", 0, 1);
  }

  private void RunSpawn()
  {
    StartCoroutine("Spawn");
  }

  private IEnumerator Spawn()
  {
    while (true)
    {
      instances.Add(
          new EnablableObject(
              false,
              Instantiate(unrolledTemplates[UnityEngine.Random.Range(0, unrolledTemplates.Count)], gameObject.transform)
          )
      );
      float wait = tickLength * UnityEngine.Random.Range(0.5f, 1.5f);
      yield return new WaitForSeconds(wait);
    }
  }

  void Clean()
  {
    Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

    List<EnablableObject> toRemove = new List<EnablableObject>();

    foreach (EnablableObject instance in instances)
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

    foreach (EnablableObject item in toRemove)
    {
      instances.Remove(item);
    }

  }

  private class EnablableObject
  {

    public bool enabled;
    public GameObject gameObject;

    public EnablableObject(bool enabled, GameObject gameObject)
    {
      this.enabled = enabled;
      this.gameObject = gameObject;
    }
  }

  [System.Serializable]
  public class PriorityObject
  {

    public int priority;
    public GameObject gameObject;
  }
}
