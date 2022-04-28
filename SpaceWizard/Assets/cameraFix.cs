using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFix : MonoBehaviour
{
    public Transform cam;
    // Start is called before the first frame update
    void LateUpdate()
    {
        Camera camera = Camera.main;
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);

    }
}
