using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
public Transform target;
public Vector3 offset;
public float rotationSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotationSensitivity;
        target.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotationSensitivity;
        target.Rotate(vertical, 0, 0);

        //Move camera based on target rotation
        float YAngle = target.eulerAngles.y;
        float XAngle = target.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(XAngle, YAngle, 0);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;
        transform.LookAt(target);
    }
}
