/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public bool isSprinting = false;
    private float gravity = -9.18f;
    private bool isGrounded;
    private float jumpHeight = 1.0f;

    private Rigidbody rb;
    private Animator animator;
    CharacterController cb; 


    public void Start()
    {
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
            
            
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Animator animator;


    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>(); 

    }

    public void FixedUpdate()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y <= 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            animator.SetFloat("speed", playerSpeed);
        }
        else
        {
            print("Standing still");
            animator.SetFloat("speed", 0f);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

