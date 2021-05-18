using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskController : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyBall", 5f);
    }
    //make the ball destroy itself after a few seconds
    public void DestroyBall()
    {
        Destroy(gameObject);
    }
}
