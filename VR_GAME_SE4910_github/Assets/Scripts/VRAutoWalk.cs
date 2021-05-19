using UnityEngine;
using System.Collections;
//my file, used unity docs and random tutorials from stack overflow but
//main functionality architected by me
[RequireComponent(typeof(CharacterController))]
public class VRAutoWalk : MonoBehaviour
{
    //character walking and turning speed
    //made the player only slightly faster than the bird
    public float speed = 4.5F;
    public float rotateSpeed = 3.0F;
    public float toggleAngle = 30.0f;
    public bool moveforward;

    void Update()
    {
        
        CharacterController controller = GetComponent<CharacterController>();
        //folows the camera, which is a child of the player, so if they look down past the toggel angle, they will toggle
        //motion and either start or stop walking
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
