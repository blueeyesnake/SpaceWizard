using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CornController : MonoBehaviour
{
    public GameObject theEnemy;

    public int maxHealth = 100;
    public int currentHealth;
    public healthBar healthBar;

    private Rigidbody myRB;
    public float moveSpeed;
    public PlayerController thePlayer;

    public int deathCount;

    public int damageToGive = 20;
    // Start is called before the first frame update
    void Start()
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
        transform.LookAt(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z));
        if (currentHealth <= 0)
        {

            //Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 10);
            deathCount++;
            if(deathCount >= 1)
            {
                SceneManager.LoadScene(3);
            }
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed);

        //myRB.velocity = (transform.forward * moveSpeed);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damageToGive);
        }
    }

    public int getDeathCountCorn()
    {
        return deathCount;
    }
}
