using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireballController : MonoBehaviour
{

    public float fireballSpeed;

    public float lifeTime;

    public int damageToGive;
    public int killCount;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //multiplies by Time.deltaTime due to update only being called once per frame
        transform.Translate(Vector3.forward * fireballSpeed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<RadialBulletController>().TakeDamage(damageToGive);
            
        }

        if (other.gameObject.tag == "EnemyCorn")
        {
            other.gameObject.GetComponent<CornController>().TakeDamage(damageToGive);
            
        }
    }
}
