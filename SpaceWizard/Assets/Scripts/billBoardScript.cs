using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billBoardScript : MonoBehaviour
{
    // this script makes the enemy health always face the camera

    public Transform cam;

    //LateUpdate is always called after update
    //allows the camera to move, and then the healthbar to point towards it in that order
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.position);
    }
}
