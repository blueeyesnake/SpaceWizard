using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApocalypseScene : MonoBehaviour
{
    public void StartApocalypse()
    {
        SceneManager.LoadScene(4);
    }
}
