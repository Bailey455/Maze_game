using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    private float senseX;
    private float senseY;

    private Transform orientation;
    public Camera cam;
    public Vector3 camPos;

    private float xRotation;
    private float yRotation;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camPos = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse x input
        float mouseX = Input.GetAxisRaw("Mouse x") * Time.deltaTime * senseX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senseY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        cam.transform.position = this.transform.position + cam.transform.position;
    }
}
