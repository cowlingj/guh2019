using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetPieceSpawner : MonoBehaviour
{
  private List<EnablableObject> instances = new List<EnablableObject>();

  public PriorityObject[] templates = { };

  private List<GameObject> unrolledTemplates = new List<GameObject>();

  public float delay = 1f;
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
      yield return new WaitForSeconds(delay);
    }
  }

  void Clean()
  {
    Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

    List<EnablableObject> toRemove = new List<EnablableObject>();

    foreach (EnablableObject instance in instances)
    {

      if (instance.gameObject == null)
      {
        toRemove.Add(instance);
        break;
      }

      bool visible = GeometryUtility.TestPlanesAABB(
          planes,
          GetBounds(instance.gameObject)
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

private Bounds GetBounds(GameObject obj) {
    Bounds bounds = new Bounds(obj.transform.position, Vector3.zero);
    Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
    foreach (Renderer renderer in renderers) {
        if (renderer.enabled) {
          bounds.Encapsulate(renderer.bounds);
        }
    }
    return bounds;
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
