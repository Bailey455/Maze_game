using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public bool isSprinting = false;
    private float gravity = -20f;

    private Rigidbody rb;
    private Animator animator;
    CharacterController cb; 

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        cb = gameObject.GetComponent<CharacterController>();
    }

    public void FixedUpdate()
    {
    // fancy movement script
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
    movementDirection.Normalize();

    transform.Translate(movementDirection * Time.deltaTime * movementSpeed, Space.World);

    animator.SetFloat("speed", movementSpeed);

    if (movementDirection != Vector3.zero)
    {
        transform.forward = movementDirection;
    }   
        

        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
        
        if(isSprinting == true)
        {
            movementSpeed = 3.0f; 
        }
        else
        {
            movementSpeed = 3.0f;
        }
        */
        
    }
}
