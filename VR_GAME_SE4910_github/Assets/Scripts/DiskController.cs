using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//deletes ball after a few seconds to prevent an overload of objects in the scene
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
