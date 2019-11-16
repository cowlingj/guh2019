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
        for(int i = 0; i < airtime; i++)
        {
            if (i < airtime / 2)
            {
                transform.Translate(Vector3.up * jumpMultiplier);
            }
            else
            {
                transform.Translate(Vector3.up * -1 * jumpMultiplier);
            }
            yield return null;
        }
        isJumping = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            while(isJumping == false)
            {
                isJumping = true;
                StartCoroutine("playerJump");
            }
        }
    }
}
