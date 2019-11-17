using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool isJumping;
    public int airtime = 60;
    public float jumpMultiplier;


    IEnumerator playerJump()
    {
        jumpMultiplier = airtime / 200f;
        for (int i = 0; i < airtime; i++)
        {
            if (i < airtime / 2)
            {
                jumpMultiplier -= 0.01f;
                transform.Translate(Vector3.up * jumpMultiplier);
            }
            else if (i > airtime / 2)
            {
                jumpMultiplier += 0.01f;
                transform.Translate(Vector3.up * -1 * jumpMultiplier);
            }
            yield return null;
        }
        isJumping = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.Space))
        {
            while (isJumping == false)
            {
                isJumping = true;
                StartCoroutine("playerJump");
            }
        }
    }
}

