using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float pLerp = .03f;
    public float rLerp = .01f;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, player.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, rLerp);
    }
}
