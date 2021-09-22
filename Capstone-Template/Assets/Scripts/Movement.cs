using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var joystick = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick); // "joystick" is a 2D Vector (x, y)
        float fixedY = camera.GetComponent<Rigidbody>().position.y; // camera.transform is a 3D Vector (x, y, z), and y should never change

        camera.GetComponent<Rigidbody>().position += (transform.right * joystick.x + transform.forward * joystick.y) * speed * Time.deltaTime;
        camera.GetComponent<Rigidbody>().position = new Vector3(camera.GetComponent<Rigidbody>().position.x, fixedY, camera.GetComponent<Rigidbody>().position.z);

        if (joystick.x == 0 && joystick.y == 0)
            camera.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
