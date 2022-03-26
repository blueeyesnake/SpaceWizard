using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public int jumped;

    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    public int killCount;
    //reference to in game camera
    public Transform cam;
    //for smooth turning
    //smooths turning
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    //flip spped
    public float rotSpeed = 700;

    public bool isColliding;
    public Collider collisionTemp;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Robber"))
        {
            isColliding = true;
            collisionTemp = collision;
        }
      
    }

    private void OnTriggerExit(Collider collision)
    {
        isColliding = false;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        //makes forward wherever camera is pointing
        movementDirection = Quaternion.AngleAxis(cam.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (characterController.isGrounded)
        {
            jumped = 0;
        }

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                
                ySpeed = jumpSpeed;
                jumped = 1;
                

            }
        }
        else
        {
            characterController.stepOffset = 0;
            jumped = 1;
            
                
        }

        if (jumped == 1)
        {

            transform.Rotate(new Vector3(rotSpeed, 0f, 0f) * 2.5f * Time.deltaTime);

            if (jumped == 1 && isColliding == true)
            {

                Destroy(collisionTemp.gameObject);
                killCount++;
                isColliding = false;


            }



        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        


        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            if(characterController.isGrounded)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        if(killCount >= 6)
        {
            SceneManager.LoadScene(5);
        }
    }
}