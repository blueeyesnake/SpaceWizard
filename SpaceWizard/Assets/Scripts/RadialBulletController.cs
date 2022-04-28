using UnityEngine;
using UnityEngine.SceneManagement;

public class RadialBulletController : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int maxNumberOfProjectiles;             // Number of projectiles to shoot.
    public int minNumberOfProjectiles;
    public float projectileSpeed;               // Speed of the projectile.
    public GameObject ProjectilePrefab;         // Prefab to spawn.
    public float delay;
    [Header("Private Variables")]
    private Vector3 startPoint;                 // Starting position of the bullet.
    private const float radius = 1F;            // Help us find the move direction.
    private float timeRemaining = 3;
    public GameObject theEnemy;

    //enemy health objects
    public int maxHealth = 100;
    public int currentHealth;
    public healthBar healthBar;

    //for enemy movement
    private Rigidbody myRB;
    public float moveSpeed;
    public PlayerController thePlayer;

    public int deathCount;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>(); //gets rigidbody attached to enemy
        thePlayer = FindObjectOfType<PlayerController>(); //enemy automatically knows where player is

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        deathCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //theEnemy.GetComponent<Animator>().Play("Idle");
        //enemy moves towards player
        if (myRB.velocity.magnitude > 0)
        {
            theEnemy.GetComponent<Animator>().Play("Walk");
        }
        if (currentHealth > 0)
        {
            transform.LookAt(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z));
        }
            //transform.LookAt(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z));
        //replace key down with actual damage detection
        

        if(currentHealth <= 0)
        {
             
            theEnemy.GetComponent<Animator>().Play("Death"); //doesnt work for some reason
            //Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 10);
            deathCount++;
            if(deathCount >= 1)
            {
                SceneManager.LoadScene(2);
            }
            Destroy(gameObject);
            
        }


        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            theEnemy.GetComponent<Animator>().Play("Attack");
            startPoint = transform.position;
            SpawnProjectile(Mathf.RoundToInt(Random.Range(minNumberOfProjectiles, maxNumberOfProjectiles)));
            delay = Random.Range(1, 3);
            Debug.Log("Next Attack in: " + delay + " Seconds");
        }
 
    }

    private void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed);

        //myRB.velocity = (transform.forward * moveSpeed);
    }

    // Spawns x number of projectiles.
    private void SpawnProjectile(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            // Direction calculations.
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            // Create vectors.
            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            // Create game objects.
            GameObject tmpObj = Instantiate(ProjectilePrefab, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);

            // Destory the gameobject after 10 seconds.
            Destroy(tmpObj, 10F);

            angle += angleStep;
        }
    }

    //function for damaging enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    public int getDeathCount()
    {
        return deathCount;
    }    
   
}