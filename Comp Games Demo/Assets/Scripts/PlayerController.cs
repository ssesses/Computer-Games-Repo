using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public Rigidbody rb;
    public float jumpSpeed;
    public LayerMask FloorMask;
    public Transform GroundCheckTransform;

    private Vector3 horizontalMove;
    private Vector3 verticalMove;

    // public GameObject Camera;
    // private Vector2 move, look;
    // private float lookRotation;
    // public float maxForce;

    // public void OnMove(InputAction.CallbackContext context)
    // {
    //     move = context.ReadValue<Vector2>();
    // }

    // public void OnLook(InputAction.CallbackContext context)
    // {
    //     look = context.ReadValue<Vector2>();
    // }

    // private void FixedUpdate()
    // {
    //     Vector3 currentVelocity = rb.velocity;
    //     Vector3 targetVelocity = new Vector3(move.x, 0, move.y);
    //     targetVelocity *= movementSpeed;

    //     targetVelocity = transform.TransformDirection(targetVelocity);

    //     Vector3 velocityChange = (targetVelocity - currentVelocity);

    //     Vector3.ClampMagnitude(velocityChange, maxForce);
    //     rb.AddForce(velocityChange, ForceMode.VelocityChange);

    //     rb.AddForce(velocityChange,ForceMode.VelocityChange);
    // }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * transform.right;
        verticalMove = Input.GetAxis("Vertical") * new Vector3(transform.forward.x, 0f, transform.forward.z);

        Vector3 direction = horizontalMove + verticalMove;

        transform.position += direction * movementSpeed * Time.deltaTime;
        //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y, Input.GetAxis("Vertical") * movementSpeed);


        if(Input.GetButtonDown("Jump"))
        {
            if(Physics.CheckSphere(GroundCheckTransform.position, 1f, FloorMask))
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            }

        }
    }
}
