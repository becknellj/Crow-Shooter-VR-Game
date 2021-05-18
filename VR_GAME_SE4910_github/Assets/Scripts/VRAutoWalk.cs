using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class VRAutoWalk : MonoBehaviour
{
    public float speed = 4.5F;
    public float rotateSpeed = 3.0F;
    public float toggleAngle = 30.0f;
    public bool moveforward;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (Camera.main.transform.eulerAngles.x >= toggleAngle && Camera.main.transform.eulerAngles.x < 90)
        {
            moveforward = !moveforward;

        }
        if (moveforward)
        {
            // Rotate around y - axis
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

            // Move forward / backward
            Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }


    }
   
}
/*
 *  void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (Camera.main.transform.eulerAngles.x >= toggleAngle && Camera.main.transform.eulerAngles.x < 90)
        {
            moveforward = true;

        }
        else
        {
            moveforward = false;
        }
        if (moveforward)
        {
            // Rotate around y - axis
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

            // Move forward / backward
            Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
      

    }
*/




















































/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class VRAutoWalk : MonoBehaviour
    {
        public float speed = 3F;
        public bool moveForward;
        private CharacterController controller;



    // Start is called before the first frame update
    void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        public void ToggleMovement()
        {
            moveForward = !moveForward;

            if (moveForward)
            {
                //Debug.Log("hello bestie");

                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Debug.Log(forward.x);

                if(controller.SimpleMove(forward))
                {
                Debug.Log("hello bestie");
                }
                
            }
        }
    }/*
    public float speed = 3F;
    public bool moveForward;
    private CharacterController controller;
    public GameObject player;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        CubeController.OnCubeHit += AutoWalk;
       
    }
    private void OnDisable()
    {
        CubeController.OnCubeHit -= AutoWalk;

    }
    void AutoWalk()
    {
        Debug.Log("moveforward");
        moveForward = !moveForward;

       /* if (moveForward)
        {
            Vector3 forward = player.transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
    }*/

/*
 * public class VRAutoWalk : MonoBehaviour
{
    public float speed = 3F;
    public bool moveForward;
    private CharacterController controller;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public void ToggleMovement()
    {
        
       
        moveForward = !moveForward;
        
        if (moveForward)
        {
            Vector3 forward = player.transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
    }
}*/

/*public float speed = 3F;
   public bool moveForward;
   private CharacterController controller;
   public GameObject player;

   // Start is called before the first frame update
   void Start()
   {
       controller = GetComponent<CharacterController>();

   }

   // Update is called once per frame
   void Update()
   {
       if (Input.GetButtonDown("Fire1"))
       {
           moveForward = !moveForward;
       }
       if (moveForward)
       {
           Vector3 forward = player.transform.TransformDirection(Vector3.forward);
           controller.SimpleMove(forward * speed);
       }
   }*/