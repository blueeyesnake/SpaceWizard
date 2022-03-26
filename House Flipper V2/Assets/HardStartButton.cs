using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardStartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartHard()
    {
        SceneManager.LoadScene(3);
    }
}
