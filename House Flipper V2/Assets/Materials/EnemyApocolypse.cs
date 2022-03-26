using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyApocolypse : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab0;
    public GameObject m_EnemyPrefab1;
    public GameObject m_EnemyPrefab2;
    public GameObject m_EnemyPrefab3;
    //public float timeRemaining = 10;
    //public bool timerIsRunning = false;
    WaitForSecondsRealtime _wait;
    public int random;
    public float timeRemaining = 10;
    public float timeLeft = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
        //InvokeRepeating("SpawnNewEnemy", 1, 2);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if (timeRemaining > 0)
            {
                SpawnNewEnemy();
                timeRemaining -= Time.deltaTime;
            }
            else
            {

                timeRemaining = 10;
            }
        }

        
    }
    

       


    void SpawnNewEnemy()
    {
        Instantiate(m_EnemyPrefab3, m_SpawnPoints[3].transform.position, Quaternion.identity);
        Instantiate(m_EnemyPrefab0, m_SpawnPoints[0].transform.position, Quaternion.identity);
        Instantiate(m_EnemyPrefab1, m_SpawnPoints[1].transform.position, Quaternion.identity);
        Instantiate(m_EnemyPrefab2, m_SpawnPoints[2].transform.position, Quaternion.identity);
        
    }
}
