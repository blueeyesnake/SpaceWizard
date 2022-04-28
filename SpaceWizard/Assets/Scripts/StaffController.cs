using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffController : MonoBehaviour
{

    public bool isFiring;
    public FireballController fireball;
    public float fireballSpeed;
    public PlayerController player;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;
    public int manaToLose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                FireballController newFireball = Instantiate(fireball, firePoint.position, firePoint.rotation) as FireballController;
                player.gameObject.GetComponent<PlayerController>().LoseMana(manaToLose);
                //sets fireballSpeed of the fireball object class equal to the fireballSpeed in this class
                newFireball.fireballSpeed = fireballSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
