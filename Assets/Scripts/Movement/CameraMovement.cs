using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform camera_position;

    // Update is called once per frame
    private void Update()
    {
        transform.position = camera_position.position;
    }
}
