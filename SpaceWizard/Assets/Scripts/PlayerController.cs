using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    // Start is called before the first frame update

    private Camera mainCamera;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        //finds camera in world
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
        //makes character look at mouse
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        //makes new plane at default position
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        //if the ray hits something in the world, returns true
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            //just for debugging where the player should be looking in the scene
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
    //instead of once per frame, fixed update happens at a set time
    private void FixedUpdate()
    {
        myRigidBody.velocity = moveVelocity;
    }
}
