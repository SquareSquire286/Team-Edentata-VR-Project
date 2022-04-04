using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// **************************************************************
// Purpose: This class implements the camera movement module via
//          the left joystick. It listens for a 2D vector of
//          floating-point numbers between -1.0 and 1.0, which 
//          represent the joystick's deviation from the default 
//          position in both horizontal and vertical directions, 
//          and applies this vector to the camera's rigidbody motion.
//***************************************************************
public class Movement : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject camera;
    private Rigidbody cameraRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        cameraRigidbody = camera.GetComponent<Rigidbody>(); // initialize the camera rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        var joystick = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick); // "joystick" is a 2D Vector (x, y)
        float fixedY = cameraRigidbody.position.y; // cameraRigidbody.position is a 3D Vector (x, y, z), and y should never change

        // apply joystick.x to the camera rigidbody's sway (X) axis, and joystick.y to the camera rigidbody's surge (Z) axis
        cameraRigidbody.position += (transform.right * joystick.x + transform.forward * joystick.y) * speed * Time.deltaTime;
        cameraRigidbody.position = new Vector3(cameraRigidbody.position.x, fixedY, cameraRigidbody.position.z);

        if (joystick.x == 0 && joystick.y == 0) // if no input is detected from the left joystick in either direction, zero the velocity vector
        {
            cameraRigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
}
