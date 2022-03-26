using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLinearMovement : MonoBehaviour
{
    public Transform[] target;
    public float speed;

    private int current;
    private int counter = 0;
    

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x <= target[current].position.x + 1 && transform.position.x >= target[current].position.x - 1 && counter == 0)
        {
            current = (current + 1) % target.Length;
            counter++;
            
            
        }
        else
        {


            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);



        }
        if (counter > 0)
        {
            Vector3 secondPosition = new Vector3(370.967f, 0f, 355.41f);
            if(transform.position.x < 370.967f && transform.position.z < 355.41f)
            {
                //transform.position = new Vector3(transform.position.x + 0.001f, transform.position.y, transform.position.z);
                Vector3 pos = Vector3.MoveTowards(transform.position, secondPosition, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
            {

            }
        }
        
        
    }
}
