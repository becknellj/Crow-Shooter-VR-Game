using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
   // public Light myLight;
    //public GameObject myCam;

    public float speed = 3F;
    public bool moveForward;
    private CharacterController controller;
    public GameObject player;


    void Start()
    {
        controller = player.GetComponent<CharacterController>();

    }
    public void ToggleLight(){
        //myLight.enabled = !myLight.enabled;
        // myCam.transform.Translate(Vector3.forward * Time.deltaTime * 20);
        // move = !move;
        moveForward = !moveForward;
        Debug.Log("hello bestie");

        if (moveForward)
        {
            Debug.Log("hello bestie");
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
    }
}

