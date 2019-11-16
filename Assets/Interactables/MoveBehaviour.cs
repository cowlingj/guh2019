using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{

    public float x = 0;
    public float y = 0;

    private Vector3 v;

    void Start() {
        v = new Vector3(x, y, 0);    
    }

    void Update() {
        gameObject.transform.Translate(v);
    }
}
