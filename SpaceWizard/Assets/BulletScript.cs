using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageToGive;
    
    private void OnCollisionEnter(Collision other)
    {
        bool redAura = other.gameObject.GetComponent<PlayerController>().redAura;
        bool blueAura = other.gameObject.GetComponent<PlayerController>().blueAura;
        Debug.Log(redAura + "RED AURA");
        Debug.Log(blueAura + "BLUE AURA");
        if (other.gameObject.tag == "Player")
        {
            if(gameObject.GetComponent<Renderer>().material.color == Color.blue && blueAura != true){
                other.gameObject.GetComponent<PlayerController>().TakeDamage(damageToGive);
                Debug.Log("BLUE HIT");
            }
            else if(gameObject.GetComponent<Renderer>().material.color == Color.red && redAura != true){
                 other.gameObject.GetComponent<PlayerController>().TakeDamage(damageToGive);
                Debug.Log("RED HIT");
            }
            // Debug.Log(gameObject.GetComponent<Renderer>().material.color);
            // if(redAura && ){

            // }
            // other.gameObject.GetComponent<PlayerController>().TakeDamage(damageToGive);
            Destroy(gameObject);
        }
    }
}
