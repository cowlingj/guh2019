using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenu : MonoBehaviour
{
    public GameObject parent;

    public void Activate() {
        gameObject.SetActive(true);
        parent.SetActive(false);
    }
    public void Back() {
        gameObject.SetActive(false);
        parent.SetActive(true);
    }
}
