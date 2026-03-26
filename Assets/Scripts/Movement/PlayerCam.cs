using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sens_x;
    public float sens_y;

    public Transform orientation;

    float x_rotation;
    float y_rotation;
    
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // get mouse input
        float mouse_x = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens_x;
        float mouse_y = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens_y;

        y_rotation += mouse_x;
        x_rotation -= mouse_y;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90);

        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(x_rotation, y_rotation, 0);
        orientation.rotation = Quaternion.Euler(0, y_rotation, 0);
    }
}
