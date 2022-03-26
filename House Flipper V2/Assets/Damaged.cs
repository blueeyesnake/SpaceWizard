using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Damaged : MonoBehaviour
{
    public int health = 30;
    public int damage = 10;
    public TextEditor myText;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Robber"))
        {
            SceneManager.LoadScene(2);
        }
           

    }

    
}
