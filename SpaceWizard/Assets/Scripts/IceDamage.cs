using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageToGive;

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<RadialBulletController>().TakeDamage(damageToGive);
        }
    }
}
