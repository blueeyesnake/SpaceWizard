using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Robber"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Nothing happened");
        }
    }
}
