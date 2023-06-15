using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed = 75.0f;
    public bool isSprinting = false;

    private Rigidbody rb;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        // fancy movement script
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * Time.deltaTime * movementSpeed);

       

        if (Input.GetKey(KeyCode.LeftShift))
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
        
    }
}
