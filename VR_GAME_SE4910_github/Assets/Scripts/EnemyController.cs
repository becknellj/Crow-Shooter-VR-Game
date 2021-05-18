using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static Action OnEnemyDied;


    public float speed;

    public float xRange;
    public float yRange;
    public float zRange;
    
    // Start is called before the first frame update
    void Start()
    {
        //get enemy to look at us
        transform.LookAt(Camera.main.transform);
    }

    // Update is called once per frame
    //make enemy move to the player
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed); //always moving forward at a consistent speed
        transform.LookAt(Camera.main.transform);

    }
    //make enemy die when hit
    void OnTriggerEnter(Collider other)
    {
        //if we are hitting the bird with a disk
        if (other.gameObject.tag == "Disk")
        {
            if (OnEnemyDied!=null)
            {
                OnEnemyDied();
            }
            TeleportEnemy();
        }
      
    }
    //when an enemy dies he reappears in a random spot
    public void TeleportEnemy()
    {
        //Random.Range()
        float newX = UnityEngine.Random.Range(-xRange, xRange);
        float newY = UnityEngine.Random.Range(4, yRange);
        float newZ = UnityEngine.Random.Range(-zRange, zRange);

        transform.position = new Vector3(newX, newY, newZ);
        //transform.LookAt(player.transform.position);
        transform.LookAt(Camera.main.transform);
        
    }

}
