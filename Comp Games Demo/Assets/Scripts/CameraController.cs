using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
public Transform target;
public Vector3 offset;
public float rotationSensitivity;
public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Get X and Y mouse position and rotate target accordingly
        float horizontal = Input.GetAxis("Mouse X") * rotationSensitivity;
        target.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotationSensitivity;
        pivot.Rotate(vertical, 0, 0);

        //Move camera based on target rotation
        float YAngle = target.eulerAngles.y;
        float XAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(XAngle, YAngle, 0);
        transform.position = target.position - (rotation * offset);

        transform.LookAt(target);
    }
}
