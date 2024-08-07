using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
public Transform target;
public Vector3 offset;
public float rotationSensitivity;
public Transform pivot;
public CameraShake shakingScript;

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

        //limit camera rotation
        if(pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(45f, 0, 0);
        }

        if(pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 315f)
        {
            pivot.rotation = Quaternion.Euler(315f, 0, 0);
        }

        //Move camera based on target rotation
        float YAngle = target.eulerAngles.y;
        float XAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(XAngle, YAngle, 0);

        if(shakingScript.Shaking == false)
        {
            transform.position = target.position - (rotation * offset);

            if(transform.position.y < target.position.y)
            {
                transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
            }
        }
        transform.LookAt(target);
    }
}
