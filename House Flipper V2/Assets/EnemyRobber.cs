using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRobber : MonoBehaviour
{
    public float deathDistance = 0.5f;
    public float distanceAway;
    public Transform target;
    public NavMeshAgent enemy;
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(target.position);
        
    }
}
