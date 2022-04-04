using UnityEngine;

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

    //enemy health objects
    public int maxHealth = 100;
    public int currentHealth;
    public healthBar healthBar;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //replace key down with actual damage detection
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(4);
        }


        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {   startPoint = transform.position;
            SpawnProjectile(Mathf.RoundToInt(Random.Range(minNumberOfProjectiles, maxNumberOfProjectiles)));
            delay = Random.Range(1, 3);
            Debug.Log("Next Attack in: " + delay + " Seconds");
        }
 
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
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }    
}