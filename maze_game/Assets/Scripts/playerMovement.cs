using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public static CharacterController controller;
    public static Vector3 playerVelocity;
    private bool groundedPlayer = false;
    private float playerSpeed = 2.0f;
    //private float jumpHeight = 20.0f;
    private float gravityValue = -9.81f;
    private Animator animator;
    private int keycount = 0;


    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>(); 

    }

    public void Update()
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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                print("Left shift down");
                playerSpeed = 4.0f;
                animator.SetFloat("speed", playerSpeed);
            }
            else
            {
                playerSpeed = 2.5f;
                animator.SetFloat("speed", playerSpeed);
            }

            

        }
        else
        {
            animator.SetFloat("speed", 0f);
        }

        // Changes the height position of the player.. FIGURE OUT LATER
        /*if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        */
        
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("hit", true);
        }
        animator.SetBool("hit", false);


        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "key")
        {
            keycount += 1;
            print(keycount);
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}

