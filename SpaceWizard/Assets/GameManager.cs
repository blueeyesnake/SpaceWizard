
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public int deathCountOther;
    public int deathCountCorn;
    public RadialBulletController enemy;
    public CornController enemy2;

    void Start()
    {
        
    }
    void Update()
    {
        
        /*if (SceneManager.GetActiveScene().name.Equals("Level1") && killCount == 1)
        {
            SceneManager.LoadScene(2);
        }*/
        

        
    }
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            Debug.Log("Game over");
            gameHasEnded = true;
            ReturnToMenu();
        }
        
    }    

    void ReturnToMenu()
    {
        SceneManager.LoadScene(4);
    }

    void NextLevel()
    {
        SceneManager.LoadScene(2);
    }    
    
}
