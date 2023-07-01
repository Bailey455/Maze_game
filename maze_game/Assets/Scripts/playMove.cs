using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMove : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 90;
    public float gravity = -9.18f;
    public float jumpSpeed = 15;

    CharacterController CharacterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    public void Start()
    {
        CharacterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        if (CharacterController.isGrounded)
        {
            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;
            if(Input.GetButtonDown("Space"))
            {
                moveVelocity.y = jumpSpeed;
            }
        }

        //adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        CharacterController.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }
}

