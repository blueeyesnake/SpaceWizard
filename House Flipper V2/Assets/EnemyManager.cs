using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab0;
    public GameObject m_EnemyPrefab1;
    public GameObject m_EnemyPrefab2;
    public GameObject m_EnemyPrefab3;
    //public float timeRemaining = 10;
    //public bool timerIsRunning = false;
    public int random;
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("SpawnNewEnemy", 1, 2);
    }
    


    void SpawnNewEnemy()
    {
        random = Random.Range(1, 5);
        if (random == 1)
        {
            Instantiate(m_EnemyPrefab0, m_SpawnPoints[0].transform.position, Quaternion.identity);
        }

        if (random == 2)
        {
            Instantiate(m_EnemyPrefab1, m_SpawnPoints[1].transform.position, Quaternion.identity);
        }
        
        if(random == 3)
        {
            Instantiate(m_EnemyPrefab2, m_SpawnPoints[2].transform.position, Quaternion.identity);
        }
        
        if(random == 4)
        {
            Instantiate(m_EnemyPrefab3, m_SpawnPoints[3].transform.position, Quaternion.identity);
        }    
        
    }
}
