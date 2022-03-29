using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{

    public float fireballSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //multiplies by Time.deltaTime due to update only being called once per frame
        transform.Translate(Vector3.forward * fireballSpeed * Time.deltaTime);
        
    }
}
