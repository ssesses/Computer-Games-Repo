using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public Rigidbody rb;
    public float jumpSpeed;
    private float distanceToGround;
    public LayerMask FloorMask;
    public Transform GroundCheckTransform;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y, Input.GetAxis("Vertical") * movementSpeed);

        if(Input.GetButtonDown("Jump"))
        {
            if(Physics.CheckSphere(GroundCheckTransform.position, 1f, FloorMask))
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            }

        }
    }
}
